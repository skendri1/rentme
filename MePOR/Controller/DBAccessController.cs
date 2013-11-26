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

        public DataTable SearchCustomerByName(string fname, string lname)
        {
            return this.db.SearchCustomerByName(fname, lname);
        }

        public DataTable SearchCustomerByPhone(string phoneNumber)
        {
            return this.db.SearchCustomerByPhone(phoneNumber);
        }

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
    }
}
