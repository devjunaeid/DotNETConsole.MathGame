namespace DotNETConsole.MathGame.IMathGame;

using DotNETConsole.MathGame.Enums;

internal interface IQuestions
{
    internal string Question { get; set; }
    internal List<(Answer, string)> Options { get; set; }
    internal QuestionType Type { get; set; }
    internal Answer SelectedAnswer { get; set; }
    internal DifficultyLevel Level { get; set; }
}
