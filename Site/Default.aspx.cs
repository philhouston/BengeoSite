using System;
using System.Linq;
using System.Web.UI;
using System.Xml.Linq;

public partial class _Default : Page
{
    private XDocument doc;
    private XDocument doc2;

    protected void Page_Init(object sender, EventArgs e)
    {
        doc = SiteCache.FixtureData;
        doc2 = SiteCache.NewslettersData;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DetermineNextFixture();
            DetermineLastResults();
            DetermineLastNewsLetter();
        }
    }

    protected void butJoin_Click(object sender, EventArgs e)
    {
        // Redirect to a page providing additional information on how to become a member of the society.
    }

    private void DetermineLastResults()
    {
        //.Where(e => e.Elements("Results") != null)


        try
        {
            //var fixtureReference = doc.Elements("Fixtures")
            //                        .Elements("Fixture")
            //                            .Where(e => (DateTime.Parse(e.Attribute("Date").Value) < DateTime.Now))
            //                                .Where( e => e.Descendants("Results").Count() > 0)
            //                                    .OrderByDescending(e => DateTime.Parse(e.Attribute("Date").Value))
            //                                        .Select(e => new { reference = e.Attribute("Reference").Value }).Take(1).SingleOrDefault();

            var fixtureReference = doc.Elements("Fixtures")
                                      .Elements("Fixture")
                                      .Where(e => (DateTime.Parse(e.Attribute("Date").Value) < DateTime.Now))
                                      .Where(e => e.Descendants("Results").Any())
                                      .OrderByDescending(e => DateTime.Parse(e.Attribute("Date").Value))
                                      .Select(e => new {reference = e.Attribute("Reference").Value}).FirstOrDefault();


            var lastresults = doc.Elements("Fixtures")
                                 .Elements("Fixture")
                                 .Where(e => e.Attribute("Reference").Value == fixtureReference.reference)
                                 .Select(e => new
                                     {
                                         date = e.Attribute("Date").Value,
                                         location = e.Attribute("Location").Value,
                                         holecount = e.Attribute("HoleCount").Value
                                     }).Single();

            litLastResults.Text = string.Format("<b>Date: </b>{0}<br/><b>Location: </b>{1}<br/><b>Holes: </b>{2}",
                                                lastresults.date, lastresults.location, lastresults.holecount);
            //linkResults.NavigateUrl += "?id=" + fixtureReference.reference;
            linkResults.HRef += "?id=" + fixtureReference.reference;
        }
        catch (Exception)
        {
            litLastResults.Text = "<b>To be Recorded</b>";
            linkResults.Visible = false;
        }
    }

    private void DetermineLastNewsLetter()
    {
        var newsLetterReference = doc2.Elements("newsletters")
                                      .Elements("newsletter")
                                      .Where(e => (DateTime.Parse(e.Attribute("date").Value) < DateTime.Now))
                                      .OrderByDescending(e => DateTime.Parse(e.Attribute("date").Value))
                                      .Select(e => new {date = e.Attribute("date").Value}).Take(1).SingleOrDefault();

        litLastNewsLetter.Text = string.Format("<b>Date: </b>{0}<br/>", newsLetterReference.date);
    }


    private void DetermineNextFixture()
    {
        try
        {
            var fixtureReference = doc.Elements("Fixtures")
                                      .Elements("Fixture")
                                      .Where(e => DateTime.Parse(e.Attribute("Date").Value) > DateTime.Now)
                                      .OrderBy(e => DateTime.Parse(e.Attribute("Date").Value))
                                      .Select(e => new { reference = e.Attribute("Reference").Value }).Take(1).Single();

            var nextfixture = doc.Elements("Fixtures")
                                 .Elements("Fixture")
                                 .Where(e => e.Attribute("Reference").Value == fixtureReference.reference)
                                 .Select(e => new
                                     {
                                         date = e.Attribute("Date").Value,
                                         location = e.Attribute("Location").Value,
                                         holecount = e.Attribute("HoleCount").Value
                                     }).Single();

            litNextFixture.Text = string.Format("<b>Date: </b>{0}<br/><b>Location: </b>{1}<br/><b>Holes: </b>{2}",
                                                nextfixture.date, nextfixture.location, nextfixture.holecount);
//            linkNextFixture.NavigateUrl += "?id=" + fixtureReference.reference;
            linkNextFixture.HRef += "?id=" + fixtureReference.reference;


        }
        catch (Exception)
        {
            litNextFixture.Text = "<b>To be Announced</b>";
            linkNextFixture.Visible = false;
        }
    }
}