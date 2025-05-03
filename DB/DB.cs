namespace DotNETConsole.MathGame.DB;

using DotNETConsole.MathGame.Models;
using DotNETConsole.MathGame.Enums;

internal class DB
{
    internal List<Questions> QuestionsTable = new List<Questions>();

    internal void INIT()
    {
        Random random = new Random();

        // Init 10 Addition Questions.
        for (int i = 0; i < 10; i++)
        {
            Questions tempQ = new Questions();
            int tempFirstNumber = random.Next(1, 100);
            int tempSecondNumber = random.Next(1, 100);
            tempQ.Question = $"What is [bold green]{tempFirstNumber}+{tempSecondNumber}[/] = ?";
            tempQ.Type = QuestionType.Addition;
            int ansRndSeed = random.Next(1, 4);
            for (int j = 0; j < 4; j++)
            {
                Answer option = (Answer)j;
                if (j == ansRndSeed)
                {
                    tempQ.Options.Add((option, $"[bold green]{tempFirstNumber + tempSecondNumber}[/]"));
                    tempQ.SelectedAnswer = option;
                }
                else
                {
                    tempQ.Options.Add((option, $"[bold green]{random.Next(tempFirstNumber, tempFirstNumber + tempSecondNumber - 1)}[/]"));
                }
            }
            QuestionsTable.Add(tempQ);
        }

        // Init 10 Subtraction Questions.
       for (int i = 0; i < 10; i++)
        {
            Questions tempQ = new Questions();
            int tempFirstNumber = random.Next(1, 100); 
            int tempSecondNumber = random.Next(tempFirstNumber, tempFirstNumber + 100);
            tempQ.Question = $"What is [bold green]{tempSecondNumber}-{tempFirstNumber}[/] = ?";
            tempQ.Type = QuestionType.Subtraction;
            int ansRndSeed = random.Next(1, 4);
            for (int j = 0; j < 4; j++)
            {
                Answer option = (Answer)j;
                if (j == ansRndSeed)
                {
                    tempQ.Options.Add((option, $"[bold green]{tempSecondNumber - tempFirstNumber}[/]"));
                    tempQ.SelectedAnswer = option;
                }
                else
                {
                    tempQ.Options.Add((option, $"[bold green]{random.Next(0, tempSecondNumber - tempFirstNumber - 1)}[/]"));
                }
            }
            QuestionsTable.Add(tempQ);
        } 
    }
}
