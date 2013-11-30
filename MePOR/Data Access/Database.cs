using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace MePOR.DataAccess
{
    class Database
    {
        string connectionSettings = "server=cs.westga.edu; port=3307; uid=cs3230f13m;" +
              "pwd=UttpzH3cY63xhfNS;database=cs3230f13m;";

        public Database()
        {
        }

        public DataTable QueryAdministratorLogin(string username, string password)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string sql = "SELECT username, password FROM ADMINISTRATOR WHERE username=@username AND password=@password";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add("@username", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@password", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);

                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@password"].Value = password;

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable QueryEmployeeLogin(string username, string password)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string sql = "SELECT username, password FROM EMPLOYEE WHERE username=@username AND password=@password";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add("@username", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@password", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);

                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@password"].Value = password;

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable QueryEmployeeLoginID(string username, string password)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string sql = "SELECT employeenum FROM EMPLOYEE WHERE username=@username AND password=@password";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add("@username", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@password", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);

                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@password"].Value = password;

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable SearchCustomerByPhone(string phoneNumber)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string sql = "select memberid, fname, lname, phonenumber from MEMBER where phonenumber=@phoneNumber";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add("@phoneNumber", MySql.Data.MySqlClient.MySqlDbType.VarChar, 10);
                cmd.Parameters["@phoneNumber"].Value = phoneNumber;

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable SearchItem(string searchCriteria, string search)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string sql = null;

            switch (searchCriteria)
            {
                case MePOR.NUMBER:
                    sql = "select itemnumber, name, category, style, dailyrate, totalstock, itemsavailable from ITEM where itemnumber=@number";
                    break;
                case MePOR.NAME:
                    sql = "select itemnumber, name, category, style, dailyrate, totalstock, itemsavailable from ITEM where name=@search";
                    break;
                case MePOR.CATEGORY:
                    sql = "select itemnumber, name, category, style, dailyrate, totalstock, itemsavailable from ITEM where category=@search";
                    break;
                case MePOR.STYLE:
                    sql = "select itemnumber, name, category, style, dailyrate, totalstock, itemsavailable from ITEM where style=@search";
                    break;
            }

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                if (searchCriteria.Equals(MePOR.NUMBER))
                {
                    cmd.Parameters.Add("@number", MySql.Data.MySqlClient.MySqlDbType.Int32, 11);
                    cmd.Parameters["@number"].Value = search;
                }
                else
                {
                    cmd.Parameters.Add("@search", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);
                    cmd.Parameters["@search"].Value = search;
                }

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable SearchCustomerByName(string fname, string lname)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string sql = "select memberid, fname, lname, phonenumber from MEMBER where fname=@fname && lname=@lname";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add("@fname", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@lname", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);

                cmd.Parameters["@fname"].Value = fname;
                cmd.Parameters["@lname"].Value = lname;

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();

            string sql = "SELECT r.rentalid, fname, lname, rentaldatetime, duedate, i.name, c.quantityrented FROM ((RENTAL r JOIN CONTAINS c ON r.rentalid=c.rentalid) JOIN MEMBER m ON r.memberid=m.memberid) JOIN ITEM i ON c.itemnumber=i.itemnumber WHERE r.rentaldatetime >= @start AND r.rentaldatetime <= @end ";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add("@start", MySql.Data.MySqlClient.MySqlDbType.DateTime);
                cmd.Parameters.Add("@end", MySql.Data.MySqlClient.MySqlDbType.DateTime);

                cmd.Parameters["@start"].Value = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters["@end"].Value = endDate.ToString("yyyy-MM-dd HH:mm:ss");

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable PerformAdvancedQuery(string query)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string sql = query;

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    result = cmd.ExecuteReader();
                    dt.Load(result);
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public void InsertNewMember(string fName, string mInitial, string lName, string ssn, string phoneNumber, string street, string city, string state, string zipCode)
        {
            string sql = "INSERT INTO MEMBER (fname, minitial, lname, ssn, phonenumber, street, city, state, zip) VALUES(@fName,@mInitial,@lName,@ssn,@phoneNumber,@street,@city,@state,@zipCode)";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                // Create the parameter objects as specific as possible.
                cmd.Parameters.Add("@fName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@mInitial", MySql.Data.MySqlClient.MySqlDbType.VarChar, 1);
                cmd.Parameters.Add("@lName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@ssn", MySql.Data.MySqlClient.MySqlDbType.VarChar, 9);
                cmd.Parameters.Add("@phoneNumber", MySql.Data.MySqlClient.MySqlDbType.VarChar, 10);
                cmd.Parameters.Add("@street", MySql.Data.MySqlClient.MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@city", MySql.Data.MySqlClient.MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@state", MySql.Data.MySqlClient.MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@zipCode", MySql.Data.MySqlClient.MySqlDbType.VarChar, 5);

                // Add the parameter values. 
                cmd.Parameters["@fName"].Value = fName;
                cmd.Parameters["@mInitial"].Value = mInitial;
                cmd.Parameters["@lName"].Value = lName;
                cmd.Parameters["@ssn"].Value = ssn;
                cmd.Parameters["@phoneNumber"].Value = phoneNumber;
                cmd.Parameters["@street"].Value = street;
                cmd.Parameters["@city"].Value = city;
                cmd.Parameters["@state"].Value = state;
                cmd.Parameters["@zipCode"].Value = zipCode;

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Returns the rental id of the inserted rental
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public int InsertRental(int memberID, int employeeID)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();
            string id = string.Empty;
            string sql =
                " INSERT INTO RENTAL (memberid, rentaldatetime, rentemployeenum, duedate) VALUES(@memberid, NOW(), @rentemployeenum, DATE_ADD(NOW(), INTERVAL 7 DAY))";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                // Create the parameter objects as specific as possible.
                cmd.Parameters.Add("@memberid", MySql.Data.MySqlClient.MySqlDbType.Int32, 11);
                cmd.Parameters.Add("@rentemployeenum", MySql.Data.MySqlClient.MySqlDbType.Int32, 11);

                // Add the parameter values. 
                cmd.Parameters["@memberid"].Value = memberID;
                cmd.Parameters["@rentemployeenum"].Value = employeeID;

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                    string rentalIDSQL = "SELECT last_insert_id();";

                    MySqlCommand rentalcmd = new MySqlCommand(rentalIDSQL);
                    rentalcmd.Connection = new MySqlConnection(connectionSettings);
                    rentalcmd.Connection.Open();
                    result = rentalcmd.ExecuteReader();
                    dt.Load(result);

                    string colName = dt.Columns[0].ColumnName;
                    id = dt.Rows[0].ItemArray[0].ToString();

                    rentalcmd.Connection.Close();


                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                
                return Convert.ToInt32(id);
            }
        
        }

        public void InsertRentalItems(int rentalID, DataTable selectedItems)
        {

            string sql =
                "INSERT INTO CONTAINS (rentalid, itemnumber, quantityrented) " +
                "VALUES(@rentalid, @itemnumber, @quantityrented)";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                try
                {
                
                    foreach (DataRow currentRow in selectedItems.Rows)
                    {
                        int itemNumber = Convert.ToInt32(currentRow["itemnumber"].ToString());
                        int qtyRented = Convert.ToInt32(currentRow["Quantity To Rent"]);

                        cmd.Parameters.Add("@rentalid", MySql.Data.MySqlClient.MySqlDbType.Int32, 11);
                        cmd.Parameters.Add("@itemnumber", MySql.Data.MySqlClient.MySqlDbType.Int32, 11);
                        cmd.Parameters.Add("@quantityrented", MySql.Data.MySqlClient.MySqlDbType.Int32, 11);

                        cmd.Parameters["@rentalid"].Value = rentalID;
                        cmd.Parameters["@itemnumber"].Value = itemNumber;
                        cmd.Parameters["@quantityrented"].Value = qtyRented;

                        cmd.Connection = new MySqlConnection(connectionSettings);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        cmd.Connection.Close();
                        cmd.Parameters.Clear();

                        string updateSQL = "UPDATE ITEM SET itemsavailable=itemsavailable-@qty WHERE itemnumber=@itemnumber";
                        MySqlCommand updateCmd = new MySqlCommand(updateSQL);

                        updateCmd.Parameters.Add("@qty", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        updateCmd.Parameters.Add("@itemnumber", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        updateCmd.Parameters["@qty"].Value = qtyRented;
                        updateCmd.Parameters["@itemnumber"].Value = itemNumber;

                        updateCmd.Connection = new MySqlConnection(connectionSettings);
                        updateCmd.Connection.Open();
                        updateCmd.ExecuteNonQuery();
                        updateCmd.Parameters.Clear();

                        updateCmd.Connection.Close();

                    }

      
                    
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        private static void HandleSqlException(MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    Console.WriteLine("Cannot connect to server.  Contact administrator");
                    break;
                default:
                    Console.WriteLine(ex.Message + "!\nPlease try again!");
                    break;
            }
        }
    }
}
