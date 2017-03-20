using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


public partial class Pages_Register : System.Web.UI.Page
{
    string connectionString = Connect.getConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {
    
    }


    protected void submit_Click(object sender, EventArgs e)
    {
        OleDbConnection myConn = new OleDbConnection(connectionString);
        string Name = name.Text;
        string Email = email.Text;
        string Username = username.Text;
        string Password = password.Text;
        string Confirm = confirm.Text;
        DateTime date = Convert.ToDateTime(Request.Form["birthday"]);

        string sql = "INSERT INTO Users(Username,Name,Email,Password,Birthdate) VALUES('" + Username + "','" + Name + "','" + Email + "','" + Password + "'," + date + ")";
        OleDbCommand myCmd = new OleDbCommand(sql, myConn);
        
        try
        {
            myConn.Open();
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConn.Close();
        }



    }
}