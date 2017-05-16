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

public partial class Pages_UserReviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateGrid();
        }
    }

    private void PopulateGrid()
    {
        RatingService ratingService = new RatingService();
        DataSet reviews = ratingService.GetAllReviewsOfUser((string)Session["Username"]);

        GridViewReviews.DataSource = reviews;
        GridViewReviews.DataBind();
    }
}