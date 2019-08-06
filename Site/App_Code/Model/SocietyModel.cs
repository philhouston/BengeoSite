using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
///     Summary description for SocietyModel
/// </summary>
public class SocietyModel
{
    public IEnumerable<CaptainInfo> GetCaptains()
    {
        XDocument doc = SiteCache.SocietyData;

        var results = new List<CaptainInfo>();

        IEnumerable<CaptainInfo> captains = doc.Element("Society")
                                               .Descendants("Captain")
                                               .OrderByDescending(e => int.Parse(e.Attribute("Season").Value))
                                               .Select(e => new CaptainInfo
                                                   {
                                                       Season = e.Attribute("Season").Value,
                                                       Name = e.Attribute("Member").Value,
                                                       Picture = e.Attribute("Picture").Value,
                                                       Raised = double.Parse(e.Attribute("Raised").Value),
                                                       Charity = e.Attribute("Charity").Value
                                                   });

        return captains;
    }
}