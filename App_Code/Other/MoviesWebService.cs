using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
/// <summary>
/// Summary description for MoviesWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MoviesWebService : System.Web.Services.WebService
{

    public MoviesWebService()
    {

    }

    [WebMethod]
    public DataSet GetAllMovies()
    {
        MoviesService mov = new MoviesService();
        return mov.GetAllMovies();
    }

    [WebMethod]
    public void InsertMovie(MoviesDetails movie)
    {
        MoviesService mov = new MoviesService();
        mov.InsertMovie(movie);
    }
    [WebMethod]
    public int GetIDbyName(string name)
    {
        MoviesService mov = new MoviesService();
        return mov.GetIDbyName(name);
    }

    [WebMethod]
    public MoviesDetails GetMovieByID(int id)
    {
        MoviesService mov = new MoviesService();
        return mov.GetMovieByID(id);
    }

    [WebMethod]
    public void UpdateMovieRating(int rating, int movieID, int addUser)
    {
        MoviesService mov = new MoviesService();
        mov.UpdateMovieRating(rating,movieID,addUser);
    }

    [WebMethod]
    public DataSet GetAllMoviesFiltered(int Expression, int Rating)
    {
        MoviesService mov = new MoviesService();
        return mov.GetAllMoviesFiltered(Expression,Rating);
    }
}
