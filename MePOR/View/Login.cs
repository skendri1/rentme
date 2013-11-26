using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MePOR.DataAccess;
using MePOR.View;

namespace MePOR
{
    public partial class Login : Form
    {
        private string _username;
        private string _password;

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = this.loginButton;
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            this._username = this.usernameTextbox.Text;
            this._password = this.passwordTextbox.Text;

            Database db = new Database();
            string queryEmployee = "SELECT username, password FROM EMPLOYEE WHERE username=" + "'" + this._username + "'" + "AND password=" + "'" +
                           this._password + "'";
            string resultsEmployee = db.QueryDB(queryEmployee, false);

            string queryAdmin = "SELECT username, password FROM ADMINISTRATOR WHERE username=" + "'" + this._username + "'" + "AND password=" + "'" +
                           this._password + "'";
            string resultsAdmin = db.QueryDB(queryAdmin, false);

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

        private void ShowInvalidDialog()
        {
            Invalid invalidDialog = new Invalid();
            invalidDialog.ShowDialog(this);
            invalidDialog.Dispose();
        }

    }
}
