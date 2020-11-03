using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AutomationFramework.Helpers
{
    public static class DataBaseHelperExtension
    {
        //NOT TESTED

        //Open the connection

        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                LogHelpers.writeFile("ERROR ::" + e.Message);
            }

            return null;
        }

        //Close the connection

        public static void DBClose (this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                LogHelpers.writeFile("ERROR ::" + e.Message);
            }
        }

        //Execute Query

        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataTable dataTable;
            try
            {
                //Check the state of the connection to DB
                if(sqlConnection == null || (sqlConnection!= null && (sqlConnection.State == ConnectionState.Closed ||
                    sqlConnection.State == ConnectionState.Broken)))
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text; //not store proccedure

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                LogHelpers.writeFile("ERROR ::" + e.Message);
                return dataTable = null;
            }
            finally
            {
                sqlConnection.Close();
                dataTable = null;
            }
        }

    }
}
