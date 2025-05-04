namespace DotNETConsole.MathGame.DB;

using DotNETConsole.MathGame.Models;
using DotNETConsole.MathGame.Enums;

internal class DB
{
    internal List<Questions> QuestionsTable = new List<Questions>();
    internal List<Scores> ScoreTable = new List<Scores>();

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
            int result = tempFirstNumber + tempSecondNumber;
            for (int j = 0; j < 4; j++)
            {
                Answer option = (Answer)j;
                if (j == ansRndSeed)
                {
                    tempQ.Options.Add((option, $"[bold green]{result}[/]"));
                    tempQ.SelectedAnswer = option;
                }
                else
                {
                    int randomResult = random.Next(tempFirstNumber, tempFirstNumber + tempSecondNumber - 1);
                    if (randomResult == result)
                    {
                        randomResult += random.Next(1, 10);
                    }
                    tempQ.Options.Add((option, $"[bold green]{randomResult}[/]"));
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
            int result = tempSecondNumber - tempFirstNumber;
            for (int j = 0; j < 4; j++)
            {
                Answer option = (Answer)j;
                if (j == ansRndSeed)
                {
                    tempQ.Options.Add((option, $"[bold green]{result}[/]"));
                    tempQ.SelectedAnswer = option;
                }
                else
                {
                    int randomResult = random.Next(0, tempSecondNumber - tempFirstNumber + 1);
                    if (randomResult == result)
                    {
                        randomResult += random.Next(1, 10);
                    }
                    tempQ.Options.Add((option, $"[bold green]{randomResult}[/]"));
                }
            }
            QuestionsTable.Add(tempQ);
        }

        // Init 10 Multiplication Questions.
        for (int i = 0; i < 10; i++)
        {
            Questions tempQ = new Questions();
            int tempFirstNumber = random.Next(2, 20);
            int tempSecondNumber = random.Next(2, 20);
            tempQ.Question = $"What is [bold green]{tempSecondNumber}x{tempFirstNumber}[/] = ?";
            tempQ.Type = QuestionType.Multiplication;
            int ansRndSeed = random.Next(1, 4);
            int result = tempFirstNumber * tempSecondNumber;
            for (int j = 0; j < 4; j++)
            {
                Answer option = (Answer)j;
                if (j == ansRndSeed)
                {
                    tempQ.Options.Add((option, $"[bold green]{result}[/]"));
                    tempQ.SelectedAnswer = option;
                }
                else
                {
                    int randomResult = random.Next(tempFirstNumber, tempSecondNumber * 17);
                    if (randomResult == result)
                    {
                        randomResult += random.Next(1, 10);
                    }
                    tempQ.Options.Add((option, $"[bold green]{randomResult}[/]"));
                }
            }
            QuestionsTable.Add(tempQ);
        }

        // Init 10 Division Questions.
        for (int i = 0; i < 10; i++)
        {
            Questions tempQ = new Questions();
            int divisor = random.Next(2, 10);
            int dividend = random.Next(20, 100);

            //Adjusted dividend
            int remainder = dividend % divisor;
            if (remainder != 0)
            {
                dividend += divisor - remainder;
            }

            tempQ.Question = $"What is [bold green]{dividend}/{divisor}[/] = ?";
            tempQ.Type = QuestionType.Division;
            int ansRndSeed = random.Next(1, 4);
            int result = dividend / divisor;
            for (int j = 0; j < 4; j++)
            {
                Answer option = (Answer)j;
                if (j == ansRndSeed)
                {
                    tempQ.Options.Add((option, $"[bold green]{result}[/]"));
                    tempQ.SelectedAnswer = option;
                }
                else
                {
                    int randomResult = random.Next(1, result + 10);
                    if (randomResult == result)
                    {
                        randomResult += random.Next(1, 10);
                    }
                    tempQ.Options.Add((option, $"[bold green]{randomResult}[/]"));
                }
            }
            QuestionsTable.Add(tempQ);
        }
    }
}
