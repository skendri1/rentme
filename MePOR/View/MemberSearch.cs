using MePOR.Controller;
using MePOR.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MePOR.View
{
    public partial class MemberSearch : Form
    {
        DBAccessController dbControl;
        DataTable result;

        public MemberSearch()
        {
            InitializeComponent();
            dbControl = new DBAccessController();
            this.AcceptButton = this.searchButton;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string fname = this.fnameTextBox.Text;
            string lname = this.lnameTextBox.Text;
            string phoneNumber = this.phoneTextBox.Text;

            if ((!fname.Equals("") && !phoneTextBox.Text.Equals("")) || (!lname.Equals("") && !phoneTextBox.Text.Equals("")))
            {
                MessageBox.Show("Please search by both first and last name or by phone number only.");
                return;
            }
            if ((fname.Equals("") && lname.Equals("") && phoneNumber.Equals("")))
            {
                MessageBox.Show("Please search by both first and last name or by phone number only.");
                return;
            }

            if (!phoneNumber.Equals(""))
            {
                result = this.dbControl.SearchCustomerByPhone(phoneNumber);
            }
            if (!fname.Equals("") && !lname.Equals(""))
            {
                result = this.dbControl.SearchCustomerByName(fname, lname);
            }
            
            this.memberSearchGrid.DataSource = result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
