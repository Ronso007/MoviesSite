using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddMovie : System.Web.UI.Page
{
    public string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["User"] == null)
            Response.Redirect("Home.aspx");
        if ((string)Session["User"] == "none")
            Response.Redirect("Home.aspx");
        

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        MoviesDetails movie = new MoviesDetails();
        MoviesService movieService = new MoviesService();

        ActorsService actorService = new ActorsService();

        string MovieName = movieName.Text;
        string Director = director.Text;
        string Genre = genres.SelectedValue;
        string Description = description.Text;
        string actorsList = actors.Text;
        string Duration = duration.Text;
        string Image = image.Text;
        string Trailer = trailer.Text;

        movie.MovieName = MovieName;
        movie.Director = Director;
        movie.MovieGenre = Genre;
        movie.Description = Description;
        movie.Duration = Duration;
        movie.ImgURL = Image;
        movie.TrailerURL = Trailer;

        movieService.InsertMovie(movie);

        string[] arrActorString = actorsList.Split(','); //Split Actors By ','
        ActorsDetails[] arrActors = new ActorsDetails[arrActorString.Length];
        for (int i = 0;i<arrActors.Length;i++)
        {
            arrActors[i] = new ActorsDetails(arrActorString[i]);
            arrActors[i].Name.Trim();

            if (actorService.GetIDbyName(arrActors[i].Name) != -1)
            {
                actorService.InsertActor(arrActors[i]);
            }
        }

        int movieID = movieService.GetIDbyName(movie.MovieName);
        int firstActorID = actorService.GetIDbyName(arrActors[0].Name);

        for(int i = 0;i<arrActors.Length;i++)
        {
            actorService.InsertActorInMovie(movieID, firstActorID + i);
        }
        userMsg.Attributes.Add("class", "alert alert-success");
        msg = "You Added A Movie";
    }
}