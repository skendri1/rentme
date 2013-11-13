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
            String fname = this.fnameTextBox.Text;

            string query = "select memberid, fname, lname, phonenumber from MEMBER";
            string result = this.db.QueryDB(query);
            this.richTextBox.Text = result;
        }
    }
}
