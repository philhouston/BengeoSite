using System.Collections.Generic;
using System.Linq;

/// <summary>
///     Summary description for PlayerYearInfo
/// </summary>
public class PlayerYearInfo
{
    private readonly IScoreCalculator _calculator;
    private readonly List<PlayerEventInfo> _events = new List<PlayerEventInfo>();
    private int _total;

    public PlayerYearInfo(string paramPlayer, List<string> paramEventNames, IScoreCalculator paramCalculator)
    {
        Player = paramPlayer;
        _calculator = paramCalculator;

        foreach (string name in paramEventNames)
        {
            _events.Add(new PlayerEventInfo(name));
        }
    }

    public List<PlayerEventInfo> Events
    {
        get { return _events; }
    }

    public int Event1
    {
        get
        {
            if (_events.Count < 1)
                return 0;

            if (_events[0].Score < 0)
                return 0;

            return _events[0].Score;
        }
    }

    public int Event2
    {
        get
        {
            if (_events.Count < 2)
                return 0;

            if (_events[1].Score < 0)
                return 0;

            return _events[1].Score;
        }
    }

    public int Event3
    {
        get
        {
            if (_events.Count < 3)
                return 0;

            if (_events[2].Score < 0)
                return 0;

            return _events[2].Score;
        }
    }

    public int Event4
    {
        get
        {
            if (_events.Count < 4)
                return 0;

            if (_events[3].Score < 0)
                return 0;

            return _events[3].Score;
        }
    }

    public int Event5
    {
        get
        {
            if (_events.Count < 5)
                return 0;

            if (_events[4].Score < 0)
                return 0;

            return _events[4].Score;
        }
    }

    public int Event6
    {
        get
        {
            if (_events.Count < 6)
                return 0;

            if (_events[5].Score < 0)
                return 0;

            return _events[5].Score;
        }
    }

    public int Event7
    {
        get
        {
            if (_events.Count < 7)
                return 0;

            if (_events[6].Score < 0)
                return 0;

            return _events[6].Score;
        }
    }

    public int Event8
    {
        get
        {
            if (_events.Count < 8)
                return 0;

            if (_events[7].Score < 0)
                return 0;

            return _events[7].Score;
        }
    }


    public string Player { get; set; }

    public int Total
    {
        get { return _total; }
    }

    public void RecordEvent(string paramEventName, int paramPosition)
    {
        PlayerEventInfo ev = _events.Where(ee => ee.EventName == paramEventName).SingleOrDefault();

        ev.Position = paramPosition;
        ev.Score = _calculator.CalculateScore(ev);

        _total = _calculator.CalculateTotal(this);
    }
}