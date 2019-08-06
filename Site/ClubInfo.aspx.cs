using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClubInfo : Page
{
    private readonly ClubModel model = new ClubModel();
    private string reference;


    protected void Page_Init(object sender, EventArgs e)
    {
    }

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
                BindClubs();
                BindResults();
            }
        }
    }

    private void HideSelection()
    {
        litClub.Visible = false;
        cbClub.Visible = false;
    }

    private void BindClubs()
    {
        cbClub.DataBind();
    }

    private void BindResults()
    {
        grid.PageIndex = 0;
        grid.DataBind();
    }

    protected void clubSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = cbClub.SelectedItem.Value;

        IEnumerable<ClubDataInfo> results = model.GetClubInfo(reference);

        lnkHistory.HRef = "fixturehistory.aspx?id=" + (from ee in results
                                                              select ee.Reference).SingleOrDefault();

        //lnkHistory.NavigateUrl = "fixturehistory.aspx?id=" + (from ee in results
        //                                                      select ee.Reference).SingleOrDefault();


        e.Result = results;
    }

    protected void cbClub_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindResults();
    }

    protected void ClubListDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model.GetClubList();
    }

    protected void DirectionDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = cbClub.SelectedItem.Value;

        e.Result = model.GetDirections(reference);
    }
}