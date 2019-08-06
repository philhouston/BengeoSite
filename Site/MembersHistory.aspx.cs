using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Handicap : Page
{
    private XDocument doc;
    private XDocument doc1;
    private FixtureModel model;
    private PlayerModel model2;

    protected void Page_Init(object sender, EventArgs e)
    {
        doc = SiteCache.FixtureData;
        doc1 = SiteCache.HandicapData;

        model = new FixtureModel();
        model2 = new PlayerModel();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cbMember.DataBind();
            cbMember.SelectedIndex = 0;
            LoadMembersInfo();
            RefreshGridData();
        }
    }

    private void RefreshGridData()
    {
        grid.DataBind();
        grid1.DataBind();
        grid2.DataBind();
    }

    private void LoadMembersInfo()
    {
        //var latestHandicap = doc1.Element("Members").Elements("Member").Elements("Adjustments").Elements("Adjustment")
        //                      .Where(ee => ee.Ancestors("Member").Single().Attribute("Name").Value == cbMember.SelectedItem.Value)
        //                        .OrderByDescending(ee => DateTime.Parse(ee.Attribute("Date").Value))
        //                            .Select(ee => decimal.Parse(ee.Attribute("Handicap").Value))
        //                                .Take(1)
        //                                    .SingleOrDefault();

        decimal latestHandicap = model2.GetLatestHandicap(cbMember.SelectedItem.Value);


        //var latestDiscretionary = doc1.Element("Members").Elements("Member").Elements("DiscretionaryShots").Elements("DiscretionaryShot")
        //                            .Where(ee => ee.Ancestors("Member").Single().Attribute("Name").Value == cbMember.SelectedItem.Value)
        //                                .Where(ee => DateTime.Parse(ee.Attribute("Expires").Value) > DateTime.Now)
        //                                    .Sum(ee => decimal.Parse(ee.Attribute("Adjustment").Value));

        decimal latestDiscretionary = model2.GetLatestDiscretionary(cbMember.SelectedItem.Value);


        //var latestAdjustments = doc.Element("Fixtures")
        //                             .Elements("Fixture")
        //                                .Descendants("Adjustment")
        //                                    .Where(ee => (string)ee.Attribute("Name") == cbMember.SelectedItem.Value)
        //                                        .Where(ee => DateTime.Now < DateTime.Parse((String)ee.Ancestors("Adjustments").SingleOrDefault().Attribute("Expiry")))
        //                                            .OrderByDescending(ee => DateTime.Parse((string)ee.Ancestors("Adjustments").SingleOrDefault().Attribute("Expiry")))
        //                                                .Sum(ee => decimal.Parse((string)ee.Attribute("Adjustment")));

        decimal latestAdjustments = model.GetLatestAdjustments(cbMember.SelectedItem.Value);


        //var info = doc1.Element("Members").Elements("Member")
        //            .Where(ee => ee.Attribute("Name").Value == cbMember.SelectedItem.Value)
        //                .Select(ee => new
        //                {
        //                    club = ee.Attribute("Club").Value,
        //                    playingHandicap = latestHandicap + latestDiscretionary + latestAdjustments,
        //                    picture = ee.Attribute("Picture").Value
        //                }).SingleOrDefault();

        PlayerInfo info = model2.GetPlayerInfo(cbMember.SelectedItem.Value,
                                               latestHandicap + latestDiscretionary + latestAdjustments);

        litMembersClubValue.Text = info.Club;
        litPlayingHandicapValue.Text = info.PlayingHandicap.ToString();
        //MemberPicture.ImageUrl = info.Picture;
        MemberPicture.Src = info.Picture;
    }


    protected void cbMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMembersInfo();
        RefreshGridData();
    }

    protected void tabs_ActiveTabChanged(object sender, EventArgs e)
    {
        RefreshGridData();
    }

    protected void MembersDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        var members = (from ee in doc1.Elements("Members").Elements("Member")
                       where ee.Attribute("Member").Value == "True"
                       orderby ee.Attribute("Surname").Value + ", " + ee.Attribute("Forename").Value
                       select new
                           {
                               DisplayName = ee.Attribute("Surname").Value + ", " + ee.Attribute("Forename").Value,
                               Name = ee.Attribute("Name").Value
                           }).Distinct();

        e.Result = members;
    }

    protected void HandicapHistorySource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        var handicaps = doc1.Element("Members").Elements("Member").Elements("Adjustments").Elements("Adjustment")
                            .Where(
                                ee =>
                                ee.Ancestors("Member").Single().Attribute("Name").Value == cbMember.SelectedItem.Value)
                            .OrderByDescending(ee => DateTime.Parse(ee.Attribute("Date").Value))
                            .Select(ee => new
                                {
                                    date = DateTime.Parse(ee.Attribute("Date").Value),
                                    description = ee.Attribute("Description").Value,
                                    handicap = Decimal.Parse(ee.Attribute("Handicap").Value)
                                });

        e.Result = handicaps;
    }

    protected void PlayingAdjustmentSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        var adjustments = doc.Element("Fixtures")
                             .Elements("Fixture")
                             .Descendants("Adjustment")
                             .Where(ee => (string) ee.Attribute("Name") == cbMember.SelectedItem.Value)
                             .Where(
                                 ee =>
                                 DateTime.Now <
                                 DateTime.Parse(
                                     (string) ee.Ancestors("Adjustments").SingleOrDefault().Attribute("Expiry")))
                             .OrderByDescending(
                                 ee => DateTime.Parse((string) ee.Ancestors("Adjustments").Single().Attribute("Expiry")))
                             .Select(ee => new
                                 {
                                     date =
                                               DateTime.Parse(
                                                   (string) ee.Ancestors("Fixture").SingleOrDefault().Attribute("Date")),
                                     expiry =
                                               DateTime.Parse(
                                                   (string)
                                                   ee.Ancestors("Adjustments").SingleOrDefault().Attribute("Expiry")),
                                     location = (string) ee.Ancestors("Fixture").SingleOrDefault().Attribute("Location"),
                                     adjustment = (string) ee.Attribute("Adjustment"),
                                     reason = (string) ee.Attribute("Reason")
                                 });

        e.Result = adjustments;
    }

    protected void PlayingHistorySource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        var scores = doc.Element("Fixtures")
                        .Elements("Fixture")
                        .Where(ee => ee.Element("Results") != null)
                        .Descendants("Score")
                        .Where(ee => ee.Attribute("Name").Value == cbMember.SelectedItem.Value)
                        .OrderByDescending(
                            ee => DateTime.Parse(ee.Ancestors("Fixture").SingleOrDefault().Attribute("Date").Value))
                        .Select(ee => new
                            {
                                season = (string) ee.Ancestors("Fixture").SingleOrDefault().Attribute("Season"),
                                date =
                                          DateTime.Parse(
                                              (string) ee.Ancestors("Fixture").SingleOrDefault().Attribute("Date")),
                                location = (string) ee.Ancestors("Fixture").SingleOrDefault().Attribute("Location"),
                                division = (string) ee.Ancestors("Result").SingleOrDefault().Attribute("Cup"),
                                position = (string) ee.Attribute("Position"),
                                points = (string) ee.Attribute("Points")
                            });

        e.Result = scores;
    }
}