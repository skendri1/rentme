using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MePOR.Controller;
using MePOR.Model;

namespace MePOR.View
{

    /// <summary>
    /// Handles the Registration form class.
    /// </summary>
    public partial class RegistrationForm : Form
    {

        private ArrayList ErrorInValidationLabels;
        private ArrayList ValidLabels;
        
        public ArrayList NewMemberInformation;
        
        /// <summary>
        /// Creates the registration form
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();
            this.AcceptButton = this.submitBtn;
            this.ErrorInValidationLabels = new ArrayList();
            this.ValidLabels = new ArrayList();
            this.NewMemberInformation = new ArrayList();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            // this.NewMember = new Member(this.nameTextBox.Text, this.emailTextBox.Text);

            this.ErrorInValidationLabels.Clear();
            this.ValidLabels.Clear();

            this.ValidateGivenInformation();
            if (this.ErrorInValidationLabels.Count != 0)
            {
                this.ChangeTextOfLabelsWithValidationErrors();
                return;
            }   

            this.SetNewMemberInformationArrayList();
            NewMemberRegistrationDatabaseController.InsertNewMemberIntoDatabase(this.firstNameTextBox.Text, 
                this.middleInitialTextBox.Text, this.lastNameTextBox.Text, this.ssnTextBox.Text, this.phoneNumberTextBox.Text, 
                this.streetTextBox.Text, this.cityTextBox.Text, this.stateTextBox.Text, this.zipCodeTextBox.Text);
            this.Close();
        }

        /// <summary>
        /// Validates the given information of the form
        /// </summary>
        private void ValidateGivenInformation()
        {
            //Validate SSN
            if (!NewMemberValidationController.ValidateSSN(this.ssnTextBox.Text))
            {
                this.ErrorInValidationLabels.Add(this.ssnLabel);
            }
            else
            {
                this.ValidLabels.Add(this.ssnLabel);
            }

            //Validate First Name
            if (!NewMemberValidationController.ValidateName(this.firstNameTextBox.Text))
            {
                this.ErrorInValidationLabels.Add(this.firstNameLabel);
            }
            else
            {
                this.ValidLabels.Add(this.firstNameLabel);
            }

            //Validate Middle Initial
            if (!NewMemberValidationController.ValidateName(this.middleInitialTextBox.Text) || this.middleInitialTextBox.Text.Length > 1)
            {
                this.ErrorInValidationLabels.Add(this.middleInitialLabel);
            }
            else
            {
                this.ValidLabels.Add(this.middleInitialLabel);
            }

            //Validate Last Name
            if (!NewMemberValidationController.ValidateName(this.lastNameTextBox.Text))
            {
                this.ErrorInValidationLabels.Add(this.lastNameLabel);
            }
            else
            {
                this.ValidLabels.Add(this.lastNameLabel);
            }

            //Validate Phone Number
            if (!NewMemberValidationController.ValidatePhoneNumber(this.phoneNumberTextBox.Text))
            {
                this.ErrorInValidationLabels.Add(this.phoneNumberLabel);
            }
            else
            {
                this.ValidLabels.Add(this.phoneNumberLabel);
            }

            //Validate Street
            if (this.streetTextBox.Text.Length == 0)
            {
                this.ErrorInValidationLabels.Add(this.streetLabel);
            }
            else
            {
                this.ValidLabels.Add(this.streetLabel);
            }

            //Validate City
            if (!NewMemberValidationController.ValidateName(this.cityTextBox.Text))
            {
                this.ErrorInValidationLabels.Add(this.cityLabel);
            }
            else
            {
                this.ValidLabels.Add(this.cityLabel);
            }

            //Validate State
            if (!NewMemberValidationController.ValidateName(this.stateTextBox.Text))
            {
                this.ErrorInValidationLabels.Add(this.stateLabel);
            }
            else
            {
                this.ValidLabels.Add(this.stateLabel);
            }

            //Validate Zip Code
            if (!NewMemberValidationController.ValidateZipCode(this.zipCodeTextBox.Text))
            {
                this.ErrorInValidationLabels.Add(this.zipCodeLabel);
            }
            else
            {
                this.ValidLabels.Add(this.zipCodeLabel);
            }

        }

        private void ChangeTextOfLabelsWithValidationErrors()
        {
            foreach (var label in this.ErrorInValidationLabels)
            {
                Label currentLabel = (Label) label;
                currentLabel.ForeColor = System.Drawing.Color.Red;
            }

            foreach (var label in this.ValidLabels)
            {
                Label currentLabel = (Label)label;
                currentLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void SetNewMemberInformationArrayList()
        {
            this.NewMemberInformation.Add(this.ssnTextBox.Text);
            this.NewMemberInformation.Add(this.firstNameTextBox.Text);
            this.NewMemberInformation.Add(this.middleInitialTextBox.Text);
            this.NewMemberInformation.Add(this.lastNameTextBox.Text);
            this.NewMemberInformation.Add(this.phoneNumberTextBox.Text);
            this.NewMemberInformation.Add(this.streetTextBox.Text);
            this.NewMemberInformation.Add(this.cityTextBox.Text);
            this.NewMemberInformation.Add(this.stateTextBox.Text);
            this.NewMemberInformation.Add(this.zipCodeTextBox.Text);
        }

    }
}
