using System.Linq;

/// <summary>
///     Summary description for HighestScore
/// </summary>
public class HighestScore : IScoreCalculator
{
    #region IScoreCalculator Members

    int IScoreCalculator.CalculateScore(PlayerEventInfo paramEvent)
    {
        if (paramEvent == null)
            return -1;

        if (paramEvent.Position < 1)
            return -1;

        int score = 26 - paramEvent.Position;

        if (score < 1)
            score = 1;

        return score;
    }

    int IScoreCalculator.CalculateTotal(PlayerYearInfo paramPlayer)
    {
        return paramPlayer.Events.Where(ee => ee.Score > 0)
                          .OrderByDescending(ee => ee.Score)
                          .Take(5)
                          .Sum(ee => ee.Score);
    }

    #endregion
}