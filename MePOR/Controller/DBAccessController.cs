using MePOR.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MePOR.Controller
{
    class DBAccessController
    {
        Database db;

        /// <summary>
        /// Creates a new DBAccessControll that provides the GUI and interface to the database.
        /// </summary>
        public DBAccessController(){
            db = new Database();
        }
        
        /// <summary>
        /// Gets the ID of the employee with specified username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>employee ID number</returns>
        public int GetCurrentEmployeeID(string username, string password)
        {
            DataTable dt = this.db.QueryEmployeeLoginID(username, password);

            int id = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            return id;
        }

        /// <summary>
        /// Returns an item with specified criteria and search keyword.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <param name="search"></param>
        /// <returns>returns all items with specified criteria and keyword</returns>
        public DataTable SearchItem(string searchCriteria, string search)
        {
            return this.db.SearchItem(searchCriteria, search);
        }

        /// <summary>
        /// Provides an interface for the administrator to perform an advanced query on the database.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>DataTable with the results of the advanced query.</returns>
        public DataTable PerformAdvancedQuery(string query)
        {
            return this.db.PerformAdvancedQuery(query);
        }

        /// <summary>
        /// Test to see if there is a valid connection to the database.
        /// </summary>
        /// <returns>Boolean indicating a connection with the database</returns>
        public bool CanConnectToDB()
        {
            return this.db.CanConnectToServer();
        }

        #region SEARCH CUSTOMER

        /// <summary>
        /// Searches the database for members with specified name.
        /// </summary>
        /// <param name="fname">first name of member</param>
        /// <param name="lname">last name of member</param>
        /// <returns>DataTable of all members with specified name</returns>
        public DataTable SearchCustomerByName(string fname, string lname)
        {
            return this.db.SearchCustomerByName(fname, lname);
        }

        /// <summary>
        /// Searches the database for all members with specified phone number.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>DataTable of all members with specified phone number.</returns>
        public DataTable SearchCustomerByPhone(string phoneNumber)
        {
            return this.db.SearchCustomerByPhone(phoneNumber);
        }

        #endregion SEARCH CUSTOMER

        #region AUTHENTICATE LOGINS

        public Boolean AuthenticateEmployee(string username, string password)
        {
            DataTable dt = this.db.QueryEmployeeLogin(username, password);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }

        public Boolean AuthenticateAdministrator(string username, string password)
        {
            DataTable dt = this.db.QueryAdministratorLogin(username, password);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }

        #endregion AUTHENTICATE LOGINS

        #region RENTALS

        public DataTable GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            return this.db.GetRentalsInDateRange(startDate, endDate);
        }

        public void InsertRental(int memberid, int employeenum, DataTable selectedItemsDataTable)
        {
            int rentalID = this.db.InsertRental(memberid, employeenum);

            this.db.InsertRentalItems(rentalID, selectedItemsDataTable);
        }

        #endregion RENTALS

        #region RETURNS

        public DataTable GetMembersRentalItems(int memberid)
        {
            DataTable rentalIds = this.db.GetRentalIDsOfMember(memberid);

            DataTable allItemsRented = this.db.GetItemsAllRented(rentalIds);

            DataTable allRentalsNotReturned = this.db.GetRentalsNotReturned(allItemsRented);

            return allRentalsNotReturned;
        }

        public decimal ReturnItems(int employeeid, DataTable returningItems)
        {
            decimal totalFee = this.db.ReturnItems(employeeid, returningItems);

            return totalFee;
        }

        #endregion RETURNS
    }
}
