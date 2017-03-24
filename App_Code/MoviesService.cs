using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;


public class MoviesService
{
    protected OleDbConnection myConn;
    OleDbParameter objParam;

    public MoviesService()
    {
        myConn = new OleDbConnection(Connect.getConnectionString());
    }

    public void InsertMovie(MoviesDetails movie)
    {
        string Name = movie.MovieName;
        string Genre = movie.MovieGenre;
        string Director = movie.Director;
        DateTime ReleaseDate = movie.ReleaseDate;

        OleDbCommand myCmd = new OleDbCommand("MovieInsInto", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@movieName", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Name;

        objParam = myCmd.Parameters.Add("@movieGenre", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Genre;

        objParam = myCmd.Parameters.Add("@director", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = Director;

        objParam = myCmd.Parameters.Add("@birthday", OleDbType.DBDate);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = ReleaseDate;


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