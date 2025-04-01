using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class SqlDataReaderAppl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string dataSource = @"Server=(local)\SQLEXPRESS; uid=programmer; pwd=pass; 
database=MyWebSite_(CSB)";

        SqlConnection myConn = new SqlConnection(dataSource);
        myConn.Open();

        string mySql = "SELECT * FROM MemberTbl";
        SqlCommand myCmd = new SqlCommand(mySql, myConn);


        SqlDataReader myReader = myCmd.ExecuteReader();


        while(myReader.Read())
        {
            Response.Write(myReader[0] + " / ");
            Response.Write(myReader[1] + " / ");
            Response.Write(myReader[2] + " / ");
            Response.Write(myReader[3] + " <br>");

      
        }

        myReader.Close();
        myConn.Close();

    }
}