namespace DotNETConsole.MathGame.UI;
using Spectre.Console;
using DotNETConsole.MathGame.DB;
using DotNETConsole.MathGame.Models;
using DotNETConsole.MathGame.Enums;

internal class MainUI
{
    static int Score { get; set; }
    static int GameCycle { get; set; }
    static DB database { get; set; } = new DB();
    internal void GameInit()
    {
        database.Init();
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
        Score = 0;
        // Filtering Question from DB based on Game Type.
        List<Questions> filterdQuestions = database.QuestionsTable.Where(q => q.Type == gameType).ToList();
        Scores scoreEntry = new Scores();
        GameCycle += 1;
        scoreEntry.Lebel = $"Game {GameCycle}";
        int totalQuestions = filterdQuestions.Count;
        int currentQuestion = 1;

        foreach (Questions q in filterdQuestions)
        {
            string message = $"{scoreEntry.Lebel}:: Type-{gameType} :: Q({currentQuestion}/{totalQuestions}) --------- Current Score: {Score}";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 10);
            AnsiConsole.MarkupLine($"[bold blue]{message}[/]");
            bool correct = q.AskQuestion();
            if (correct)
            {
                Score += 5;
            }
            currentQuestion++;
            scoreEntry.UpdateScore(Score);
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
            table.AddRow($"{sc.Lebel}", $"{sc.TimeStamp}", $"{Score}");
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine($"[bold red]press 'Esc' to return to the main menu.[/]");
    }

    internal void GameEndMessage()
    {
        Console.Clear();
        string message = $"Game Over! Your final score is: {Score}";

        //Write the message in the middle
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
        AnsiConsole.MarkupLine($"[bold green]{message}[/]");
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2 + 10);
        AnsiConsole.MarkupLine($"[bold red]press 'Esc' to return to the main menu.[/]");
    }

    internal void GameTopBar()
    {
        Console.Clear();
        string message = $"Welcome to MQuiz";

        //Write the message in the middle
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, 0);
        AnsiConsole.MarkupLine($"[bold green]-==-{message}-==-[/]");
        Console.SetCursorPosition((Console.WindowWidth - 10) / 2, 1);
        AnsiConsole.MarkupLine("author: [blue][link=https://github.com/devjunaeid]devjunaeid[/][/]");
    }
}
