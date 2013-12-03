using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace MePOR.DataAccess
{
    class Database
    {
        string connectionSettings = "server=cs.westga.edu; port=3307; uid=cs3230f13m;" +
              "pwd=UttpzH3cY63xhfNS;database=cs3230f13m;";

        /// <summary>
        /// Creates a default database object that provides access to rent me database.
        /// </summary>
        public Database()
        {
        }

        #region QUERY LOGIN

        /// <summary>
        /// Checks the entered administrator username and password aginst the database.
        /// </summary>
        /// <param name="username">administrator username</param>
        /// <param name="password">administrator password</param>
        /// <returns>DataTable with the username and password of selected user. Empty DataTable
        /// if the information is invalid</returns>
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

        /// <summary>
        /// Checks the entered employee username and password aginst the database.
        /// </summary>
        /// <param name="username">employee username</param>
        /// <param name="password">employee password</param>
        /// <returns>DataTable with the username and password of selected user. Empty DataTable
        /// if the information is invalid</returns>
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

        /// <summary>
        /// Gets the employee number of the employee that corresponds to the username and password entered.
        /// </summary>
        /// <param name="username">employee username</param>
        /// <param name="password">employee password</param>
        /// <returns>DataTable with the employee number of selected user. Empty DataTable
        /// if the information is invalid</returns>
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

        #endregion QUERY LOGIN

        #region SEARCH CUSTOMER

        /// <summary>
        /// Searchs for customers in the database with the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">10 digit phone number for a customer in database</param>
        /// <returns>customer with specified phone number. Empty table if customer does not 
        /// exist with phone number</returns>
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

        /// <summary>
        /// Searches for member in database with specified name.
        /// </summary>
        /// <param name="fname">first name of member in database</param>
        /// <param name="lname">last name of memeber in database</param>
        /// <returns>DataTable of all members with specified first and last name. Empty
        /// table if member does not exist with the first and last name.</returns>
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

        #endregion SEARCH CUSTOMER

        /// <summary>
        /// Searches for items in the database.
        /// </summary>
        /// <param name="searchCriteria">Criteria such as item category that the item is to be
        /// searched by.</param>
        /// <param name="search">Keyword for the value in the database that corresponds to the
        /// specified criteria</param>
        /// <returns>DataTable with all of the items with the value for the specified 
        /// search criteria. Empty datatable is return if item does not exist.</returns>
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

        /// <summary>
        /// Gets a datatable of all of the rentals between the specified dates.
        /// </summary>
        /// <param name="startDate">The startdatetime of the transaction range.</param>
        /// <param name="endDate">The endatetime of the transaction range.</param>
        /// <returns></returns>
        public DataTable GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();

            string sql = "SELECT r.rentalid, fname, lname, rentaldatetime, duedate, i.name, c.quantityrented FROM ((RENTAL r JOIN CONTAINS c ON r.rentalid=c.rentalid) JOIN MEMBER m ON r.memberid=m.memberid) JOIN ITEM i ON c.itemnumber=i.itemnumber WHERE r.rentaldatetime >= @start AND r.rentaldatetime <= @end ";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add("@start", MySql.Data.MySqlClient.MySqlDbType.Date);
                cmd.Parameters.Add("@end", MySql.Data.MySqlClient.MySqlDbType.Date);

                cmd.Parameters["@start"].Value = startDate.Date.ToString("yyyy-MM-dd");
                cmd.Parameters["@end"].Value = endDate.Date.AddDays(1).ToString("yyyy-MM-dd");

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

        /// <summary>
        /// Poses a direct query on the database.
        /// </summary>
        /// <param name="query">Query to be executed on the database</param>
        /// <returns>DataTable with the results of the executed query.</returns>
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

        /// <summary>
        /// Inserts a member in the database.
        /// </summary>
        /// <param name="fName">First name of the new member</param>
        /// <param name="mInitial">Middle initial of the new member</param>
        /// <param name="lName">Last name of the new member</param>
        /// <param name="ssn">Social Security Number of the new member</param>
        /// <param name="phoneNumber">Phone number of the new member</param>
        /// <param name="street">Street address of the new member</param>
        /// <param name="city">City of the new member</param>
        /// <param name="state">State of the new member</param>
        /// <param name="zipCode">Zip code where the new member resides</param>
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

        #region INSERT RENTAL

        /// <summary>
        /// Inserts rental in the RENTAL table of the database.
        /// </summary>
        /// <param name="memberID">memberID the member who rented the item.</param>
        /// <param name="employeeID">employeeID of the employee who helped the member rent the item.</param>
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

        /// <summary>
        /// Insert rental information into CONTAINS table in the database.
        /// </summary>
        /// <param name="rentalID">ID of the rental transaction</param>
        /// <param name="selectedItems">Items in the rental transaction</param>
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

        #endregion INSERT RENTAL

        #region RETURNS

        /// <summary>
        /// Gets a datatable with the rental ids for rental transaction by a member
        /// with specified id.
        /// </summary>
        /// <param name="memberid">ID of member to get the rental transaction for.</param>
        /// <returns>DataTable with all of the rentalids by specified member.</returns>
        public DataTable GetRentalIDsOfMember(int memberid)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();

            string sql = "SELECT rentalid FROM RENTAL WHERE memberid=@memberid";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                try
                {

                    cmd.Parameters.Add("@memberid", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    cmd.Parameters["@memberid"].Value = memberid;

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

        /// <summary>
        /// Gets all the items rented in specified rentals
        /// </summary>
        /// <param name="rentalIds">IDs of the transactions to get the items for.</param>
        /// <returns>DataTable with all of the items rented in specified rental transactions</returns>
        public DataTable GetItemsAllRented(DataTable rentalIds)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();

            string sql =
                "SELECT C.containsid, C.itemnumber, I.dailyrate, C.quantityrented, R.rentaldatetime, DATEDIFF(CURDATE(), R.rentaldatetime) AS 'Days Since Rental' " +
                "FROM CONTAINS C, ITEM I, RENTAL R " +
                "WHERE C.rentalid=@rentalid " +
                "AND I.itemnumber=C.itemnumber " +
                "AND R.rentalid=C.rentalid";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                try
                {
                    foreach (DataRow currentRow in rentalIds.Rows)
                    {
                        int rentalid = Convert.ToInt32(currentRow["rentalid"]);

                        cmd.Parameters.Add("@rentalid", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        cmd.Parameters["@rentalid"].Value = rentalid;

                        cmd.Connection = new MySqlConnection(connectionSettings);
                        cmd.Connection.Open();
                        result = cmd.ExecuteReader();
                        dt.Load(result);
                        cmd.Parameters.Clear();

                    }
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    if (cmd.Connection != null)
                    {
                        cmd.Connection.Close();
                    }

                }
            }

            return dt;
        }

        /// <summary>
        /// Gets all of the rentals that have yet to be returned.
        /// </summary>
        /// <param name="allItemsRented">DataTable of all items rented</param>
        /// <returns>DataTable containing all of the rentals that have not yet been returned</returns>
        public DataTable GetRentalsNotReturned(DataTable allItemsRented)
        {
            MySqlDataReader result = null;
            DataTable dt = new DataTable();

            string sql = "SELECT SUM(quantityreturned) " +
                         "FROM RETURNTRANSACTION " +
                         "WHERE containsid=@containsid";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                try
                {

                    List<int> rowsToRemove = new List<int>();

                    foreach (DataRow currentRow in allItemsRented.Rows)
                    {
                        int qtyRented = Convert.ToInt32(currentRow["quantityrented"].ToString());

                        int containsid = Convert.ToInt32(currentRow["containsid"].ToString());

                        cmd.Parameters.Add("@containsid", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        cmd.Parameters["@containsid"].Value = containsid;

                        cmd.Connection = new MySqlConnection(connectionSettings);
                        cmd.Connection.Open();
                        result = cmd.ExecuteReader();
                        dt.Load(result);
                        cmd.Parameters.Clear();


                        int totalReturned = 0;
                        string totalReturnedString = dt.Rows[0].ItemArray[0].ToString();
                        if (!string.IsNullOrEmpty(totalReturnedString))
                        {
                            DataRow sumReturnedRow = dt.Rows[0];
                            totalReturned = Convert.ToInt32(sumReturnedRow[0].ToString());
                        }

                        if (totalReturned < qtyRented)
                        {
                            currentRow["quantityrented"] = qtyRented - totalReturned;
                        }
                        else if (totalReturned == qtyRented)
                        {
                            int index = allItemsRented.Rows.IndexOf(currentRow);
                            rowsToRemove.Add(index);
                        }

                        dt.Clear();
                        dt = new DataTable();

                    }

                    foreach (int index in rowsToRemove)
                    {
                        allItemsRented.Rows[index].Delete();
                    }

                    allItemsRented.AcceptChanges();

                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                }
                finally
                {
                    if (cmd.Connection != null)
                    {
                        cmd.Connection.Close();
                    }

                }
            }

            return allItemsRented;
        }

        /// <summary>
        /// Inserts a return into RETURNTRANSACTION table in database.
        /// </summary>
        /// <param name="employeeId">ID of the employee returning the items.</param>
        /// <param name="returningItems">Items that are being returned</param>
        /// <returns>decimal indicating the cost of the items returned.</returns>
        public decimal ReturnItems(int employeeId, DataTable returningItems)
        {
            string sql = "INSERT INTO RETURNTRANSACTION (returnemployeenum, containsid, returndatetime, fee, quantityreturned) " +
                         "VALUES (@returnemployeenum, @containsid, NOW(), @fee, @quantityreturned)";

            decimal totalFee = decimal.Zero;

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                try
                {

                    foreach (DataRow row in returningItems.Rows)
                    {
                        cmd.Parameters.Add("@returnemployeenum", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        cmd.Parameters.Add("@containsid", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        cmd.Parameters.Add("@fee", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        cmd.Parameters.Add("@quantityreturned", MySql.Data.MySqlClient.MySqlDbType.Int32);

                        cmd.Parameters["@returnemployeenum"].Value = employeeId;
                        cmd.Parameters["@containsid"].Value = Convert.ToInt32(row["containsid"].ToString());

                        int daysSinceRental = Convert.ToInt32(row["Days Since Rental"].ToString());

                        if (daysSinceRental <= 0)
                        {
                            daysSinceRental = 1;
                        }

                        decimal fee = (Convert.ToDecimal(row["dailyrate"].ToString()) *
                                      Convert.ToInt32(row["Quantity To Return"])) * daysSinceRental;

                        totalFee += fee;

                        cmd.Parameters["@fee"].Value = fee;
                        cmd.Parameters["@quantityreturned"].Value = Convert.ToInt32(row["Quantity To Return"]);

                        cmd.Connection = new MySqlConnection(connectionSettings);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        cmd.Connection.Close();
                        cmd.Parameters.Clear();

                        string updateSQL = "UPDATE ITEM SET itemsavailable=itemsavailable+@qty WHERE itemnumber=@itemnumber";
                        MySqlCommand updateCmd = new MySqlCommand(updateSQL);

                        updateCmd.Parameters.Add("@qty", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        updateCmd.Parameters.Add("@itemnumber", MySql.Data.MySqlClient.MySqlDbType.Int32);

                        updateCmd.Parameters["@qty"].Value = Convert.ToInt32(row["Quantity To Return"]);
                        updateCmd.Parameters["@itemnumber"].Value = Convert.ToInt32(row["itemnumber"]);

                        updateCmd.Connection = new MySqlConnection(connectionSettings);
                        updateCmd.Connection.Open();
                        updateCmd.ExecuteNonQuery();

                        updateCmd.Connection.Close();
                        updateCmd.Parameters.Clear();

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

            return totalFee;
        }

        #endregion RETURNS

        private static void HandleSqlException(MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    ShowErrorMessage("Cannot Connect To Server");
                    break;
                default:
                    ShowErrorMessage(ex.Message);
                    break;
            }
        }

        /// <summary>
        /// Pose test query to test access to the database.
        /// </summary>
        /// <returns>boolean value indicating connection to the database.</returns>
        public bool CanConnectToServer()
        {
            string sql = "SELECT fname FROM EMPLOYEE";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {

                try
                {
                    cmd.Connection = new MySqlConnection(connectionSettings);
                    cmd.Connection.Open();
                    cmd.ExecuteReader();

                    return true;
                }
                catch (MySqlException ex)
                {
                    HandleSqlException(ex);
                    return false;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
