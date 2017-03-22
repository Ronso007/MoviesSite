using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string navbarRight;
    public string navbarLeft ="";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Session["User"] = "none";
        }
        if((string)Session["User"] == "none")
        {
            navbarRight = "<li><a href='Register.aspx'><span class='glyphicon glyphicon-plus'></span> Register</a></li><li><a href = 'Login.aspx' ><span class='glyphicon glyphicon-log-in'></span> Login</a></li>";
        }
        else
        {
            navbarLeft= "<li><a href='AddMovie.aspx'><span class='glyphicon glyphicon-plus'></span> Add Movie</a></li>";
            if (!(bool)Session["Admin"])
            {
                navbarRight = "<li><a>Hello " + (string)Session["User"] + "!</a></li>";
                navbarRight += "<li><a href='Profile.aspx'><span class='glyphicon glyphicon-user'></span> Profile</a></li>";
                navbarRight += "<li><a href='Logout.aspx' ><span class='glyphicon glyphicon-log-out'></span> Logout</a></li>";


            }
            else
            {
                navbarRight = "<li><a>Hello " + (string)Session["User"] + "!</a></li>";
                navbarRight += "<li><a href='Profile.aspx'><span class='glyphicon glyphicon-user'></span> Profile</a></li>";
                navbarRight += "<li><a href='Controlpanel.aspx'><span class='glyphicon glyphicon-edit'></span> Panel</a></li>";
                navbarRight += "<li><a href='Logout.aspx' ><span class='glyphicon glyphicon-log-out'></span> Logout</a></li>";
            }
                
        }
    }
}
