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

        public DBAccessController(){
            db = new Database();
        }
        
        public int GetCurrentEmployeeID(string username, string password)
        {
            DataTable dt = this.db.QueryEmployeeLoginID(username, password);

            int id = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            return id;
        }

        public DataTable SearchItem(string searchCriteria, string search)
        {
            return this.db.SearchItem(searchCriteria, search);
        }

        public DataTable PerformAdvancedQuery(string query)
        {
            return this.db.PerformAdvancedQuery(query);
        }

        #region SEARCH CUSTOMER

        public DataTable SearchCustomerByName(string fname, string lname)
        {
            return this.db.SearchCustomerByName(fname, lname);
        }

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

            DataTable itemsRentedAndQty = this.db.GetItemsRentedWithQty(rentalIds);

            return itemsRentedAndQty;
        }

        public void ReturnItems(int employeeid, DataTable returningItems)
        {
            
        }

        #endregion RETURNS
    }
}
