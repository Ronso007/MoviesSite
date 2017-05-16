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
    int movieID;
    public string RatingMsg = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            movieName = Request.QueryString["getMovieName"].ToString(); //קבלת קוד המשחק דרך GET 
        }
        catch
        {
            Response.Redirect("Home.aspx");
        }
        if (!Page.IsPostBack)
        {
            MoviesService movieService = new MoviesService();
            ActorsService actorService = new ActorsService();

            movieID = movieService.GetIDbyName(movieName);
            actors = actorService.ActorsInMovie(movieID);
            PopulatePage(movieService.GetMovieByID(movieID));
        }
        PopulateRating();

    }

    private void PopulateRating()
    {
        RatingService ratingService = new RatingService();
        if ((string)Session["Username"] != null)
        {
            if (ratingService.DidRateAlready((string)Session["Username"], movieID) == false)
                rating.Visible = true;
            else
            {
                rating.Visible = false;
                RatingMsg = "You Voted Already!";
            }
        }
        else
        {
            rating.Visible = false;
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

    protected void rating1_Click(object sender, EventArgs e)
    {
        MoviesService movieService = new MoviesService();

        RatingService ratingService = new RatingService();
        ratingService.InsertUserRateMovie((string)Session["Username"], movieService.GetIDbyName(movieName), 1);
        rating.Visible = false;
    }

    protected void rating2_Click(object sender, EventArgs e)
    {
        MoviesService movieService = new MoviesService();

        RatingService ratingService = new RatingService();
        ratingService.InsertUserRateMovie((string)Session["Username"], movieService.GetIDbyName(movieName), 2);
        rating.Visible = false;
    }

    protected void rating3_Click(object sender, EventArgs e)
    {
        MoviesService movieService = new MoviesService();

        RatingService ratingService = new RatingService();
        ratingService.InsertUserRateMovie((string)Session["Username"], movieService.GetIDbyName(movieName), 3);
        rating.Visible = false;
    }

    protected void rating4_Click(object sender, EventArgs e)
    {
        MoviesService movieService = new MoviesService();

        RatingService ratingService = new RatingService();
        ratingService.InsertUserRateMovie((string)Session["Username"], movieService.GetIDbyName(movieName), 4);
        rating.Visible = false;
    }

    protected void rating5_Click(object sender, EventArgs e)
    {
        MoviesService movieService = new MoviesService();

        RatingService ratingService = new RatingService();
        ratingService.InsertUserRateMovie((string)Session["Username"], movieService.GetIDbyName(movieName), 5);
        rating.Visible = false;
    }
}