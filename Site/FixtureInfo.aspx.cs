using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FixtureInfo : Page
{
    private readonly FixtureModel model = new FixtureModel();
    private string reference;


    protected void cbSeason_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFixtures();
    }

    protected void cbFixture_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindResults();
    }


    protected void SeasonDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model.GetListOfSeasons();
    }

    protected void FixtureDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model.GetListOfFixturesForSelecting(cbSeason.SelectedItem.Value);
    }

    protected void FixtureInfoDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        IEnumerable<FixtureListInfo> results;

        if (reference == null)
            reference = cbFixture.SelectedItem.Value;

        results = model.GetFixtureInfoDetails(reference);

        ClubInfoLink.HRef = "clubinfo.aspx?id=" + (from ee in results
                                                          select ee.Location).SingleOrDefault();


        e.Result = results;
    }

    private void BindSeasons()
    {
        cbSeason.DataBind();
    }

    private void BindFixtures()
    {
        cbFixture.DataBind();
    }

    private void BindResults()
    {
        grid.DataBind();
    }

    private void HideSelection()
    {
        litSeason.Visible = false;
        cbSeason.Visible = false;
        litFixture.Visible = false;
        cbFixture.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            // We have a reference from the query string, lets use that
            reference = Request.QueryString["id"];
            HideSelection();
        }

        if (!IsPostBack)
        {
            if (reference != null)
            {
                BindResults();
            }
            else
            {
                BindSeasons();
                BindFixtures();
                BindResults();
            }
        }
    }
}