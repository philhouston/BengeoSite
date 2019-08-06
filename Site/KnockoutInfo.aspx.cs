using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DevExpress.Web.ASPxTabControl;

public partial class KnockoutInfo : Page
{
    private XDocument doc;
    private KnockoutModel model;

    protected void Page_Init(object sender, EventArgs e)
    {
        String id = "Singles";

        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"];
        }

        switch (id)
        {
            case "Doubles":
                {
                    doc = SiteCache.DoubleKnockoutData;
                    model = new KnockoutModel(doc);
                    ScreenLabel.Src = "images/design/label_doublesKnockout.png";
                    break;
                }
            default:
                {
                    doc = SiteCache.SinglesKnockoutData;
                    model = new KnockoutModel(doc);
                    break;
                }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYears();
            UpdateTableHeaders();
            BindGames();
        }
    }


    private void UpdateTableHeaders()
    {
        string season = ddlYear.SelectedValue;
        IEnumerable<RoundInfo> data1 = model.GetRounds(season);

        foreach (RoundInfo round in data1)
        {
            var tab = new Tab(String.Format("Rd {0}", round.No.ToString()));

            tabs.Tabs.Add(tab);
        }
    }


    private void BindYears()
    {
        ddlYear.DataBind();
    }

    private void BindGames()
    {
        string season = ddlYear.SelectedValue;
        IEnumerable<RoundInfo> data1 = model.GetRounds(season);
        int round = tabs.ActiveTabIndex + 1;

        lblCutoff.Text = data1.Where(p => p.No == round).Select(p => p.Cutoff.ToShortDateString()).FirstOrDefault();

        if (grid != null)
        {
            grid.DataBind();
        }
    }

    protected void GamesSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        int round = tabs.ActiveTabIndex + 1;

        string season = ddlYear.SelectedValue;

        IEnumerable<GameInfo> data3 = model.GetGames(season, round);

        var data4 = data3.Select(p => new
            {
                p.GameNo,
                p.RoundNo,
                HomePlayer1 = p.Home.Player1,
                HomePlayer2 = p.Home.Player2,
                AwayPlayer1 = p.Away.Player1,
                AwayPlayer2 = p.Away.Player2,
                WinnerPlayer1 = p.Winner.Player1,
                WinnerPlayer2 = p.Winner.Player2,
                p.Score
            });

        e.Result = data4;
    }


    protected void yearDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model.GetListOfSeasons();
    }


    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGames();
    }

    protected void tabs_ActiveTabChanged(object sender, EventArgs e)
    {
        BindGames();
    }
}