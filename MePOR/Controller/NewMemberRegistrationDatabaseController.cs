using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MePOR.DataAccess;

namespace MePOR.Controller
{
    /// <summary>
    /// Creates a new member registraton Controller.
    /// </summary>
    public static class NewMemberRegistrationDatabaseController
    {
        /// <summary>
        /// Provides a way for the GUI to insert a new member in the database.
        /// </summary>
        /// <param name="fName">First name of new member</param>
        /// <param name="mInitial">Middle Initial of new member.</param>
        /// <param name="lName">Last name of new member</param>
        /// <param name="ssn">Social Security Number of new Member</param>
        /// <param name="phoneNumber">Phone Number of new member</param>
        /// <param name="street">Street Address of new member</param>
        /// <param name="city">City of new member</param>
        /// <param name="state">State of new member</param>
        /// <param name="zipCode">Zip Code of new member</param>
        public static void InsertNewMemberIntoDatabase(string fName, string mInitial, string lName, string ssn, string phoneNumber, string street, string city, string state, string zipCode)
        {

            Database db = new Database();
            db.InsertNewMember(fName, mInitial, lName, ssn, phoneNumber, street, city, state, zipCode);
        }

    }
}
