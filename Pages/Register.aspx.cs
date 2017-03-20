using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


public partial class Pages_Register : System.Web.UI.Page
{
    public string msg ="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if((string)Session["User"] != "none")
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string Name = name.Text;
        string Email = email.Text;
        string Username = username.Text;
        DateTime Date = Convert.ToDateTime(birthday.Text);
        string Password = password.Text;
        string Confirm = confirm.Text;

        if (Password != Confirm)
        {
            userMsg.Attributes.Add("class", "alert alert-danger");
            passwordError.Attributes.Add("class", "input-group has-error");
            confirmError.Attributes.Add("class", "input-group has-error");
            userMsg.Attributes.Add("class", "alert alert-danger");
            msg = "Passwords not Match!";
        }
        else
        {
            userMsg.Attributes.Add("class", "alert alert-success");
            msg = "Success!";
            UserDetails user = new UserDetails();
            user.Name = Name;
            user.Email = Email;
            user.Username = Username;
            user.Birthday = Date;
            user.Password = Password;

            UserService userService = new UserService();
            userService.InserUser(user);

            Session["User"] = Name;
        }
    }
}