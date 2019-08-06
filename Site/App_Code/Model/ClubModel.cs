using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
///     Summary description for ClubModel
/// </summary>
public class ClubModel
{
    public IEnumerable<SelectInfo> GetClubList()
    {
        XDocument doc = SiteCache.ClubData;

        var results = new List<SelectInfo>();

        var clubs = doc.Elements("Clubs")
                       .Elements("Club")
                       .OrderBy(e => e.Attribute("Name").Value)
                       .Select(e => new
                           {
                               reference = e.Attribute("Reference").Value,
                               name = e.Attribute("Name").Value
                           });

        foreach (var item in clubs)
        {
            results.Add(new SelectInfo(item.reference, item.name));
        }

        return results;
    }

    public IEnumerable<ClubDataInfo> GetClubInfo(string paramReference)
    {
        XDocument doc = SiteCache.ClubData;

        IEnumerable<ClubDataInfo> info = doc.Elements("Clubs")
                                            .Elements("Club")
                                            .Where(ee => ee.Attribute("Reference").Value == paramReference)
                                            .Select(ee => new ClubDataInfo
                                                {
                                                    Reference = ee.Attribute("Reference").Value,
                                                    Name = ee.Attribute("Name").Value,
                                                    Address = ee.Attribute("Address").Value,
                                                    Secretary = ee.Attribute("Secretary").Value,
                                                    SecretaryPhone = ee.Attribute("SecPhone").Value,
                                                    Pro = ee.Attribute("ProName").Value,
                                                    ProPhone = ee.Attribute("ProPhone").Value,
                                                    WebSite = ee.Attribute("WebSite").Value,
                                                    Designer = ee.Attribute("Designer").Value,
                                                    Yardage = ee.Attribute("Yardage").Value,
                                                    Par = ee.Attribute("Par").Value,
                                                    Visitor = ee.Attribute("VisitorInfo").Value
                                                }).Take(1);

        return info;
    }

    public IEnumerable<SelectInfo> GetDirections(string paramReference)
    {
        XDocument doc = SiteCache.ClubData;

        IEnumerable<XElement> club = doc.Elements("Clubs")
                                        .Elements("Club")
                                        .Where(ee => ee.Attribute("Reference").Value == paramReference);

        IEnumerable<SelectInfo> info = club.Elements("Directions")
                                           .Elements("Direction")
                                           .Select(ee => new SelectInfo(ee.Attribute("Name").Value, ee.Value));

        return info;
    }
}