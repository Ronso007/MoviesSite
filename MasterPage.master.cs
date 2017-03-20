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
            navbar = "<a href='Register.aspx'><span class='glyphicon glyphicon-plus'></span> Register</a>";
        }
        else
        {
            navbar = "<a>Hello " + (string)Session["User"] + "!</a>";
        }
    }
}
