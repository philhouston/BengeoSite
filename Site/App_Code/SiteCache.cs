using System;
using System.Xml.Linq;

/// <summary>
///     Summary description for SiteCache
/// </summary>
public static class SiteCache
{
    private static readonly XDocument fixtureDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/FixtureData.xml");

    private static readonly XDocument handicapDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/HandicapData.xml");

    private static readonly XDocument clubDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/ClubData.xml");

    private static readonly XDocument competitionDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/CompetitionData.xml");

    private static readonly XDocument newslettersDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/NewslettersData.xml");

    private static readonly XDocument cupDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/CupData.xml");

    private static readonly XDocument societyDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/SocietyHistoryData.xml");

    private static readonly XDocument agmDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/AGMData.xml");

    private static readonly XDocument doublesKnockoutDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/DoublesKnockoutData.xml");

    private static readonly XDocument singlesKnockoutDoc =
        XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/SinglesKnockoutData.xml");

    public static XDocument FixtureData
    {
        get { return fixtureDoc; }
    }

    public static XDocument DoubleKnockoutData
    {
        get { return doublesKnockoutDoc; }
    }

    public static XDocument SinglesKnockoutData
    {
        get { return singlesKnockoutDoc; }
    }


    public static XDocument AGMData
    {
        get { return agmDoc; }
    }

    public static XDocument HandicapData
    {
        get { return handicapDoc; }
    }

    public static XDocument ClubData
    {
        get { return clubDoc; }
    }

    public static XDocument CompetitionData
    {
        get { return competitionDoc; }
    }

    public static XDocument CupData
    {
        get { return cupDoc; }
    }

    public static XDocument NewslettersData
    {
        get { return newslettersDoc; }
    }

    public static XDocument SocietyData
    {
        get { return societyDoc; }
    }
}