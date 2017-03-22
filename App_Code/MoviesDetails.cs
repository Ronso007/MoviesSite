using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MoviesDetails
/// </summary>
public class MoviesDetails
{
    private int movieID;
    private string movieName;
    private string movieGenre;
    private string director;
    private DateTime releaseDate;

    public int MovieID
    {
        get
        {
            return movieID;
        }

        set
        {
            movieID = value;
        }
    }

    public string MovieName
    {
        get
        {
            return movieName;
        }

        set
        {
            movieName = value;
        }
    }

    public string MovieGenre
    {
        get
        {
            return movieGenre;
        }

        set
        {
            movieGenre = value;
        }
    }

    public string Director
    {
        get
        {
            return director;
        }

        set
        {
            director = value;
        }
    }

    public DateTime ReleaseDate
    {
        get
        {
            return releaseDate;
        }

        set
        {
            releaseDate = value;
        }
    }
}