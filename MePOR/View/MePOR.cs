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
        }

        #region HELPER METHODS

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
        
        private void clearGrids()
        {
            if (this.selectedItemsDataGridView.Rows.Count > 0)
            {
                this.selectedItemsDataGridView.Rows.Clear();
                this.selectedItemsDataGridView.Columns.Clear();
                this.selectedItemsDataGridView.DataSource = null;
            }
            
            if (this.selectedItemIDs.Count > 0)
            {
                this.selectedItemIDs.Clear();
                this.selectedItemsDataGridView.DataSource = null;
            }

            this.selectedItemsDataGridView.DataSource = null;

            this.searchItemsGridView.DataSource = null;
            
            this.memberDataGridView.DataSource = null;
                        
        }

        private void ShowRentalConfirm()
        {
            DataTable dt = this.GetSelectedItemsDataTable();
            List<string> itemsString = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string currentRowString = string.Empty;

                currentRowString += "Item Number: " + row["itemnumber"].ToString();

                currentRowString += " Name: " + row["name"].ToString();

                currentRowString += " Category: " + row["category"].ToString();

                currentRowString += " Quantity Rented: " + row["Quantity To Rent"].ToString();

                itemsString.Add(currentRowString);
            }


            string completeString = string.Empty;

            foreach (string item in itemsString)
            {
                completeString += item + "\n";
            }

            MessageBox.Show(completeString + "\n\nDUE IN 7 DAYS", "Confirmation");

        }

        #endregion HELPER METHODS     
        
        #region BUTTON LISTENERS

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


            if (this.returnRadio.Checked && this.memberDataGridView.Rows.Count == 1)
            {
                int memberid = Convert.ToInt32(memberDataGridView[0, 0].Value);
                DataTable dt = this.dbcontrol.GetMembersRentalItems(memberid);
                this.searchItemsGridView.DataSource = dt;

                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("The selected member does not have any rentals.", "No Rentals");
                    this.clearGrids();
                }

            }
           
        }

        private void searchItemsButton_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string search = this.search.Text;

            switch(this.searchByDropDown.Text)
            {
                case NUMBER:
                    int temp;
                    if (int.TryParse(search, out temp))
                    {
                        dt = dbcontrol.SearchItem(NUMBER, search);
                    }
                    else
                    {
                        this.ShowErrorMessage("Search Criteria Must Be A Number");
                    }
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

        private void clearSelectedItemsButton_Click(object sender, EventArgs e)
        {
            this.clearGrids();
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

                if (rentalRadio.Checked)
                {
                    this.selectedItemsDataGridView.Columns.Add("Quantity To Rent", "Quantity To Rent");
                }
                else
                {
                    this.selectedItemsDataGridView.Columns.Add("Quantity To Return", "Quantity To Return");
                }
                
            }

            
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
            foreach (DataGridViewRow selectedRow in this.searchItemsGridView.SelectedRows)
            {
                string selectedRowID = selectedRow.Cells[0].Value.ToString();
                if (!this.selectedItemIDs.Contains(selectedRowID))
                {

                    List<string> cells = new List<string>();

                    foreach (DataGridViewCell cell in selectedRow.Cells)
                    {
                        cells.Add(cell.Value.ToString());
                    }

                    cells.Add("1");

                    this.selectedItemsDataGridView.Rows.Add(cells.ToArray());
                    this.selectedItemIDs.Add(selectedRowID);
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

            if (this.HasErrorText())
            {
                this.ShowErrorMessage("There is an error in the selected items");
                return;
            }

            //If the rental radio button is selected, perform rental
            if (this.rentalRadio.Checked && memberDataGridView.Rows.Count == 1 && selectedItemsDataGridView.Rows.Count > 0)
            {
                int memberid = Convert.ToInt32(memberDataGridView[0, 0].Value);
                DataTable selectedItems = this.GetSelectedItemsDataTable();

                this.dbcontrol.InsertRental(memberid, this.employeeid, selectedItems);

                this.ShowRentalConfirm();

                this.clearGrids();
            }
            //If the return radio button is selected, perform return
            else
            {

                decimal totalFee = this.dbcontrol.ReturnItems(this.employeeid, this.GetSelectedItemsDataTable());

                MessageBox.Show("Total: $" + totalFee, "Checkout", MessageBoxButtons.OK);
                
                this.clearGrids();

            }
        }

        #endregion BUTTON LISTENERS

        #region RADIO BUTTONS

        private void rentalRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.rentOrReturnExecuteButton.Text = "Rent";
            this.searchForItemsGroupBox.Text = "Search For Items";

            this.clearGrids();

            this.searchByLabel.Visible = true;
            this.searchByDropDown.Visible = true;

            this.searchLabel.Visible = true;
            this.search.Visible = true;

            this.searchItemsButton.Visible = true;
            this.searchItemsButton.Enabled = true;

        }

        private void returnRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.rentOrReturnExecuteButton.Text = "Return";
            this.searchForItemsGroupBox.Text = "Items Rented By Member";

            this.clearGrids();

            this.searchByLabel.Visible = false;
            this.searchByDropDown.Visible = false;

            this.searchLabel.Visible = false;
            this.search.Visible = false;

            this.searchItemsButton.Visible = false;
            this.searchItemsButton.Enabled = false;


        }

        #endregion RADIO BUTTONS
        
        private void selectedItemsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != this.selectedItemsDataGridView.Columns.Count - 1)
            {
                return;
            }

            string qtyString = this.selectedItemsDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            string availableString = string.Empty;

            if (rentalRadio.Checked)
            {
                availableString = this.selectedItemsDataGridView[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
            }
            else
            {
                availableString = this.selectedItemsDataGridView["quantityrented", e.RowIndex].Value.ToString();
            }

            int available = Convert.ToInt32(availableString);
            int qty = Convert.ToInt32(qtyString);

            if (qty > available || qty <= 0)
            {
                string invalidQty = "Quantity to rent/return is invalid, please choose a number from 1 to " +
                                    availableString;

                this.ShowErrorMessage(invalidQty);

                this.selectedItemsDataGridView[e.ColumnIndex, e.RowIndex].ErrorText = "Invalid Qty";
            }
            else
            {
                this.selectedItemsDataGridView[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
            }

        }

        #region ERROR METHODS

        private bool HasErrorText()
        {

            foreach (DataGridViewRow row in this.selectedItemsDataGridView.Rows )
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ErrorText.Length > 0)
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion ERROR METHODS
    }
}
