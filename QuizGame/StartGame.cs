using System.Runtime.InteropServices;

namespace QuizGame;

public class StartGame
{
    public void ShowMenu()
    {

        Console.WriteLine("Welcome to Quiz-Time!");
        Console.WriteLine("Test your knowledge and see how many questions you can answer correctly!\n");
        Console.WriteLine("Ready to challenge yourself?");

        PrintStartMenu();
    }

    void PrintStartMenu()
    {
        Console.WriteLine("[1] Start game \n[2] Game rules \n[3] High Scores \n[0] Exit");

        if (int.TryParse(Console.ReadLine(), out int userChoice))
        {
            switch (userChoice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 0:
                    break;
                default:
                    InvalidMenuChoice();
                    break;
            }
        }
        else
        {
            InvalidMenuChoice();
        }
    }

    void InvalidMenuChoice()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nPlease write a valid number!");
        Console.ResetColor();

        Console.WriteLine("\nReady to challenge yourself?");
        PrintStartMenu();
    }

}
