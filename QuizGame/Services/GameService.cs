namespace QuizGame.Services;

public class GameService
{
    string[] questions = File.ReadAllLines("../../../questions.txt");

    public bool ValidateUserName(string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
