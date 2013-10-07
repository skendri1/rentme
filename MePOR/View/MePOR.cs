using System;
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
                Member member = form.NewMember;
                string memberInfo = "Name: " + member.MemberName + " Email: " + member.Email;
                MessageBox.Show(memberInfo, "Confirmation");
                
            }
        }
    }
}
