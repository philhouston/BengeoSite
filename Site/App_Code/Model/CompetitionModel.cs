using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
///     Summary description for CompetitionModel
/// </summary>
public class CompetitionModel
{
    public IEnumerable<SelectInfo> GetCompetitionList()
    {
        XDocument doc = SiteCache.CompetitionData;

        var results = new List<SelectInfo>();

        var competitions = doc.Elements("Competitions")
                              .Elements("Competition")
                              .OrderByDescending(e => e.Attribute("Name").Value)
                              .Select(e => new
                                  {
                                      reference = (string) e.Attribute("Name"),
                                      name = (string) e.Attribute("Name")
                                  })
                              .Distinct();

        foreach (var item in competitions)
        {
            results.Add(new SelectInfo(item.reference, item.name));
        }

        return results;
    }

    public IEnumerable<CompetitionDataInfo> GetCompetitionInfo(string paramReference)
    {
        XDocument doc = SiteCache.CompetitionData;

        IEnumerable<CompetitionDataInfo> info = doc.Elements("Competitions")
                                                   .Elements("Competition")
                                                   .Where(ee => (string) ee.Attribute("Name") == paramReference)
                                                   .Select(ee => new CompetitionDataInfo
                                                       {
                                                           Name = (string) ee.Attribute("Name"),
                                                           Format = (string) ee.Attribute("Format"),
                                                           History = (string) ee.Attribute("History"),
                                                           Cup = (string) ee.Attribute("Cup")
                                                       }).Take(1);

        return info;
    }
}