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
    OleDbParameter objParam;

    protected void Page_Load(object sender, EventArgs e)
    {
    
    }


    protected void submit_Click(object sender, EventArgs e)
    {
        OleDbConnection myConn = new OleDbConnection(connectionString);
        string Name = name.Text;
        string Email = email.Text;
        string Username = username.Text;
        DateTime Date = Convert.ToDateTime(birthday.Text);
        string Password = password.Text;
        string Confirm = confirm.Text;
        //DateTime date = Convert.ToDateTime(Request.Form["birthday"]);

        OleDbCommand myCmd = new OleDbCommand("UserInsInto", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@username", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Username;

        objParam = myCmd.Parameters.Add("@name", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Name;

        objParam = myCmd.Parameters.Add("@email", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Email;

        objParam = myCmd.Parameters.Add("@password", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Password;

        objParam = myCmd.Parameters.Add("@birthday", OleDbType.DBDate);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Date;


        try
        {
            myConn.Open();
            myCmd.ExecuteNonQuery();
            Session["User"] = Name;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConn.Close();
        }

        Session["User"] = Name;
    }
}