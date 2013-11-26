using MePOR.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MePOR.Controller
{
    class SearchCustomerController
    {
        Database db;

        public SearchCustomerController(){
            db = new Database();
        }

        public string SearchCustomerByName(string fname, string lname)
        {
            this.db.SearchCustomerByName(fname, lname);

            return "";
        }

        public string SearchCustomerByPhone(string phoneNumber)
        {
            this.db.SearchCustomerByPhone(phoneNumber);

            return "";
        }        
    }
}
