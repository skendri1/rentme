using MePOR.Controller;
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
    public partial class AdminInterface : Form
    {
        DBAccessController dbcontrol;

        public AdminInterface()
        {
            InitializeComponent();
            dbcontrol = new DBAccessController();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string query = queryTextbox.Text;
            DataTable dt = new DataTable();

            if (query != null && !query.Equals(""))
            {
                dt = dbcontrol.PerformAdvancedQuery(query);
                adminSearchGrid.DataSource = dt;
                return;
            }

            DateTime startDate = this.startDatePicker.Value;
            DateTime endDate = this.endDatePicker.Value;

            dt = dbcontrol.GetRentalsInDateRange(startDate, endDate);
            adminSearchGrid.DataSource = dt;
        }
    }
}
