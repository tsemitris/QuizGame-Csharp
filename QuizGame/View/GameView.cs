using System.Diagnostics.Contracts;

namespace QuizGame.View;

public class GameView
{
    public void ShowIntroText()
    {
        Console.WriteLine("\nWelcome to Quiz-Time!");
        Console.WriteLine("Test your knowledge and see how many questions you can answer correctly!\n");
        ShowReadyMessage();
    }

    void ShowReadyMessage()
    {
        Console.WriteLine("Ready to challenge yourself?");
    }

    public int ReadUserLoadGameInput()
    {
        Console.WriteLine("Which save do you want to load?");

        int userChoice = 0;
        if (!int.TryParse(Console.ReadLine(), out userChoice))
        {
            InvalidChoice();
            return ReadUserLoadGameInput();
        }

        return userChoice;
    }

    public void PrintNoUserFound()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nNo user found!");
        Console.ResetColor();
    }

    public int PrintMenuOptions()
    {
        Console.WriteLine("[1] Start game \n[2] Load game \n[3] Game rules \n[4] Leaderboard \n[0] Exit");

        int userChoice = 0;
        if (!int.TryParse(Console.ReadLine(), out userChoice))
        {
            InvalidChoice();
            ShowReadyMessage();
            return PrintMenuOptions();
        }

        return userChoice;
    }

    public void InvalidChoice()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nPlease write a valid number!");
        Console.ResetColor();
    }

    public string ReadUserName()
    {
        Console.WriteLine("\nEnter your username:");

        return Console.ReadLine() ?? "";
    }

    public void ErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void PrintLeaderboardHeader()
    {
        Console.WriteLine("\nLeaderboard:");
    }
    public void PrintUserInfo(int index, User user)
    {
        Console.WriteLine($"[{index}] Name: {user.Name}, Score: {user.Points}, Last time played: {user.LastTimePlayed}");
    }

    public void ShowQuestion(string[] question, int questionIndex)
    {
        Console.WriteLine($"\nQuestion {questionIndex}: {question[0]}");

        for (int i = 1; i < 4; i++)
        {
            Console.WriteLine($"[{i}] {question[i]}");
        }

        Console.WriteLine("Enter your answer: ");
    }

    public int ReadUserAnswer(string[] question, int questionIndex)
    {
        int userChoice = 0;
        while (!int.TryParse(Console.ReadLine(), out userChoice) || !(userChoice > 0 && userChoice < 4))
        {
            InvalidChoice();
            ShowQuestion(question, questionIndex);
        }

        return userChoice;
    }

    public void CorrectAnswerMessage()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nCorrect!");
        Console.ResetColor();
    }

    public void WrongAnswerMessage(string[] question)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"\nWrong answer! \nThe correct answer was: {question[4]}");
        Console.ResetColor();
    }

    public void ShowUserPoints(double points)
    {
        Console.WriteLine($"Points: {points}pts");
    }
    public void ShowRemainingPointsAndLifes(User user)
    {
        Console.WriteLine($"Points: {user.Points}pts | Remaining lifes: {user.Lifes}/3");
    }

    public void ShowGameOver()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nGame over!");
        Console.ResetColor();
        Console.WriteLine("Better luck next time :D");
    }

    public void ShowVictoryScreen(User user, int bonusPoints)
    {
        double points = user.Points - bonusPoints;
        double totalPoints = points + bonusPoints;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nCongratulations!! You made it.");
        Console.ResetColor();

        Console.WriteLine($"Points: {points}pts + {bonusPoints} bonus points | Total points: {totalPoints}");
    }

    public int ShowEndMenu()
    {
        Console.WriteLine("\nMenu: \n[1] Play Again \n[9] Main menu \n[0] Exit");

        int userChoice = 0;
        if (!int.TryParse(Console.ReadLine(), out userChoice))
        {
            InvalidChoice();
            return ShowEndMenu();
        }

        return userChoice;
    }

    public int ShowGoToMainMenu()
    {
        Console.WriteLine("\nMain menu: \n[1] Go \n[0] Exit game");
        int userChoice = 0;
        if (!int.TryParse(Console.ReadLine(), out userChoice))
        {
            InvalidChoice();
            return ShowGoToMainMenu();
        }

        return userChoice;
    }
}
