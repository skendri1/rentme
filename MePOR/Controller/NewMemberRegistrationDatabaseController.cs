using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MePOR.Model;

namespace MePOR.Controller
{
    public static class NewMemberRegistrationDatabaseController
    {
        public static void InsertNewMemberIntoDatabase(string fName, string mInitial, string lName, string ssn, string phoneNumber, string street, string city, string state, string zipCode)
        {

            Database db = new Database();
            db.InsertNewMember(fName, mInitial, lName, ssn, phoneNumber, street, city, state, zipCode);
        }

    }
}
