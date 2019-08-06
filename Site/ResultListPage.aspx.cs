using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class ResultListPage : Page
{
    private XDocument doc;
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
                BindDivision();
                BindResults();
            }
            else
            {
                BindSeasons();
                BindFixtures();
                BindDivision();
                BindResults();
            }
        }
    }

    private void HideSelection()
    {
        litSeason.Visible = false;
        cbSeason.Visible = false;
        litFixture.Visible = false;
        cbFixture.Visible = false;
    }

    private void BindSeasons()
    {
        cbSeason.DataBind();
    }

    private void BindFixtures()
    {
        cbFixture.DataBind();
    }

    private void BindDivision()
    {
        cbDivision.DataBind();
        cbDivision.SelectedIndex = 0;
    }

    private void BindResults()
    {
        grid.DataBind();
    }

    protected void cbSeason_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFixtures();
        BindDivision();
        BindResults();
    }

    protected void cbFixture_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDivision();
        BindResults();
    }

    protected void cbDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindResults();
    }

    protected void ResultsData_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = cbFixture.SelectedItem.Value;

        string category = cbDivision.SelectedItem.Value;

        IEnumerable<XElement> results = doc.Element("Fixtures").Elements("Fixture")
                                           .Where(ee => ee.Attribute("Reference").Value == reference)
                                           .Select(ee => ee.Element("Results"));


        IEnumerable<XElement> scores = results.Elements("Result")
                                              .Where(ee => ee.Attribute("Cup").Value == category)
                                              .Select(ee => ee.Element("Scores"));


        var orderedList = scores.Elements("Score")
                                .OrderBy(ee => int.Parse(ee.Attribute("Position").Value))
                                .Select(ee => new
                                    {
                                        position = ee.Attribute("Position").Value,
                                        name = ee.Attribute("Name").Value,
                                        points = ee.Attribute("Points").Value
                                    });


        e.Result = orderedList;
    }

    protected void DivisionDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = cbFixture.SelectedItem.Value;

        IEnumerable<XElement> results = doc.Element("Fixtures").Elements("Fixture")
                                           .Where(ee => ee.Attribute("Reference").Value == reference)
                                           .Select(ee => ee.Element("Results"));

        IEnumerable<string> scores = results.Elements("Result").Attributes("Cup")
                                            .Select(ee => ee.Value)
                                            .Distinct();

        e.Result = scores;
    }

    protected void FixtureDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (cbSeason.SelectedItem == null)
            cbSeason.SelectedIndex = 0;

        e.Result = model.GetlistOfFixturesWithResultsForSelecting(cbSeason.SelectedItem.Value);
    }

    protected void SeasonDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        IEnumerable<string> seasons = doc.Elements("Fixtures").Elements("Fixture").Attributes("Season")
                                         .Where(ee => ee.Parent.Element("Results") != null)
                                         .OrderByDescending(ee => ee.Value)
                                         .Select(ee => ee.Value)
                                         .Distinct();

        e.Result = seasons;
    }
}