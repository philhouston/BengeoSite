using System.Linq;

/// <summary>
///     Summary description for LowestPosition
/// </summary>
public class LowestPosition : IScoreCalculator
{
    #region IScoreCalculator Members

    int IScoreCalculator.CalculateScore(PlayerEventInfo paramEvent)
    {
        if (paramEvent == null)
            return -1;

        if (paramEvent.Position == 0)
            return -1;

        return paramEvent.Position;
    }

    int IScoreCalculator.CalculateTotal(PlayerYearInfo paramPlayer)
    {
        if (paramPlayer == null)
            return -1;

        if (paramPlayer.Events == null)
            return -1;

        if (paramPlayer.Events.Count < 5)
            return -1;

        return paramPlayer.Events.Where(ee => ee.Score > 0).OrderBy(ee => ee.Score).Take(5).Sum(ee => ee.Score);
    }

    #endregion
}