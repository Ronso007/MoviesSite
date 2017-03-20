using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Login : System.Web.UI.Page
{
    public string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if((string)Session["User"] != "none")
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        UserDetails user = new UserDetails();
        UserService userService = new UserService();

        string Username = username.Text;
        string Password = password.Text;

        user = userService.GetUser(Username);

        if(user.Password == Password)
        {
            userMsg.Attributes.Add("class", "alert alert-success");
            msg = "Success!";
            Session["User"] = user.Name;
        }
        else //Wrong Password
        {
            userMsg.Attributes.Add("class", "alert alert-danger");
            msg = "Wrong Username or Password! ";

        }
    }
}