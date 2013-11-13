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
using System.Windows.Forms;
using MePOR.Model;
using MePOR.View;

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

        private void registerBtn_Click(object sender, EventArgs e)
        {
            using (var form = new RegistrationForm())
            {
                var result = form.ShowDialog();
                ArrayList memberInfo = form.NewMemberInformation;

                string memberInfoString ="SSN: " + memberInfo[0] + "\nFirst Name: " + memberInfo[1] + "\nMiddle Initial: " + memberInfo[2] + "\nLast Name: " + memberInfo[3] 
                    + "\nPhone: " + memberInfo[4] + "\nStreet: " + memberInfo[5] + "\nCity: " + memberInfo[6] + "\nState: " + memberInfo[7]
                    + "\nZip: " + memberInfo[8];
                
                MessageBox.Show(memberInfoString, "Confirmation");
                
            }
        }

        private void memberSearchButton_Click(object sender, EventArgs e)
        {
            var form = new MemberSearch();
            form.ShowDialog();
        }
    }
}
