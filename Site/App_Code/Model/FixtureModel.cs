using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
///     Summary description for FixtureModel
/// </summary>
public class FixtureModel
{
    public IEnumerable<SelectInfo> GetListOfSeasons()
    {
        XDocument doc = SiteCache.FixtureData;


        var seasons = (from ee in doc.Element("Fixtures").Elements("Fixture")
                       orderby ee.Attribute("Season").Value descending
                       select new
                           {
                               reference = ee.Attribute("Season").Value,
                               display = ee.Attribute("Season").Value
                           }).Distinct();


        var distinctSeasons = new List<SelectInfo>();

        foreach (var item in seasons)
        {
            distinctSeasons.Add(new SelectInfo(item.reference, item.display));
        }

        return distinctSeasons;
    }

    public IEnumerable<SelectInfo> GetListOfSeasons(bool paramShowFuture)
    {
        IEnumerable<SelectInfo> seasons = GetListOfSeasons();

        if (!paramShowFuture)
        {
            seasons = from ee in seasons
                      where int.Parse(ee.Reference) <= DateTime.Now.Year
                      orderby ee descending
                      select ee;
        }

        return seasons;
    }

    public IEnumerable<FixtureListInfo> GetListOfFixturesForSeason(string paramSeason)
    {
        XDocument doc = SiteCache.FixtureData;

        IEnumerable<FixtureListInfo> fixtures = (from ee in doc.Element("Fixtures").Elements("Fixture")
                                                 where ee.Attribute("Season").Value == paramSeason
                                                 select new FixtureListInfo
                                                     {
                                                         Reference = (string) ee.Attribute("Reference"),
                                                         Location = (string) ee.Attribute("Location"),
                                                         Price = (string) ee.Attribute("Cost"),
                                                         Date = (string) ee.Attribute("Date"),
                                                         Description = (string) ee.Attribute("Description"),
                                                         Cup = (string) ee.Attribute("Cup"),
                                                         HoleCount = (string) ee.Attribute("HoleCount")
                                                     });

        return fixtures;
    }

    public IEnumerable<SelectInfo> GetListOfFixturesForSelecting(string paramSeason)
    {
        XDocument doc = SiteCache.FixtureData;

        IEnumerable<SelectInfo> fixtures = from ee in doc.Elements("Fixtures").Elements("Fixture")
                                           where ee.Attribute("Season").Value == paramSeason
                                           orderby ee.Attribute("Date").Value descending
                                           select
                                               new SelectInfo(ee.Attribute("Reference").Value,
                                                              (string)ee.Attribute("Date").Value + " - " +
                                                              ee.Attribute("Location").Value);

        return fixtures;
    }

    public IEnumerable<SelectInfo> GetlistOfFixturesWithResultsForSelecting(string paramSeason)
    {
        XDocument doc = SiteCache.FixtureData;

        IEnumerable<SelectInfo> fixtures = doc.Elements("Fixtures").Elements("Fixture")
                                              .Where(ee => ee.Element("Results") != null)
                                              .Where(ee => ee.Attribute("Season").Value == paramSeason)
                                              .OrderByDescending(ee => DateTime.Parse((string) ee.Attribute("Date")))
                                              .Select(ee => new SelectInfo(ee.Attribute("Reference").Value,
                                                                           ee.Attribute("Date").Value + " - " +
                                                                           ee.Attribute("Location").Value));


        return fixtures;
    }

    public IEnumerable<FixtureListInfo> GetFixtureInfoDetails(string paramFixtureReference)
    {
        XDocument doc = SiteCache.FixtureData;

        IEnumerable<FixtureListInfo> fixtures = (from ee in doc.Element("Fixtures").Elements("Fixture")
                                                 where ee.Attribute("Reference").Value == paramFixtureReference
                                                 select new FixtureListInfo
                                                     {
                                                         Reference = (string) ee.Attribute("Reference"),
                                                         Location = (string) ee.Attribute("Location"),
                                                         Price = (string) ee.Attribute("Cost"),
                                                         Date = (string) ee.Attribute("Date"),
                                                         Description = (string) ee.Attribute("Description"),
                                                         Cup = (string) ee.Attribute("Cup"),
                                                         HoleCount = (string) ee.Attribute("HoleCount"),
                                                         CutoffDate = (string) ee.Attribute("CutoffDate"),
                                                         PlayerOfTheYear = (string) ee.Attribute("PlayerOfTheYear"),
                                                         Entries = (string) ee.Attribute("Entries"),
                                                         Cancellations = (string) ee.Attribute("Cancellations"),
                                                         MeetingTime = (string) ee.Attribute("MeetingTime")
                                                     }).Take(1);

        return fixtures;
    }

    public IEnumerable<FixtureListInfo> GetClubHistory(string paramClubReference)
    {
        XDocument doc = SiteCache.FixtureData;

        IEnumerable<FixtureListInfo> fixtures = (from ee in doc.Element("Fixtures").Elements("Fixture")
                                                 where ee.Attribute("Location").Value == paramClubReference
                                                 select new FixtureListInfo
                                                     {
                                                         Reference = (string) ee.Attribute("Reference"),
                                                         Date = (string) ee.Attribute("Date"),
                                                         Cup = (string) ee.Attribute("Cup"),
                                                         Winner = (string) ee.Attribute("Winner")
                                                     });

        return fixtures;
    }

    public IEnumerable<FixtureListInfo> GetCupHistory(string paramCupReference)
    {
        XDocument doc = SiteCache.FixtureData;

        XDocument doc2 = SiteCache.CupData;

        IList<FixtureListInfo> list = doc2.Element("Cups").Elements("Cup")
                                          .Where(ee => ee.Attribute("Reference").Value == paramCupReference)
                                          .Descendants("PreviousWinner").Select(ee => new FixtureListInfo
                                              {
                                                  Reference = (string) ee.Attribute("Date"),
                                                  Date = (string) ee.Attribute("Date"),
                                                  Location = (string) ee.Attribute("Location"),
                                                  Winner = (string) ee.Attribute("Winner")
                                              }).ToList();
        // TODO:  Should the reference above really be sourced from the "DATE" field?


        IEnumerable<XElement> fixtures = (from ee in doc.Element("Fixtures").Elements("Fixture")
                                          where ee.Attribute("Cup").Value.Contains(paramCupReference)
                                          select ee);


        foreach (XElement fixture in fixtures)
        {
            if (fixture.Element("Results") != null)
            {
                IEnumerable<FixtureListInfo> resultlist = from ff in fixture.Element("Results").Elements("Result")
                                                          where ff.Attribute("Cup").Value == paramCupReference
                                                          select new FixtureListInfo
                                                              {
                                                                  Reference = (string) fixture.Attribute("Reference"),
                                                                  Date = (string) fixture.Attribute("Date"),
                                                                  Location = (string) fixture.Attribute("Location"),
                                                                  Winner = (string) ff.Attribute("Winner")
                                                              };

                foreach (FixtureListInfo item in resultlist)
                {
                    DateTime workDate = DateTime.Parse(item.Date);
                    item.Date = workDate.Year.ToString();
                    list.Add(item);
                }
            }
        }

        return list.OrderByDescending(ee => int.Parse(ee.Date)).ToList();
    }

    public decimal GetLatestAdjustments(string paraName)
    {
        XDocument doc = SiteCache.FixtureData;

        decimal latestAdjustments = doc.Element("Fixtures")
                                       .Elements("Fixture")
                                       .Descendants("Adjustment")
                                       .Where(ee => (string) ee.Attribute("Name") == paraName)
                                       .Where(
                                           ee =>
                                           DateTime.Now <
                                           DateTime.Parse(
                                               (String)
                                               ee.Ancestors("Adjustments").SingleOrDefault().Attribute("Expiry")))
                                       .OrderByDescending(
                                           ee =>
                                           DateTime.Parse(
                                               (string)
                                               ee.Ancestors("Adjustments").SingleOrDefault().Attribute("Expiry")))
                                       .Sum(ee => decimal.Parse((string) ee.Attribute("Adjustment")));


        return latestAdjustments;
    }
}