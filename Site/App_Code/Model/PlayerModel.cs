using System;
using System.Linq;
using System.Xml.Linq;

/// <summary>
///     Summary description for PlayerModel
/// </summary>
public class PlayerModel
{
    public decimal GetLatestHandicap(string paraName)
    {
        XDocument doc1 = SiteCache.HandicapData;

        decimal latestHandicap =
            doc1.Element("Members").Elements("Member").Elements("Adjustments").Elements("Adjustment")
                .Where(ee => ee.Ancestors("Member").Single().Attribute("Name").Value == paraName)
                .OrderByDescending(ee => DateTime.Parse(ee.Attribute("Date").Value))
                .Select(ee => decimal.Parse(ee.Attribute("Handicap").Value))
                .Take(1)
                .SingleOrDefault();

        return latestHandicap;
    }

    public decimal GetLatestDiscretionary(string paraName)
    {
        XDocument doc1 = SiteCache.HandicapData;

        decimal latestDiscretionary = doc1.Element("Members")
                                          .Elements("Member")
                                          .Elements("DiscretionaryShots")
                                          .Elements("DiscretionaryShot")
                                          .Where(
                                              ee => ee.Ancestors("Member").Single().Attribute("Name").Value == paraName)
                                          .Where(ee => DateTime.Parse(ee.Attribute("Expires").Value) > DateTime.Now)
                                          .Sum(ee => decimal.Parse(ee.Attribute("Adjustment").Value));

        return latestDiscretionary;
    }

    public PlayerInfo GetPlayerInfo(string paraName, decimal handicap)
    {
        XDocument doc1 = SiteCache.HandicapData;

        PlayerInfo info = doc1.Element("Members").Elements("Member")
                              .Where(ee => ee.Attribute("Name").Value == paraName)
                              .Select(ee => new PlayerInfo
                                  {
                                      Name = (string) ee.Attribute("Name"),
                                      Club = (string) ee.Attribute("Club"),
                                      PlayingHandicap = handicap,
                                      Picture = (string) ee.Attribute("Picture")
                                  }).SingleOrDefault();

        return info;
    }
}