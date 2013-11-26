﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MePOR.DataAccess;
using MePOR.View;
using MePOR.Controller;

namespace MePOR
{
    public partial class Login : Form
    {
        private string _username;
        private string _password;
        private DBAccessController dbControl;

        public Login()
        {
            InitializeComponent();
            dbControl = new DBAccessController();
            this.AcceptButton = this.loginButton;
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            this._username = this.usernameTextbox.Text;
            this._password = this.passwordTextbox.Text;

            Database db = new Database();

            if (dbControl.AuthenticateEmployee(this._username, this._password))
            {
                this.StartMePOR(UserType.Employee);
            }
            else if (dbControl.AuthenticateAdministrator(this._username, this._password))
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
