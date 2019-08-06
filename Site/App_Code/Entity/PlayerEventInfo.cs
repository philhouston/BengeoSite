/// <summary>
///     Summary description for PlayerEventInfo
/// </summary>
public class PlayerEventInfo
{
    public PlayerEventInfo(string paramEventName)
    {
        EventName = paramEventName;
        Position = -1;
        Score = -1;
    }

    public PlayerEventInfo(string paramEventName, int paramPosition)
    {
        EventName = paramEventName;
        Position = paramPosition;
        Score = -1;
    }

    public string EventName { get; set; }

    public int Position { get; set; }

    public int Score { get; set; }
}