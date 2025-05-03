namespace DotNETConsole.MathGame.UI;

using Spectre.Console;

public static class MainUI
{
    public static void Welcome()
    {
        AnsiConsole.Write(new Markup("[bold yellow]Hello[/] [red]World![/]"));
    }
}
