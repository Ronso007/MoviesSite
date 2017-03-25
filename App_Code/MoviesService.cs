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

    public int GetIDbyName(string name)
    {
        int id;
        OleDbCommand myCmd = new OleDbCommand("GetMovieByName", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@movieName", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = name;

        try
        {
            myConn.Open();
            OleDbDataReader DataReader = myCmd.ExecuteReader();
            if (DataReader.Read())
            {
                id = (int)DataReader["MovieID"];
            }
            else
            {
                id = -1;
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
        return id;

    }

    public MoviesDetails GetMovieByID(int id)
    {
        MoviesDetails movie = new MoviesDetails();

        OleDbCommand myCmd = new OleDbCommand("GetMovieByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        objParam = myCmd.Parameters.Add("@movieID", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = id;

        try
        {
            myConn.Open();
            OleDbDataReader DataReader = myCmd.ExecuteReader();

            
            if (DataReader.Read())
            {
                movie.MovieName = (string)DataReader["MovieName"];
                movie.MovieGenre = (string)DataReader["MovieGenre"];
                movie.Director = (string)DataReader["Director"];
                movie.ReleaseDate = (DateTime)DataReader["ReleaseDate"];

            }
            else
            {
                movie = null;
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
        return movie;

    }

    public DataSet GetAllMovies()
    {
        OleDbCommand myCmd = new OleDbCommand("GetAllMovies", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCmd;

        DataSet MoviesTable = new DataSet();

        try
        {
            adapter.Fill(MoviesTable, "Movies");
            MoviesTable.Tables["Movies"].PrimaryKey = new DataColumn[] { MoviesTable.Tables["Movies"].Columns["MovieID"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return MoviesTable;
    }

}