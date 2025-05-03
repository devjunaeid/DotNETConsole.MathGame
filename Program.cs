namespace DotNETConsole.MathGame;

using DotNETConsole.MathGame.UI;
using DotNETConsole.MathGame.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        MainUI GameUI = new MainUI();
        GameUI.Welcome();
        QuestionType gameType = GameUI.GameType();
        GameUI.StartGame(gameType);
    }
}
