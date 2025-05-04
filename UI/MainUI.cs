namespace DotNETConsole.MathGame.UI;
using Spectre.Console;
using DotNETConsole.MathGame.DB;
using DotNETConsole.MathGame.Models;
using DotNETConsole.MathGame.Enums;

internal class MainUI
{
    static int score { get; set; } = 0;
    static int gameCycle { get; set; } = 0;
    static DB database { get; set; } = new DB();
    internal void GameInit()
    {
        database.INIT();
    }

    internal MainMenuChoices GameMenuController()
    {
        List<MainMenuChoices> options = new List<MainMenuChoices>((MainMenuChoices[])Enum.GetValues(typeof(MainMenuChoices)));
        var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuChoices>()
                        .Title("Main Menu:")
                        .AddChoices(options));

        return choice;
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
    internal void StartGame(QuestionType gameType)
    {
        //Reset Score.
        score = 0;
        // Filtering Question from DB based on Game Type.
        List<Questions> filterdQuestions = database.QuestionsTable.Where(q => q.Type == gameType).ToList();
        Scores scoreEntry = new Scores();
        gameCycle += 1;
        scoreEntry.Lebel = $"Game {gameCycle}";
        int totalQuestions = filterdQuestions.Count;
        int currentQuestion = 1;

        foreach (Questions q in filterdQuestions)
        {
            string message = $"{scoreEntry.Lebel}:: Type-{gameType} :: Q({currentQuestion}/{totalQuestions}) --------- Current Score: {score}";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 10);
            AnsiConsole.MarkupLine($"[bold blue]{message}[/]");
            bool correct = q.AskQuestion();
            if (correct)
            {
                score += 5;
            }
            currentQuestion++;
            scoreEntry.UpdateScore(score);
            Console.Clear();
        }
        database.ScoreTable.Add(scoreEntry);
    }

    internal void ShowScore()
    {
        var table = new Table();
        table.AddColumns(new[] { "Entry", "DateTime", "Score" });

        foreach (Scores sc in database.ScoreTable)
        {
            table.AddRow($"{sc.Lebel}", $"{sc.TimeStamp}", $"{score}");
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine($"[bold red]press 'Esc' to return to the main menu.[/]");
    }

    internal void GameEndMessage()
    {
        Console.Clear();
        string message = $"Game Over! Your final score is: {score}";

        //Write the message in the middle
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
        AnsiConsole.MarkupLine($"[bold green]{message}[/]");
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2 + 10);
        AnsiConsole.MarkupLine($"[bold red]press 'Esc' to return to the main menu.[/]");
    }
}
