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
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            bool formHasErrors = false;

           // this.NewMember = new Member(this.nameTextBox.Text, this.emailTextBox.Text);
            this.Close();
            
        }


    }
}
