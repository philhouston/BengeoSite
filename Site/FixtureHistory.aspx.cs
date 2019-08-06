using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FixtureHistory : Page
{
    private readonly FixtureModel model = new FixtureModel();
    private readonly ClubModel model2 = new ClubModel();
    private string reference;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                // We have a reference from the query string, lets use that
                reference = Request.QueryString["id"];
                HideSelection();
                BindResults();
            }
            else
            {
                ddlClub.DataBind();
                BindResults();
            }
        }
    }

    private void BindResults()
    {
        grid.DataBind();
    }


    private void HideSelection()
    {
        clubPrompt.Visible = false;
        ddlClub.Visible = false;
    }


    protected void FixturesSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = ddlClub.SelectedItem.Value;

        e.Result = model.GetClubHistory(reference);
    }

    protected void clubDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model2.GetClubList();
    }


    protected void ddlClub_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindResults();
    }
}