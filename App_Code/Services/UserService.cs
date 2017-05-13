using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserService
/// </summary>
public class UserService
{
    protected OleDbConnection myConn;
    OleDbParameter objParam;

    public UserService()
    {
        myConn = new OleDbConnection(Connect.getConnectionString());
    }

    public void InserUser(UserDetails user)
    {
        string Username = user.Username;
        string Name = user.Name;
        string Email = user.Email;
        string Password = user.Password;
        DateTime Date = user.Birthday;

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

    public UserDetails GetUser(string username)
    {
        UserDetails user = new UserDetails();
        OleDbCommand myCmd = new OleDbCommand("GetUserByUsername", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@username", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = username;

        try
        {
            myConn.Open();
            OleDbDataReader DataReader = myCmd.ExecuteReader();


            user.Username = username;

            if (DataReader.Read())
            {
                user.Name = DataReader["Name"].ToString();
                user.Email = DataReader["Email"].ToString();
                user.Password = DataReader["Password"].ToString();
                user.Birthday = (DateTime)DataReader["Birthdate"];
                user.Admin = (bool)DataReader["Admin"];
            }
            else
            {
                user = null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConn.Close();
        }
        return user;
    }

    public void UpdateUser(UserDetails userD,bool admin)
    {
        string Username = userD.Username;
        string Name = userD.Name;
        string Email = userD.Email;
        string Password = userD.Password;
        DateTime Date = userD.Birthday;

        OleDbCommand myCmd = new OleDbCommand("UpdateUser", myConn);
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

        objParam = myCmd.Parameters.Add("@admin", OleDbType.Boolean);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = admin;

        objParam = myCmd.Parameters.Add("@user", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Username;

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

    public DataSet GetUsers()
    {
        OleDbCommand myCmd = new OleDbCommand("GetAllUsers", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCmd;

        DataSet UsersTable = new DataSet();

        try
        {
            adapter.Fill(UsersTable, "Users");
            UsersTable.Tables["Users"].PrimaryKey = new DataColumn[] { UsersTable.Tables["Users"].Columns["Username"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return UsersTable;
    }

    
}