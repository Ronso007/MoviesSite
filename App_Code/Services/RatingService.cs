using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for RatingService
/// </summary>
public class RatingService
{
    protected OleDbConnection myConn;
    OleDbParameter objParam;
    public RatingService()
    {
        myConn = new OleDbConnection(Connect.getConnectionString());
    }

    public void InsertUserRateMovie(string username, int movieID, int rating)
    {
        OleDbCommand myCmd = new OleDbCommand("InsertRatingOfUser", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@username", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = username;

        objParam = myCmd.Parameters.Add("@movieID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = movieID;

        objParam = myCmd.Parameters.Add("@rating", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = rating;

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

    public DataSet GetAllRating()
    {
        OleDbCommand myCmd = new OleDbCommand("GetAllRating", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCmd;

        DataSet RatingTable = new DataSet();

        try
        {
            adapter.Fill(RatingTable, "Rating");
            RatingTable.Tables["Rating"].PrimaryKey = new DataColumn[] { RatingTable.Tables["Rating"].Columns["Username"] };
            RatingTable.Tables["Rating"].PrimaryKey = new DataColumn[] { RatingTable.Tables["Rating"].Columns["MovieID"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return RatingTable;
    }

    public bool DidRateAlready(string username,int movieID)
    {
        OleDbCommand myCmd = new OleDbCommand("GetRatingOfUser", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@username", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = username;

        objParam = myCmd.Parameters.Add("@movieID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = movieID;


        try
        {
            myConn.Open();
            OleDbDataReader DataReader = myCmd.ExecuteReader();
            string userName = (string)DataReader["Username"].ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConn.Close();
        }
        return username != null;

    }
}