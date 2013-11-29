using System;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MePOR.View;
using MePOR.Controller;

namespace MePOR
{
    public enum UserType
    {
        Employee,
        Administrator
    };

    public partial class MePOR : Form
    {
        public const string NUMBER = "Number";
        public const string NAME = "Name";
        public const string CATEGORY = "Category";
        public const string STYLE = "Style";

        public readonly string[] ITEMSEARCHBY = { NUMBER, NAME, CATEGORY, STYLE };

        private int employeeid;

        private List<string> selectedItemIDs; 
        
        DBAccessController dbcontrol;

        public MePOR(UserType userType, int employeeid)
        {
            InitializeComponent();
            dbcontrol = new DBAccessController();
            this.searchByDropDown.DataSource = ITEMSEARCHBY;
            this.rentOrReturnExecuteButton.Text = "Rent";
            this.selectedItemIDs = new List<string>();

            this.employeeid = employeeid;
            MessageBox.Show(this.employeeid.ToString(), "employee id");
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            using (var form = new RegistrationForm())
            {
                var result = form.ShowDialog();
                this.Show();

                ArrayList memberInfo = form.NewMemberInformation;

                if (memberInfo.Count != 0)
                {
                    string memberInfoString ="SSN: " + memberInfo[0] + "\nFirst Name: " + memberInfo[1] + "\nMiddle Initial: " + memberInfo[2] + "\nLast Name: " + memberInfo[3] 
                        + "\nPhone: " + memberInfo[4] + "\nStreet: " + memberInfo[5] + "\nCity: " + memberInfo[6] + "\nState: " + memberInfo[7]
                        + "\nZip: " + memberInfo[8];
                
                    MessageBox.Show(memberInfoString, "Confirmation");
                }                
            }
        }

        private void memberSearchButton_Click(object sender, EventArgs e)
        {
            using (var form = new MemberSearch())
            {
                var result = form.ShowDialog();
                this.Show();

                DataTable selectedMember = form.result;

                if (selectedMember != null)
                {
                    this.memberDataGridView.DataSource = selectedMember;
                }
            }

            //var form = new MemberSearch();
            //form.ShowDialog();

           
        }

        private void searchItemsButton_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string search = this.search.Text;

            switch(this.searchByDropDown.Text)
            {
                case NUMBER:
                    dt = dbcontrol.SearchItem(NUMBER, search);
                    break;
                case NAME:
                    dt = dbcontrol.SearchItem(NAME, search);
                    break;
                case CATEGORY:
                    dt = dbcontrol.SearchItem(CATEGORY, search);
                    break;
                case STYLE:
                    dt = dbcontrol.SearchItem(STYLE, search);
                    break;
            }

            this.searchItemsGridView.DataSource = dt;
        }

        private void rentalRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.rentOrReturnExecuteButton.Text = "Rent";
        }

        private void returnRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.rentOrReturnExecuteButton.Text = "Return";
        }

        private void addToSelectedItemsButton_Click(object sender, EventArgs e)
        {

            if (this.searchItemsGridView.SelectedRows.Count <= 0)
            {
                return;
            }

            if (this.selectedItemsDataGridView.Columns.Count == 0)
            {
                foreach (DataGridViewColumn col in this.searchItemsGridView.Columns)
                {
                    this.selectedItemsDataGridView.Columns.Add(col.Name, col.HeaderText);
                }

                this.selectedItemsDataGridView.Columns.Add("Quantity To Rent", "Quantity To Rent");
            }

            
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
            foreach (DataGridViewRow selectedRow in this.searchItemsGridView.SelectedRows)
            {
                string selectedRowItemID = selectedRow.Cells[0].Value.ToString();
                if (!this.selectedItemIDs.Contains(selectedRowItemID))
                {

                    List<string> cells = new List<string>();

                    foreach (DataGridViewCell cell in selectedRow.Cells)
                    {
                        cells.Add(cell.Value.ToString());
                    }

                    cells.Add("1");

                    this.selectedItemsDataGridView.Rows.Add(cells.ToArray());
                    this.selectedItemIDs.Add(selectedRowItemID);
                    rowsToRemove.Add(selectedRow);
                }
            }

            foreach (DataGridViewRow row in rowsToRemove)
            {
                this.searchItemsGridView.Rows.Remove(row);
            }
        }

        private void rentOrReturnExecuteButton_Click(object sender, EventArgs e)
        {
            //If the rental radio button is selected, perform rental
            if (this.rentalRadio.Checked && memberDataGridView.Rows.Count == 1 && selectedItemsDataGridView.Rows.Count > 0)
            {
                int memberid = Convert.ToInt32(memberDataGridView[0, 0].Value);
                DataTable selectedItems = this.GetSelectedItemsDataTable();

                this.dbcontrol.InsertRental(memberid, this.employeeid, selectedItems);

                this.clearGrids();
            }
            //If the return radio button is selected, perform return
            else
            {
                
            }
        }

        private DataTable GetSelectedItemsDataTable()
        {
            DataTable dt = new DataTable();

            if (this.selectedItemsDataGridView.Columns.Count > 0)
            {
                foreach (DataGridViewColumn col in this.selectedItemsDataGridView.Columns)
                {
                    DataColumn dc = new DataColumn(col.Name.ToString());
                    dt.Columns.Add(dc);
                }
            }

            if (this.selectedItemsDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in this.selectedItemsDataGridView.Rows)
                {
                    List<string> cells = new List<string>();

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cells.Add(cell.Value.ToString());
                    }

                    DataRow newRow = dt.NewRow();
                    for (int i = 0; i < cells.Count; i++)
                    {
                        newRow[i] = cells[i];
                    }

                    dt.Rows.Add(newRow);
                    //this.selectedItemsDataGridView.Rows.Add(cells.ToArray());

                }
            }

            return dt;

        }

        private void selectedItemsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != this.selectedItemsDataGridView.Columns.Count - 1)
            {
                return;
            }

            string qtyToRentString = this.selectedItemsDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            string availableToRentString =
                this.selectedItemsDataGridView[e.ColumnIndex - 1, e.RowIndex].Value.ToString();

            int available = Convert.ToInt32(availableToRentString);
            int qtyToRent = Convert.ToInt32(qtyToRentString);

            if (qtyToRent > available || qtyToRent <= 0)
            {
                string invalidQty = "Quantity to rent is invalid, please choose a number from 1 to " +
                                    availableToRentString;

                MessageBox.Show(invalidQty, "Invalid Number");

                this.selectedItemsDataGridView[e.ColumnIndex, e.RowIndex].ErrorText = "Invalid Qty";
            }
            else
            {
                this.selectedItemsDataGridView[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
            }

        }

        private void clearSelectedItemsButton_Click(object sender, EventArgs e)
        {
            this.clearGrids();
        }

        private void clearGrids()
        {
            if (this.selectedItemsDataGridView.Rows.Count > 0)
            {
                this.selectedItemsDataGridView.Rows.Clear();
            }
            
            if (this.selectedItemIDs.Count > 0)
            {
                this.selectedItemIDs.Clear();
            }
        }

    }
}
