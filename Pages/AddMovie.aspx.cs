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
        string Genre = genres.SelectedValue;
        string Director = director.Text;
        DateTime ReleaseDate = Convert.ToDateTime(release.Text);
        string actorsList = actors.Text;

        movie.MovieName = MovieName;
        movie.MovieGenre = Genre;
        movie.Director = Director;
        movie.ReleaseDate = ReleaseDate;
        movieService.InsertMovie(movie);

        string[] arrActorString = actorsList.Split(','); //Split Actors By ','
        ActorsDetails[] arrActors = new ActorsDetails[arrActorString.Length];
        for (int i = 0;i<arrActors.Length;i++)
        {
            arrActors[i] = new ActorsDetails(arrActorString[i]);
            arrActors[i].Name.Trim();

            actorService.InsertActor(arrActors[i]); 

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