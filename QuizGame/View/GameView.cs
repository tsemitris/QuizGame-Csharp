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

    public void ShowLoadGameHeader()
    {
        Console.WriteLine("\nLoad game:");
    }

    public int ReadUserLoadGameInput()
    {
        Console.WriteLine("\nWhich save do you want to load?");
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
    public void ShowRemainingPointsAndLives(User user)
    {
        Console.WriteLine($"Points: {user.Points}pts | Remaining Lives: {user.Lives}/3");
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

    public void ShowGameRules()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nQuiz-time - Game rules");
        Console.ResetColor();

        Console.WriteLine("Test your knowledge, answer questions and earn points!");

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nHow to play:");
        Console.ResetColor();

        Console.WriteLine("1. Enter your username to start the game.");
        Console.WriteLine("2. Answer 10 multiple-choice questions..");
        Console.WriteLine("3. Each question has 3 possible answers. Choose the correct answer by entering 1, 2, or 3.");
        Console.WriteLine("4. You start the game with 3 lives.");
        Console.WriteLine("5. Every incorrect answer costs you 1 life.");
        Console.WriteLine("5. Try to answer as many questions correctly as possible before losing all your lives!");

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nScoring System:");
        Console.ResetColor();

        Console.WriteLine("- Correct answers earn you points.");
        Console.WriteLine("- The more lives you have left, the higher your potential score.");
        Console.WriteLine("- Complete all 10 questions with all 3 lives remaining to earn a special bonus!");

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nHigh Scores:");
        Console.ResetColor();

        Console.WriteLine("Your score will be recorded and displayed on the High Scores leaderboard. Compete for the highest score and see how you rank against other players!");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nGood luck, and have fun!");
        Console.ResetColor();
    }
}
