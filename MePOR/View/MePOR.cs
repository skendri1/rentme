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

        DBAccessController dbcontrol;

        public MePOR(UserType userType)
        {
            InitializeComponent();
            dbcontrol = new DBAccessController();
            this.searchByDropDown.DataSource = ITEMSEARCHBY;
            this.rentOrReturnExecuteButton.Text = "Rent";
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
            if (this.selectedItemsDataGridView.Columns.Count == 0)
            {
                foreach (DataGridViewColumn col in this.searchItemsGridView.Columns)
                {
                    this.selectedItemsDataGridView.Columns.Add(col.Name, col.HeaderText);
                }

                this.selectedItemsDataGridView.Columns.Add("NumberToRent", "Quantity To Rent");
            }

            

            foreach (DataGridViewRow selectedRow in this.searchItemsGridView.SelectedRows)
            {
                List<string> cells = new List<string>();

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    cells.Add(cell.Value.ToString());
                }

                cells.Add("1");

                this.selectedItemsDataGridView.Rows.Add(cells.ToArray());
            }
        }


    }
}
