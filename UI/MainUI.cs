namespace DotNETConsole.MathGame.UI;
using Spectre.Console;
using DotNETConsole.MathGame.DB;
using DotNETConsole.MathGame.Models;
using DotNETConsole.MathGame.Enums;

internal class MainUI
{
    static int score { get; set; } = 0;
    static DB database {get; set;} = new DB();
    internal void Welcome()
    {
        Console.WriteLine("Welcome!!!");
        database.INIT();
    }

    // Game Type Selection.
    internal QuestionType GameType()
    {
        // Converting QuestionType Enum to List for Input Selection Choice.
        List<QuestionType> qType = new List<QuestionType>((QuestionType[])Enum.GetValues(typeof(QuestionType)));

        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<QuestionType>()
                .Title("Which Mode Do You Like to Play?")
                .AddChoices(qType));

        return choice;
    }
    internal void StartGame(QuestionType gameType) {
        
        // Filtering Question from DB based on Game Type.
        List<Questions> filterdQuestions = database.QuestionsTable.Where(q => q.Type == gameType).ToList();

        foreach (Questions q in filterdQuestions)
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
