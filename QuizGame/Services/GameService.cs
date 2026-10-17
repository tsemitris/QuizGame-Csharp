using System.Globalization;

namespace QuizGame.Services;

public class GameService
{
    string[] questions = File.ReadAllLines("../../../questions.txt");
    List<int> showedQuestions = new List<int>();

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

    public void GetQuestion()
    {
        Random random = new Random();
        // int randomQuestionIndex = random.Next(1, questions.Length + 1);
        int randomQuestionIndex = random.Next(1, questions.Length);
        bool randomNumberExistance = showedQuestions.Contains(randomQuestionIndex);

        while (randomNumberExistance)
        {
            randomNumberExistance = showedQuestions.Contains(random.Next(1, questions.Length + 1));
        }

        showedQuestions.Add(randomQuestionIndex);
        Console.WriteLine(questions[randomQuestionIndex] + "\n");
    }
}
