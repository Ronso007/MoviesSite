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

        string MovieName = movieName.Text;
        string Genre = genres.SelectedValue;
        string Director = director.Text;
        DateTime ReleaseDate = Convert.ToDateTime(release.Text);
        string actorsList = actors.Text;

        string[] arrActorString = actorsList.Split(','); //Split Actors By ','
        Actors[] arrActors = new Actors[arrActorString.Length]; 
        
        
        for(int i = 0;i<arrActors.Length;i++)
        {

            arrActors[i] = new Actors(arrActorString[i]);
        }

        movie.MovieName = MovieName;
        movie.MovieGenre = Genre;
        movie.Director = Director;
        movie.ReleaseDate = ReleaseDate;

        movieService.InsertMovie(movie);
        msg = "You Add A Movie";
    }
}