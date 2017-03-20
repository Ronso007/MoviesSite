using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string navbar;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Session["User"] = "none";
        }
        if((string)Session["User"] == "none")
        {
            navbar = "<li><a href='Register.aspx'><span class='glyphicon glyphicon-plus'></span> Register</a></li><li><a href = 'Login.aspx' ><span class='glyphicon glyphicon-log-in'></span> Login</a></li>";
        }
        else
        {
            navbar = "<li><a>Hello " + (string)Session["User"] + "!</a></li><li><a href='Logout.aspx'><span class='glyphicon glyphicon-log-out'></span> Logout</a></li>";
        }
    }
}
