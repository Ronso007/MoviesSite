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

    public void InsertUserRateMovie(string username, int movieID, int rating,DateTime date,string review)
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

        objParam = myCmd.Parameters.Add("@reviewDate", OleDbType.Date);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = date;

        objParam = myCmd.Parameters.Add("@review", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = review;

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
           // RatingTable.Tables["Rating"].PrimaryKey = new DataColumn[] { RatingTable.Tables["Rating"].Columns["Username"] };
           // RatingTable.Tables["Rating"].PrimaryKey = new DataColumn[] { RatingTable.Tables["Rating"].Columns["MovieID"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return RatingTable;
    }

    public bool DidRateAlready(string username,int movieID)
    {
        bool Found;
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
            Found = DataReader.HasRows;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConn.Close();
        }
        return Found;
    }

    public DataSet GetAllReviewsOfUser(string username)
    {
        OleDbCommand myCmd = new OleDbCommand("GetAllReviewsOfUser", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@username", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = username;

        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCmd;

        DataSet RatingTable = new DataSet();

        try
        {
            adapter.Fill(RatingTable, "Rating");
            RatingTable.Tables["Rating"].PrimaryKey = new DataColumn[] { RatingTable.Tables["Rating"].Columns["MovieName"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConn.Close();
        }
        return RatingTable;
    }

    public void UpdateRating(string username,int movieID,int Rating,string Review )
    {
        OleDbCommand myCmd = new OleDbCommand("UpdateRatingRow", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@rating", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Rating;

        objParam = myCmd.Parameters.Add("@review", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Review;

        objParam = myCmd.Parameters.Add("@username", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = username;

        objParam = myCmd.Parameters.Add("@movieID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = movieID;
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

    public DataSet GetAllRatingOfMovie(int movieID)
    {
        OleDbCommand myCmd = new OleDbCommand("GetAllRatingOfMovie", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@movieID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = movieID;
        
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCmd;

        DataSet RatingTable = new DataSet();

        try
        {
            adapter.Fill(RatingTable, "Rating");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return RatingTable;
    }

    public int GetSpecificRating(string username,int movieID)
    {
        OleDbCommand myCmd = new OleDbCommand("GetSpecificRating", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@username", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = username;

        objParam = myCmd.Parameters.Add("@movieID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = movieID;

        int rating;
        try
        {
            myConn.Open();
            OleDbDataReader DataReader = myCmd.ExecuteReader();


            if (DataReader.Read())
            {
                rating = (int)DataReader["Rating"];
            }
            else
            {
                rating = -1;
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
        return rating;

    }

}