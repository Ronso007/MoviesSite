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

public partial class Pages_ReviewsContolPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateGrid();
        }
    }

    private DataSet GetData()
    {
        DataSet reviews = new DataSet();

        RatingService ratingService = new RatingService();
        reviews = ratingService.GetAllRating();
        return reviews;
    }
    private void PopulateGrid()
    {
        GridViewReviews.DataSource = GetData();
        GridViewReviews.DataBind();
    }



    protected void GridViewReviews_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewReviews.EditIndex = e.NewEditIndex;
        PopulateGrid();
    }

    protected void GridViewReviews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewReviews.EditIndex = -1;
        PopulateGrid();
    }


    protected void GridViewReviews_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        RatingService ratingService = new RatingService();
        localMoviesWebService.MoviesWebService moviesWeb = new localMoviesWebService.MoviesWebService();

        try
        {
            string username = GridViewReviews.Rows[e.RowIndex].Cells[0].Text;
            int movieID = moviesWeb.GetIDbyName(GridViewReviews.Rows[e.RowIndex].Cells[1].Text);
            int rating = int.Parse(GridViewReviews.Rows[e.RowIndex].Cells[3].Text);
            string review = ((TextBox)(GridViewReviews.Rows[e.RowIndex].Cells[4].Controls[0])).Text;


            ratingService.UpdateRating(username, movieID, rating, review);

            GridViewReviews.EditIndex = -1;
            PopulateGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
}