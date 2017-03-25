using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        MoviesService movieService = new MoviesService();
        return movieService.GetAllMovies();
    }
    private void PopulateGrid()
    {
        GridViewMovies.DataSource = GetData();
        GridViewMovies.DataBind();
    }
}