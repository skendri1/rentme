using MePOR.Model;
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
        string searchResults;
        Database db;

        public MemberSearch()
        {
            InitializeComponent();
            searchResults = "";
            db = new Database();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string query = "";

            string fnameText = this.fnameTextBox.Text;
            string lnameText = this.lnameTextBox.Text;
            string phoneText = this.phoneTextBox.Text;

            if ((!fnameText.Equals("") && !phoneTextBox.Text.Equals("")) || (!lnameText.Equals("") && !phoneTextBox.Text.Equals("")))
            {
                MessageBox.Show("Please search by both first and last name or by phone number only.");
                return;
            }
            if ((fnameText.Equals("") && lnameText.Equals("") && phoneText.Equals("")))
            {
                MessageBox.Show("Please search by both first and last name or by phone number only.");
                return;
            }

            if (!phoneText.Equals(""))
            {
                query = "select memberid, fname, lname, phonenumber from MEMBER where phonenumber=" + phoneText;
            }
            if (!fnameText.Equals("") && !lnameText.Equals(""))
            {
                query = "select memberid, fname, lname, phonenumber from MEMBER where fname='" + fnameText + "'&&lname='" + lnameText + "'";
            }

            string result = this.db.QueryDB(query,true);
            this.richTextBox.Text = result;
        }
    }
}
