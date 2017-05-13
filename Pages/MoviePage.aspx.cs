using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MoviePage : System.Web.UI.Page
{
    string movieName;
    public string VideoSource;

    protected void Page_Load(object sender, EventArgs e)
    {
        movieName = Request.QueryString["getMovieName"].ToString(); //קבלת קוד המשחק דרך GET 
        if (!Page.IsPostBack)
        {
            MoviesService movieService = new MoviesService();
            int id = movieService.GetIDbyName(movieName);
            
            PopulatePage(movieService.GetMovieByID(id));

        }

    }
    private void PopulatePage(MoviesDetails movie)
    {
        MovieName.Text = movie.MovieName;
        movieImage.ImageUrl = movie.ImgURL;
        Director.Text = movie.Director;
        Genre.Text = movie.MovieGenre;
        Duration.Text = movie.Duration.ToString();
        Description.Text = movie.Description;
        VideoSource = movie.TrailerURL;
    }
}