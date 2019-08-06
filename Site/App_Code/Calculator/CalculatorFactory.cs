/// <summary>
///     Summary description for POTY_CalcFactory
/// </summary>
public class CalculatorFactory
{
    public static IScoreCalculator GetScoreCalculator(string paramSeason)
    {
        int season = int.Parse(paramSeason);

        if (season < 2009)
            return new LowestPosition();
        else
            return new HighestScore();
    }
}