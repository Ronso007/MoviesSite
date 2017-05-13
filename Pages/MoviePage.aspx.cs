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
    string[] actors;

    protected void Page_Load(object sender, EventArgs e)
    {
        movieName = Request.QueryString["getMovieName"].ToString(); //קבלת קוד המשחק דרך GET 
        if (!Page.IsPostBack)
        {
            MoviesService movieService = new MoviesService();
            ActorsService actorService = new ActorsService();

            int id = movieService.GetIDbyName(movieName);
            actors = actorService.ActorsInMovie(id);
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
        Actors.Text = "";
        for (int i = 0; i < actors.Length; i++)
        {
            if (i != actors.Length - 1)
                Actors.Text += actors[i] + ", ";
            else
                Actors.Text += actors[i];
        }
    }
}