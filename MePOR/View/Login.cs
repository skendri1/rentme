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
        private const string DefaultPassword = "password";

        private Dictionary<string, string> _userPasswords;

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = this.loginButton;
            LoadUsers();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            this._username = this.usernameTextbox.Text;
            this._password = this.passwordTextbox.Text;

            if(this._userPasswords.ContainsKey(this._username))
            {
                string usernamesCorrectPassword;
                
                CheckPassword(this._userPasswords[this._username]);
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
                MePOR meporApplication = new MePOR(GetUserType());
                meporApplication.ShowDialog(this);
                meporApplication.Dispose();
            }
            else
            {
                ShowInvalidDialog();
            }
        }

        private UserType GetUserType()
        {
            if(this._username.Equals(EmployeeUsername))
            {
                return UserType.Employee;
            }
            if(this._username.Equals(AdminUsername))
            {
                return UserType.Administrator;
            }
            return UserType.Employee;
        }

        private void ShowInvalidDialog()
        {
            Invalid invalidDialog = new Invalid();
            invalidDialog.ShowDialog(this);
            invalidDialog.Dispose();
        }

        private void LoadUsers()
        {
            this._userPasswords = new Dictionary<string, string>
                                     {{EmployeeUsername, DefaultPassword}, {AdminUsername, DefaultPassword}};
        }
    }
}
