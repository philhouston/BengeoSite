using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class PlayerOfTheYear : Page
{
    private XDocument doc;
    private XDocument doc1;
    private FixtureModel model;
    private string reference;
    private bool showSelection = false;

    public bool ShowSelection
    {
        get { return showSelection; }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        doc = SiteCache.FixtureData;
        doc1 = SiteCache.HandicapData;
        model = new FixtureModel();
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
                BindSeasons();
                BindResults();
            }
            else
            {
                BindSeasons();
                BindResults();
            }
        }
    }

    private void HideSelection()
    {
        litSeason.Visible = false;
        cbSeason.Visible = false;
    }

    private void BindSeasons()
    {
        cbSeason.DataBind();
    }

    private void BindResults()
    {
        grid.DataBind();
    }

    protected void cbSeason_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindResults();
    }

    protected void PlayerYearData_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = cbSeason.SelectedItem.Value;

        IScoreCalculator calculator = CalculatorFactory.GetScoreCalculator(reference);


        var events = doc.Element("Fixtures").Elements("Fixture")
                        .Where(ee => (string) ee.Attribute("Season") == reference)
                        .Where(ee => (string) ee.Attribute("PlayerOfTheYear") == "True")
                        .OrderBy(ee => (string) ee.Attribute("Reference"))
                        .Select(ee =>
                                new
                                    {
                                        reference = (string) ee.Attribute("Reference"),
                                        location = (string) ee.Attribute("Location"),
                                        abbrevation = (string) ee.Attribute("Abbreviation")
                                    });


        List<string> evs = events.Select(ee => ee.abbrevation).ToList();


        List<PlayerYearInfo> PlayerOfTheYearTable = doc1.Element("Members").Elements("Member")
                                                        .Select(
                                                            ee =>
                                                            new PlayerYearInfo((string) ee.Attribute("Name"), evs,
                                                                               calculator)).ToList();
        int counter = 0;

        foreach (var ev in events)
        {
            counter++;

            IEnumerable<XElement> results = doc.Element("Fixtures").Elements("Fixture")
                                               .Where(ee => (string) ee.Attribute("Reference") == ev.reference)
                                               .Descendants("Score")
                                               .Where(
                                                   ff =>
                                                   (string)
                                                   ff.Ancestors("Result").SingleOrDefault().Attribute("PlayerOfTheYear") ==
                                                   "True")
                                               .Select(ee => ee);

            foreach (XElement score in results)
            {
                PlayerYearInfo player = PlayerOfTheYearTable.Where(ee => ee.Player == (string) score.Attribute("Name"))
                                                            .Select(ee => ee)
                                                            .SingleOrDefault();

                if (player != null)
                {
                    player.RecordEvent(ev.abbrevation, (int) score.Attribute("Position"));
                }
            }
        }


        e.Result = PlayerOfTheYearTable.Where(ee => ee.Total > 0).OrderByDescending(ee => ee.Total).Select(ee => ee);
    }


    protected void SeasonDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        IEnumerable<string> seasons = (from ee in doc.Elements("Fixtures").Elements("Fixture")
                                       where ee.Element("Results") != null
                                       orderby ee.Attribute("Season").Value descending
                                       select ee.Attribute("Season").Value).Distinct();

        e.Result = seasons;
    }
}