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
        private static string COMMA_SEP = ",";
        private static string SINGLE_QUOTE = "'";

        public static void InsertNewMemberIntoDatabase(string fName, string mInitial, string lName, string ssn, string phoneNumber, string street, string city, string state, string zipCode)
        {

            Database db = new Database();

            string insert = "INSERT INTO MEMBER (fname, minitial, lname, ssn, phonenumber, street, city, state, zip) VALUES ";

            string values = "(" + SINGLE_QUOTE  + fName + SINGLE_QUOTE + COMMA_SEP 
                + SINGLE_QUOTE + mInitial + SINGLE_QUOTE + COMMA_SEP 
                + SINGLE_QUOTE + lName + SINGLE_QUOTE + COMMA_SEP
                + SINGLE_QUOTE + ssn + SINGLE_QUOTE + COMMA_SEP 
                + SINGLE_QUOTE + phoneNumber + SINGLE_QUOTE + COMMA_SEP 
                + SINGLE_QUOTE + street + SINGLE_QUOTE + COMMA_SEP 
                + SINGLE_QUOTE + city + SINGLE_QUOTE + COMMA_SEP 
                + SINGLE_QUOTE + state + SINGLE_QUOTE + COMMA_SEP 
                + SINGLE_QUOTE + zipCode + SINGLE_QUOTE + ")";

            string InsertQuery = insert + values;

            db.ExecuteNonQuery(InsertQuery);
        }

    }
}
