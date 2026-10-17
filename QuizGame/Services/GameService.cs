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

    public double CalculatePoints(int userLives)
    {
        int correctAnswerPoint = 100;
        switch (userLives)
        {
            case 1:
                return 1 * correctAnswerPoint;
            case 2:
                return 1.5 * correctAnswerPoint;
            case 3:
                return 2 * correctAnswerPoint;
            default:
                return 0;
        }
    }

    public int CalculatePerfectGameBonus(int correctAnswers, int userLives)
    {
        int bonusPoints = 0;
        if (correctAnswers == 10)
        {
            bonusPoints += 200;
        }

        if (userLives == 3)
        {
            bonusPoints += 300;
        }

        return bonusPoints;
    }
}
