using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
///     Summary description for KnockoutModel
/// </summary>
public class KnockoutModel
{
    private readonly XDocument doc;

    public KnockoutModel(XDocument doc)
    {
        this.doc = doc;
    }


    public IEnumerable<SelectInfo> GetListOfSeasons()
    {
        var seasons = (from ee in doc.Element("Seasons").Elements("Season")
                       orderby ee.Attribute("Year").Value descending
                       select new
                           {
                               reference = ee.Attribute("Year").Value,
                               display = ee.Attribute("Year").Value
                           }).Distinct();


        var distinctSeasons = new List<SelectInfo>();

        foreach (var item in seasons)
        {
            distinctSeasons.Add(new SelectInfo(item.reference, item.display));
        }

        return distinctSeasons;
    }

    public IEnumerable<RoundInfo> GetRounds(String season)
    {
        IEnumerable<RoundInfo> rounds = doc.Element("Seasons").Elements("Season")
                                           .Where(ee => ee.Attribute("Year").Value == season)
                                           .Descendants("Round")
                                           .Select(ee => new RoundInfo
                                               {
                                                   No = (int) ee.Attribute("No"),
                                                   Cutoff = DateTime.Parse((string) ee.Attribute("Cutoff"))
                                               });

        return rounds;
    }

    public IEnumerable<TeamInfo> GetTeams(String season)
    {
        IEnumerable<XElement> teams = doc.Element("Seasons").Elements("Season").Elements("Teams")
                                         .Where(ee => ee.Parent.Attribute("Year").Value == season)
                                         .Select(ee => ee);

        IEnumerable<XElement> teams2 = teams.Elements("Team").Select(ee => ee);


        var teamList = new List<TeamInfo>();

        foreach (XElement team in teams2)
        {
            var ti = new TeamInfo();
            ti.TeamName = (string) team.Attribute("Name");

            IEnumerable<XElement> players = team.Element("Players").Elements("Player").Select(ee => ee);

            foreach (XElement player in players)
            {
                var name = (string) player.Attribute("Name");
                if (!string.IsNullOrEmpty(name))
                    ti.Players.Add(name);
            }

            teamList.Add(ti);
        }

        return teamList;
    }

    public IEnumerable<GameInfo> GetGames(String season, int round)
    {
        IEnumerable<TeamInfo> teams = GetTeams(season);

        var games = doc.Element("Seasons").Elements("Season")
                       .Where(ee => (string) ee.Attribute("Year") == season)
                       .Descendants("Game")
                       .Select(ee => new
                           {
                               GameNo = (int) ee.Attribute("No"),
                               RoundNo = (int) ee.Parent.Parent.Attribute("No"),
                               Winner = (string) ee.Attribute("Winner"),
                               Home = (string) ee.Attribute("Home"),
                               Away = (string) ee.Attribute("Away"),
                               Score = (string) ee.Attribute("Score")
                           });

        var games2 = new List<GameInfo>();
        foreach (var game in games.Where(p => p.RoundNo == round).Select(p => p))
        {
            var info = new GameInfo();

            info.Winner = teams.SingleOrDefault(p => p.TeamName == game.Winner);
            info.Home = teams.SingleOrDefault(p => p.TeamName == game.Home);
            info.Away = teams.SingleOrDefault(p => p.TeamName == game.Away);

            if (info.Winner == null)
                info.Winner = new TeamInfo(game.Winner, game.Winner);

            if (info.Home == null)
                info.Home = new TeamInfo(game.Home, game.Home);

            if (info.Away == null)
                info.Away = new TeamInfo(game.Away, game.Away);

            info.GameNo = game.GameNo;
            info.RoundNo = game.RoundNo;
            info.Score = game.Score;

            games2.Add(info);
        }
        return games2;
    }
}