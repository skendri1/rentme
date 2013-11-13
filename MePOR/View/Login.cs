using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MePOR.Model;
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

        //TODO: Get rid of this dictionary (not used)
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

            Database db = new Database();
            string queryEmployee = "SELECT username, password FROM EMPLOYEE WHERE username=" + "'" + this._username + "'" + "AND password=" + "'" +
                           this._password + "'";
            string resultsEmployee = db.QueryDB(queryEmployee,false);

            string queryAdmin = "SELECT username, password FROM ADMINISTRATOR WHERE username=" + "'" + this._username + "'" + "AND password=" + "'" +
                           this._password + "'";
            string resultsAdmin = db.QueryDB(queryAdmin, false);

           /*
            if(this._userPasswords.ContainsKey(this._username))
            {
                string usernamesCorrectPassword;
                
                CheckPassword(this._userPasswords[this._username]);
            }
            */
            if (resultsEmployee.Length > 0)
            {
                this.StartMePOR(UserType.Employee);
            }
            else if (resultsAdmin.Length > 0)
            {
                this.StartMePOR(UserType.Administrator);
            }
            else
            {
                ShowInvalidDialog();
            }

        }

        private void StartMePOR(UserType userType)
        {
            MePOR meporApplication = new MePOR(userType);
            this.Hide();
            meporApplication.ShowDialog(this);
            meporApplication.Dispose();
            this.Show();
        }

        //TODO: Get rid of this method (not used)
        private void CheckPassword(string usernamesCorrectPassword)
        {
            if (usernamesCorrectPassword != null && usernamesCorrectPassword.Equals(this._password))
            {
                MePOR meporApplication = new MePOR(GetUserType());
                this.Hide();
                meporApplication.ShowDialog(this);
                meporApplication.Dispose();
                this.Show();
            }
            else
            {
                ShowInvalidDialog();
            }
        }

        //TODO: Get rid of this method (not used)
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

        //TODO: Get rid of this method (not used)
        private void LoadUsers()
        {
            this._userPasswords = new Dictionary<string, string>
                                     {{EmployeeUsername, DefaultPassword}, {AdminUsername, DefaultPassword}};

        }
    }
}
