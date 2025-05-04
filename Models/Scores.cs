namespace DotNETConsole.MathGame.Models;


internal class Scores
{
    internal DateTime TimeStamp { get; set; } = DateTime.Now;
    internal string Lebel { get; set; } = "";
    internal int Score { get; set; } = 0;

    internal void UpdateScore(int score)
    {
        Score = score;
    }
}
