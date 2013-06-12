using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//link to this for data access
using System.Data.SqlClient;

//link to this to read web.config
using System.Configuration;

namespace BusinessRules
{
    public class CSupplier
    {
        //create some properties based on the database columns
        private int mSupplierID;
        private string mCompanyName;

        public int SupplierID
        {
            get { return mSupplierID; }
            set { mSupplierID = value; }
        }

        public string CompanyName
        {
            get { return mCompanyName; }
            set { mCompanyName = value; }
        }

        //create some variables we will need for any data access
        private SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
        private SqlCommand objCmd;

        //write a function to retrieve the supplier list
        public SqlDataReader getSuppliers()
        {
            //instantiate our connection
            objConn.Open();

            //set up our SQL command
            objCmd = new SqlCommand("SELECT * FROM Suppliers ORDER BY CompanyName", objConn);

            //execute the command and store the results in an SqlDataReader
            SqlDataReader objRdr;
            objRdr = objCmd.ExecuteReader();

            //send the datareader to the code that called this function
            return objRdr;
        }

        public void getSupplier()
        {
            //loop up a supplier based on their ID
            objConn.Open();

            //set up SQL command
            string strSQL = "SELECT CompanyName FROM Suppliers WHERE SupplierID = " + SupplierID.ToString();
            objCmd = new SqlCommand(strSQL, objConn);

            //execute the command and store the results in an SqlDataReader
            SqlDataReader objRdr;
            objRdr = objCmd.ExecuteReader();

            //loop through the datareader (even though there's only 1 record)
            while (objRdr.Read())
            {
                CompanyName = objRdr.GetString(0);
            }

            //clean up
            objRdr.Close();
            objCmd.Dispose();
            objConn.Close();
        }

        public void saveSupplier()
        {
            // connect
            objConn.Open();

            //set up the sql
            string strSQL;
            if (SupplierID == 0)
            {
                strSQL = "INSERT INTO Suppliers (CompanyName) VALUES ('" + CompanyName + "')";
            }
            else
            {
                strSQL = "UPDATE Suppliers SET CompanyName = '" + CompanyName +
                "' WHERE SupplierID = " + SupplierID.ToString();
            }
            objCmd = new SqlCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();

            //clean up
            objCmd.Dispose();
            objConn.Close();
        }

        public void deleteSupplier()
        {
            // connect
            objConn.Open();

            //set up the sql
            string strSQL = "DELETE FROM Suppliers WHERE SupplierID = " + SupplierID.ToString();
            objCmd = new SqlCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();

            //clean up
            objCmd.Dispose();
            objConn.Close();
        }
    }
}
