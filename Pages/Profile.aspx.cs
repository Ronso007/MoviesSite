using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Profile : System.Web.UI.Page
{
    public string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((string)Session["User"] == "none" || Session["Username"] == null)
            Response.Redirect("Home.aspx");
        if (!Page.IsPostBack)
        {
            UserDetails user = new UserDetails();
            UserService userService = new UserService();

            user = userService.GetUser((string)Session["Username"]);
            username.Text = user.Username;
            name.Text = user.Name;
            email.Text = user.Email;
            birthday.Text = user.Birthday.ToString("yyyy-MM-dd");
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        UserDetails user = new UserDetails();
        UserService userService = new UserService();

        user.Username = username.Text;
        user.Name = name.Text;
        user.Email = email.Text;
        user.Birthday = Convert.ToDateTime(birthday.Text);
        if(password.Text != confirm.Text)
        {
            userMsg.Attributes.Add("class", "alert alert-danger");
            msg = "Passwords not Match! ";
        }
        else
        {
            user.Password = password.Text;
            userService.UpdateUser(user, false);
            userMsg.Attributes.Add("class", "alert alert-success");
            msg = "Profile Updated";
        }
    }
}