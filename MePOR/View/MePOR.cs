using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MePOR
{
    public enum UserType
    {
        Employee,
        Administrator
    };

    public partial class MePOR : Form
    {
        public MePOR(UserType userType)
        {
            InitializeComponent();
            SetUserText(userType);
        }

        private void SetUserText(UserType userType)
        {
            if (userType == UserType.Employee)
            {
                this.userLabel.Text = "Employee System";
            }
            if (userType == UserType.Administrator)
            {
                this.userLabel.Text = "Administrator System";
            }
        }
    }
}
