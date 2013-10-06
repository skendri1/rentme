using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MePOR.View;

namespace MePOR
{
    public partial class Login : Form
    {
        private string _username;
        private string _password;

        private const string EmployeeUsername = "employee";
        private const string AdminUsername = "admin";

        private Dictionary<string, string> userPasswords;

        public Login()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            this._username = this.usernameTextbox.Text;
            this._password = this.passwordTextbox.Text;

            if(this.userPasswords.ContainsKey(this._username))
            {
                string usernamesCorrectPassword;
                this.userPasswords.TryGetValue(this._username, out usernamesCorrectPassword);
                
                CheckPassword(usernamesCorrectPassword);
            }
            else
            {
                ShowInvalidDialog();
            }

        }

        private void CheckPassword(string usernamesCorrectPassword)
        {
            if (usernamesCorrectPassword != null && usernamesCorrectPassword.Equals(this._password))
            {
                MePOR meporApplication = new MePOR();
                meporApplication.ShowDialog(this);
                meporApplication.Dispose();
            }
            else
            {
                ShowInvalidDialog();
            }
        }

        private void ShowInvalidDialog()
        {
            Invalid invalidDialog = new Invalid();
            invalidDialog.ShowDialog(this);
            invalidDialog.Dispose();
        }

        private void LoadUsers()
        {
            this.userPasswords = new Dictionary<string, string> { { EmployeeUsername, _password }, { AdminUsername, _password } };
        }
    }
}
