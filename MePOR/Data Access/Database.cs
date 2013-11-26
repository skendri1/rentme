﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace MePOR.Model
{
    class Database
    {
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;

        string connectionSettings = "server=cs.westga.edu; port=3307; uid=cs3230f13m;" +
              "pwd=UttpzH3cY63xhfNS;database=cs3230f13m;";

        public Database()
        {

        }

        public string QueryDB(string query, bool withColumnNames)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                OpenConnection();
                ExecuteQuery(query);

                if (withColumnNames)
                {
                    sb.AppendLine(buildColumnNames(query));
                }

                sb.Append(buildRecords());
            }
            catch (MySqlException ex)
            {
                HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return sb.ToString();
        }

        public void PrintColumnNameTypes(string query)
        {
            try
            {
                OpenConnection();
                PrintColumnNames(query);
            }
            catch (MySqlException ex)
            {
                HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void PrintColumnNames(string query)
        {
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string nameType = (reader.GetName(i) + " (" + reader.GetFieldType(i).ToString().Replace("System.", "") + ")");
                Console.Write(nameType.PadRight(18, ' '));
            }
            Console.WriteLine("\n");
        }

        private static void HandleSqlException(MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    Console.WriteLine("Cannot connect to server.  Contact administrator");
                    break;
                case 1045:
                    Console.WriteLine("Invalid username/password, please try again");
                    break;
                default:
                    Console.WriteLine(ex.Message + "!\nPlease try again!");
                    break;
            }
        }

        private void CloseConnection()
        {
            if (reader != null)
                reader.Close();
            if (connection != null)
                connection.Close();
        }

        private string buildRecords()
        {
            ArrayList types = new ArrayList();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                types.Add(reader.GetFieldType(i));
            }

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sb.Append(readField((Type)types[i], i).PadRight(18, ' '));
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }

        private string buildColumnNames(string query)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string nameType = (reader.GetName(i));
                sb.Append(nameType.PadRight(18, ' '));
            }
            sb.Append("\n");

            return sb.ToString();
        }

        private string readField(System.Type type, int index)
        {
            if (reader.IsDBNull(index))
            {
                return "NULL";
            }
            if (type == typeof(System.String))
            {
                return reader.GetString(index);
            }
            if (type == typeof(System.Int32))
            {
                return reader.GetInt32(index).ToString();
            }
            if (type == typeof(System.Double))
            {
                return reader.GetDouble(index).ToString();
            }
            if (type == typeof(System.Decimal))
            {
                return reader.GetDouble(index).ToString();
            }
            if (type == typeof(System.DateTime))
            {
                return reader.GetDateTime(index).ToShortDateString();
            }
            return "-1";
        }

        private void ExecuteQuery(string query)
        {
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
        }

        /// <summary>
        /// Executes the given nonquery string
        /// </summary>
        /// <param name="nonquery">The nonquery string for the database</param>
        public void ExecuteNonQuery(string nonquery)
        {
            try
            {
                this.OpenConnection();



                command = new MySqlCommand(nonquery, connection);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

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

        private void OpenConnection()
        {
            connection = new MySqlConnection(connectionSettings);
            connection.Open();
        }

        //string sql = "SELECT UserId FROM User WHERE " +
        //    "UserName = @UserName AND Password = @Password";

        //using (SqlCommand cmd = new SqlCommand(sql))
        //{
        //    // Create the parameter objects as specific as possible.
        //    cmd.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 50);
        //    cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 25);

        //    // Add the parameter values.  Validation should have already happened.
        //    cmd.Parameters["@UserName"].Value = UserName;
        //    cmd.Parameters["@Password"].Value = Password;
        //    cmd.Connection = connnection;

        //    try
        //    {
        //        cmd.Connection.Open();
        //        var userId = cmd.ExecuteScalar();
        //    }
        //    catch (SqlException sx)
        //    {
        //        // Handle exceptions before moving on.
        //    }
        //}

    }
}