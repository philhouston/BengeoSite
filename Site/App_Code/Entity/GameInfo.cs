using System;

/// <summary>
///     Summary description for GameInfo
/// </summary>
public class GameInfo
{
    public int RoundNo { get; set; }
    public int GameNo { get; set; }
    public TeamInfo Winner { get; set; }
    public TeamInfo Home { get; set; }
    public TeamInfo Away { get; set; }
    public String Score { get; set; }
}