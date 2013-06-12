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
    public class CTerritory
    {
        //create some properties based on the database columns
        private int mTerritoryID;
        private string mCompanyName;

        public int TerritoryID
        {
            get { return mTerritoryID; }
            set { mTerritoryID = value; }
        }

        public string CompanyName
        {
            get { return mCompanyName; }
            set { mCompanyName = value; }
        }

        //create some variables we will need for any data access
        private SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
        private SqlCommand objCmd;

        //write a function to retrieve the Territory list
        public SqlDataReader getTerritories()
        {
            //instantiate our connection
            objConn.Open();

            //set up our SQL command
            objCmd = new SqlCommand("SELECT t.TerritoryID, r.RegionDescription  FROM Territories as t INNER JOIN Region as r ON t.RegionID = r.RegionID ORDER BY r.RegionDescription", objConn);

            //execute the command and store the results in an SqlDataReader
            SqlDataReader objRdr;
            objRdr = objCmd.ExecuteReader();

            //send the datareader to the code that called this function
            return objRdr;
        }

        public void getTerritory()
        {
            //loop up a Territory based on their ID
            objConn.Open();

            //set up SQL command
            string strSQL = "SELECT CompanyName FROM Territories WHERE TerritoryID = " + TerritoryID.ToString();
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

        public void saveTerritory()
        {
            // connect
            objConn.Open();

            //set up the sql
            string strSQL;
            if (TerritoryID == 0)
            {
                strSQL = "INSERT INTO Territories (CompanyName) VALUES ('" + CompanyName + "')";
            }
            else
            {
                strSQL = "UPDATE Territories SET CompanyName = '" + CompanyName +
                "' WHERE TerritoryID = " + TerritoryID.ToString();
            }
            objCmd = new SqlCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();

            //clean up
            objCmd.Dispose();
            objConn.Close();
        }

        public void deleteTerritory()
        {
            // connect
            objConn.Open();

            //set up the sql
            string strSQL = "DELETE FROM Territories WHERE TerritoryID = " + TerritoryID.ToString();
            objCmd = new SqlCommand(strSQL, objConn);
            objCmd.ExecuteNonQuery();

            //clean up
            objCmd.Dispose();
            objConn.Close();
        }
    }
}
