using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
public partial class Pages_MoviePage : System.Web.UI.Page
{
    string movieName;
    public string VideoSource;
    string[] actors;
    int movieID;
    public string RatingMsg = "";
    public string Reviews = "";
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
            localMoviesWebService.MoviesWebService moviesWeb = new localMoviesWebService.MoviesWebService();

            movieID = moviesWeb.GetIDbyName(movieName);
            actors = moviesWeb.ActorsInMovie(movieID);
            PopulatePage(moviesWeb.GetMovieByID(movieID));
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

    private void PopulatePage(localMoviesWebService.MoviesDetails movie)
    {
        MovieName.Text = movie.MovieName;
        movieImage.ImageUrl = movie.ImgURL;
        Director.Text = movie.Director;
        Genre.Text = movie.MovieGenre;
        Duration.Text = movie.Duration.ToString();
        Description.Text = movie.Description;
        VideoSource = movie.TrailerURL;
        Actors.Text = "";

        if (movie.NumberOfUsers != 0)
        {

            CalcRating.Text = (movie.TotalRating / (double)movie.NumberOfUsers).ToString();
        }
        else
        {
            CalcRating.Text = "0";
        }

        for (int i = 0; i < actors.Length; i++)
        {
            if (i != actors.Length - 1)
                Actors.Text += actors[i] + ", ";
            else
                Actors.Text += actors[i];
        }

        DataSet reviews = new DataSet();
        RatingService ratingService = new RatingService();
        reviews = ratingService.GetAllRatingOfMovie(movieID);

        Reviews += "<tr>";
        Reviews += "<th>User</th>";
        Reviews += "<th>Date</th>";
        Reviews += "<th>Rating</th>";
        Reviews += "<th>Review</th>";

        Reviews += "</tr>";

        for (int i = 0; i < reviews.Tables["Rating"].Rows.Count; i++)
        {
            Reviews += "<tr>";
            Reviews += "<td>" + reviews.Tables["Rating"].Rows[i][0].ToString() + "</td>";
            Reviews += "<td>" + reviews.Tables[0].Rows[i][3].ToString() + "</td>";
            Reviews += "<td>" + reviews.Tables[0].Rows[i][2].ToString() + "</td>";
            Reviews += "<td>" + reviews.Tables[0].Rows[i][4].ToString() + "</td>";

            Reviews += "</tr>";
        }
    }

    protected void rating1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            localMoviesWebService.MoviesWebService moviesWeb = new localMoviesWebService.MoviesWebService();
            RatingService ratingService = new RatingService();
            int id = moviesWeb.GetIDbyName(movieName);
            ratingService.InsertUserRateMovie((string)Session["Username"], id, 1, DateTime.Now, review.Text);

            if (moviesWeb.GetMovieByID(id).NumberOfUsers == -1)
            {
                moviesWeb.UpdateMovieRating(1, id, 2);
            }
            else
                moviesWeb.UpdateMovieRating(1, id, 1);

            rating.Visible = false;
        }
    }

    protected void rating2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            localMoviesWebService.MoviesWebService moviesWeb = new localMoviesWebService.MoviesWebService();
            RatingService ratingService = new RatingService();
            int id = moviesWeb.GetIDbyName(movieName);
            ratingService.InsertUserRateMovie((string)Session["Username"], id, 2, DateTime.Now, review.Text);

            if (moviesWeb.GetMovieByID(id).NumberOfUsers == -1)
            {
                moviesWeb.UpdateMovieRating(2, id, 2);
            }
            else
                moviesWeb.UpdateMovieRating(2, id, 1);


            rating.Visible = false;
        }
    }

    protected void rating3_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            localMoviesWebService.MoviesWebService moviesWeb = new localMoviesWebService.MoviesWebService();
            RatingService ratingService = new RatingService();
            int id = moviesWeb.GetIDbyName(movieName);
            ratingService.InsertUserRateMovie((string)Session["Username"], id, 3, DateTime.Now, review.Text);
            if (moviesWeb.GetMovieByID(id).NumberOfUsers == -1)
            {
                moviesWeb.UpdateMovieRating(3, id, 2);
            }
            else
                moviesWeb.UpdateMovieRating(3, id, 1);

            rating.Visible = false;
        }
    }

    protected void rating4_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            localMoviesWebService.MoviesWebService moviesWeb = new localMoviesWebService.MoviesWebService();
            RatingService ratingService = new RatingService();
            int id = moviesWeb.GetIDbyName(movieName);
            ratingService.InsertUserRateMovie((string)Session["Username"], id, 4, DateTime.Now, review.Text);
            if (moviesWeb.GetMovieByID(id).NumberOfUsers == -1)
            {
                moviesWeb.UpdateMovieRating(4, id, 2);
            }
            else
                moviesWeb.UpdateMovieRating(4, id, 1);

            rating.Visible = false;
        }
    }

    protected void rating5_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            localMoviesWebService.MoviesWebService moviesWeb = new localMoviesWebService.MoviesWebService();
            RatingService ratingService = new RatingService();
            int id = moviesWeb.GetIDbyName(movieName);
            ratingService.InsertUserRateMovie((string)Session["Username"], id, 5, DateTime.Now, review.Text);
            if (moviesWeb.GetMovieByID(id).NumberOfUsers == -1)
            {
                moviesWeb.UpdateMovieRating(5, id, 2);
            }
            else
                moviesWeb.UpdateMovieRating(5, id, 1);

            rating.Visible = false;
        }
    }
}