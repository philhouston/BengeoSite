using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CupHistory : Page
{
    private readonly FixtureModel model = new FixtureModel();
    private readonly CupModel model2 = new CupModel();
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
                ddlCup.DataBind();
                BindResults();
            }
        }
    }

    private void BindResults()
    {
        if (ddlCup.SelectedItem != null)
        {
            CupDataInfo cupInfo = model2.GetCupInfo(ddlCup.SelectedValue);
            if (cupInfo != null)
            {
                donationValue.Text = cupInfo.DonatedBy;
                donationDateValue.Text = cupInfo.Date;
            }
        }
        grid.DataBind();
    }


    private void HideSelection()
    {
        cupPrompt.Visible = false;
        ddlCup.Visible = false;
    }


    protected void FixturesSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = ddlCup.SelectedItem.Value;

        e.Result = model.GetCupHistory(reference);
    }

    protected void cupDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model2.GetCupList();
    }


    protected void ddlCup_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindResults();
    }
}