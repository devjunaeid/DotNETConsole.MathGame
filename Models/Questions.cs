namespace DotNETConsole.MathGame.Models;
using DotNETConsole.MathGame.Enums;
using DotNETConsole.MathGame.IMathGame;
using Spectre.Console;

internal class Questions : IQuestions
{
    internal string Question { get; set; } = string.Empty;
    internal List<(Answer, string)> Options { get; set; } = new List<(Answer, string)>();
    internal QuestionType Type { get; set; }
    internal Answer SelectedAnswer { get; set; }

    public bool AskQuestion()
    {
        // AnsiConsole.Write(new Markup(Question));
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<(Answer, string)>()
                .Title(Question)
                .AddChoices(Options));
        return choice.Item1 == SelectedAnswer;
    }
}
