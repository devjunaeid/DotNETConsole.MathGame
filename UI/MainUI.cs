namespace DotNETConsole.MathGame.UI;
using DotNETConsole.MathGame.DB;
using DotNETConsole.MathGame.Models;

internal class MainUI
{
    static int score { get; set; } = 0;
    internal void Welcome()
    {
        Console.WriteLine("Welcome!!!");
    }

    internal void StartGame()
    {
        DB database = new DB();
        database.INIT();
        foreach (Questions q in database.QuestionsTable)
        {
            Console.WriteLine($"Current Score: {score}");
            bool correct = q.AskQuestion();
            if (correct)
            {
                score += 5;
            }
            Console.Clear();
        }
    }
}
