﻿using System;
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
        OleDbCommand myCmd = new OleDbCommand("GetUserByID", myConn);
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

}