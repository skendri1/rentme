using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MePOR.Model;

namespace MePOR.View
{
    public partial class RegistrationForm : Form
    {
        public Member NewMember;

        /// <summary>
        /// Creates the registration form
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();
            this.AcceptButton = this.submitBtn;
            this.invalidInputLabel.Text = "";
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            bool formHasErrors = false;

            if (this.nameTextBox.Text.Length < 1)
            {
                const string invalidNameString = "Name is required";
                this.invalidInputLabel.Text = invalidNameString;
                formHasErrors = true;
            }
            if (Member.IsEmailValid(this.emailTextBox.Text))
            {
                const  String invalidEmailString = "Email is invalid";
                if (formHasErrors)
                {
                    this.invalidInputLabel.Text = this.invalidInputLabel.Text + " " + invalidEmailString;
                }
                else
                {
                    this.invalidInputLabel.Text = invalidEmailString;
                }
                formHasErrors = true;
            }

            if (formHasErrors)
            {
                this.nameTextBox.Text = "";
                this.emailTextBox.Text = "";
            }

            else
            {
                this.NewMember = new Member(this.nameTextBox.Text, this.emailTextBox.Text);
                this.Close();
            }
        }


    }
}
