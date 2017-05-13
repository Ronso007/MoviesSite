using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;


public partial class Pages_Movies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            PopulateGrid();
        }
    }
    private DataSet GetData()
    {
        DataSet Movies = new DataSet();

        MoviesServiceReference.MoviesWebServiceSoap test = new MoviesServiceReference.MoviesWebServiceSoapClient();
        return test.GetAllMovies();
    }
    private void PopulateGrid()
    {
        GridViewMovies.DataSource = GetData();
        GridViewMovies.DataBind();
    }

    protected void GridViewMovies_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            Response.Redirect("MoviePage.aspx?getMovieName=" + ((Label)(e.Item.FindControl("movieName"))).Text);
        }
    }
}