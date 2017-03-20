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
        UserDetails user2 = new UserDetails();
        UserService userService = new UserService();


        string Name = name.Text;
        string Email = email.Text;
        string Username = username.Text;
        DateTime Date = Convert.ToDateTime(birthday.Text);
        string Password = password.Text;
        string Confirm = confirm.Text;

        user2 = userService.GetUser(Username);
        if (Password != Confirm || user2 != null)
        {
            userMsg.Attributes.Add("class", "alert alert-danger");
            passwordError.Attributes.Add("class", "input-group has-error");
            confirmError.Attributes.Add("class", "input-group has-error");
            if (Password != Confirm)
                msg = "Passwords not Match! ";
            if(user2 != null)
                msg = "Username already Exist!";
        }
        else
        {
            UserDetails user = new UserDetails();
            userMsg.Attributes.Add("class", "alert alert-success");
            msg = "Success!";
            user.Name = Name;
            user.Email = Email;
            user.Username = Username;
            user.Birthday = Date;
            user.Password = Password;

            userService.InserUser(user);

            Session["User"] = Name;
        }
    }
}