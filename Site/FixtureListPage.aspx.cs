using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FixtueListPage : Page
{
    private readonly FixtureModel model = new FixtureModel();

    private void BindYears()
    {
        ddlYear.DataBind();
    }

    private void BindFixtures()
    {
        grid.DataBind();
    }

    protected void FixturesSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model.GetListOfFixturesForSeason(ddlYear.Text);
    }

    protected void yearDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model.GetListOfSeasons(chkFuture.Checked);
    }


    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFixtures();
    }

    protected void chkFuture_CheckedChanged(object sender, EventArgs e)
    {
        BindYears();
        BindFixtures();
    }
}