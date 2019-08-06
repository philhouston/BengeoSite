using System;
using System.Collections.Generic;

/// <summary>
///     Summary description for TeamInfo
/// </summary>
public class TeamInfo
{
    public TeamInfo()
    {
        Players = new List<string>();
    }

    public TeamInfo(string name)
    {
        Players = new List<string>();
        TeamName = name;
    }

    public TeamInfo(string name, string player1)
    {
        Players = new List<string>();
        TeamName = name;
        Players.Add(player1);
    }

    public TeamInfo(string name, string player1, string player2)
    {
        Players = new List<string>();
        TeamName = name;
        Players.Add(player1);
        Players.Add(player2);
    }


    public String TeamName { get; set; }
    public List<String> Players { get; set; }

    public String Player1
    {
        get
        {
            if (Players.Count > 0)
                return Players[0];
            else
                return string.Empty;
        }
    }

    public String Player2
    {
        get
        {
            if (Players.Count > 1)
                return Players[1];
            else
                return string.Empty;
        }
    }
}