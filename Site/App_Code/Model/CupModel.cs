using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
///     Summary description for ClubModel
/// </summary>
public class CupModel
{
    public IEnumerable<SelectInfo> GetCupList()
    {
        XDocument doc = SiteCache.CupData;

        var results = new List<SelectInfo>();

        var cups = doc.Elements("Cups")
                      .Elements("Cup")
                      .OrderBy(e => e.Attribute("Name").Value)
                      .Select(e => new
                          {
                              reference = e.Attribute("Reference").Value,
                              name = e.Attribute("Name").Value
                          });

        foreach (var item in cups)
        {
            results.Add(new SelectInfo(item.reference, item.name));
        }

        return results;
    }

    public CupDataInfo GetCupInfo(string paramReference)
    {
        XDocument doc = SiteCache.CupData;

        CupDataInfo info = doc.Elements("Cups")
                              .Elements("Cup")
                              .Where(ee => ee.Attribute("Reference").Value == paramReference)
                              .Select(ee => new CupDataInfo
                                  {
                                      Reference = ee.Attribute("Reference").Value,
                                      Name = ee.Attribute("Name").Value,
                                      DonatedBy = ee.Attribute("DonatedBy").Value,
                                      Date = ee.Attribute("Date").Value,
                                      Purpose = ee.Attribute("Purpose").Value
                                  })
                              .SingleOrDefault();
        return info;
    }
}