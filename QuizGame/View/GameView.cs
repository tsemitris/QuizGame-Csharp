namespace QuizGame.View;

public class GameView
{
    public void ShowIntroText()
    {
        Console.WriteLine("Welcome to Quiz-Time!");
        Console.WriteLine("Test your knowledge and see how many questions you can answer correctly!\n");
        ShowReadyMessage();
    }

    void ShowReadyMessage()
    {
        Console.WriteLine("Ready to challenge yourself?");
    }

    public int PrintMenuOptions()
    {
        Console.WriteLine("[1] Start game \n[2] Game rules \n[3] Leaderboard \n[0] Exit");

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

    public void ShowLeaderboard(int index, User user)
    {
        Console.WriteLine($"[{index}] Name: {user.Name}, Score: {user.Score}, Last time played: {user.LastTimePlayed}");
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
        Console.WriteLine("Correct!");
        Console.ResetColor();
    }

    public void WrongAnswerMessage(string[] question)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"\nWrong answer! \nThe correct answer was: {question[4]}");
        Console.ResetColor();
    }
}
