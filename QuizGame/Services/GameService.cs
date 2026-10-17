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

    public string[] GetQuestion()
    {
        Random random = new Random();
        int randomQuestionIndex = random.Next(1, questions.Length + 1);
        bool randomNumberExistance = showedQuestions.Contains(randomQuestionIndex);

        while (randomNumberExistance)
        {
            randomQuestionIndex = random.Next(1, questions.Length + 1);
            randomNumberExistance = showedQuestions.Contains(randomQuestionIndex);
        }

        showedQuestions.Add(randomQuestionIndex);
        string[] answers = questions[randomQuestionIndex].Split(';');

        return answers;
    }

    public bool ValidateUserAnswer(string[] answers, int userAnswer)
    {
        if (answers[userAnswer] == answers[4])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
