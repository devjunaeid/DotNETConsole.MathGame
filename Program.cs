namespace DotNETConsole.MathGame;

using DotNETConsole.MathGame.UI;
using DotNETConsole.MathGame.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        MainUI gameUI = new MainUI();
        gameUI.GameInit();
        bool gameRunning = true;
        while (gameRunning)
        {
            gameUI.GameTopBar();
            MainMenuChoices menuChoice = gameUI.GameMenuController();
            switch (menuChoice)
            {
                case MainMenuChoices.StartGame:
                    QuestionType gameType = gameUI.GameType();
                    gameUI.StartGame(gameType);
                    gameUI.GameEndMessage();
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }
                    Console.Clear();
                    break;
                case MainMenuChoices.ViewScore:
                    gameUI.ShowScore();
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }
                    Console.Clear();
                    break;
                case MainMenuChoices.Exit:
                    gameRunning = false;
                    Console.Clear();
                    break;
            }
        }
    }
}
