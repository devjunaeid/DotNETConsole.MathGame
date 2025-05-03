namespace DotNETConsole.MathGame;

using DotNETConsole.MathGame.UI;

public class Program
{
    public static void Main(string[] args)
    {
        MainUI GameUI = new MainUI();
        GameUI.Welcome();
        GameUI.StartGame();
    }
}
