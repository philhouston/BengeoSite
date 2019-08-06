/// <summary>
///     Summary description for IScoreCalculator
/// </summary>
public interface IScoreCalculator
{
    int CalculateScore(PlayerEventInfo paramEvent);
    int CalculateTotal(PlayerYearInfo paramPlayer);
}