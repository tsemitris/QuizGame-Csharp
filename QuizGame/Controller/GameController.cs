using System.ComponentModel;
using QuizGame.Services;
using QuizGame.View;

namespace QuizGame;

public class GameController
{
    private readonly GameService _gameService;
    private readonly GameView _gameView;
    private readonly UsersService _usersService;

    public GameController(GameService gameService, GameView gameView, UsersService usersService)
    {
        _gameService = gameService;
        _gameView = gameView;
        _usersService = usersService;
    }

    public void StartGame()
    {
        _gameView.ShowIntroText();

        int userChoice = _gameView.PrintMenuOptions();

        switch (userChoice)
        {
            case 1:
                string userName = _gameView.ReadUserName();

                while (!_gameService.ValidateUserName(userName))
                {
                    _gameView.ErrorMessage("Username can't be empty, please try again!");
                    userName = _gameView.ReadUserName();
                }

                _usersService.AddUser(userName);

                PlayGame(userName);
                break;
            case 2:
                LoadGame();
                break;
            case 3:
                _gameView.ShowGameRules();
                int userChoiceGameRules = _gameView.ShowGoToMainMenu();

                switch (userChoiceGameRules)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        break;
                    default:
                        _gameView.InvalidChoice();
                        break;
                }
                break;
            case 4:
                ShowLeaderboard();
                break;
            case 0:
                break;
            default:
                _gameView.InvalidChoice();
                break;
        }
    }

    void ShowEndMenu(string userName)
    {
        int userChoice = _gameView.ShowEndMenu();

        switch (userChoice)
        {
            case 1:
                PlayGame(userName);
                break;
            case 9:
                StartGame();
                break;
            case 0:
                break;
            default:
                _gameView.InvalidChoice();
                break;
        }
    }

    void PlayGame(string userName)
    {
        Guid userId = _usersService.GetUserId(userName);
        _usersService.ResetUser(userId);

        int correctAnswers = 0;
        for (int i = 1; i <= 10; i++)
        {
            string[] question = _gameService.GetQuestion();
            _gameView.ShowQuestion(question, i);
            int userInput = _gameView.ReadUserAnswer(question, i);

            bool validatedUserAnswer = _gameService.ValidateUserAnswer(question, userInput);

            int userLives = _usersService.GetUserLives(userId);
            if (userLives > 1)
            {
                if (validatedUserAnswer)
                {
                    _gameView.CorrectAnswerMessage();

                    double correctAnswerPoints = _gameService.CalculatePoints(userLives);
                    _usersService.UpdateUserPoints(userId, correctAnswerPoints);

                    _gameView.ShowUserPoints(_usersService.GetUserPoints(userId));
                    correctAnswers++;
                }
                else
                {
                    _gameView.WrongAnswerMessage(question);
                    _usersService.UpdateUserLife(userId);
                    _gameView.ShowRemainingPointsAndLives(_usersService.GetUserById(userId));
                }
            }
            else
            {
                _gameView.WrongAnswerMessage(question);
                _gameView.ShowGameOver();
                ShowEndMenu(userName);
                break;
            }
        }

        int bonusPoints = _gameService.CalculatePerfectGameBonus(correctAnswers, _usersService.GetUserLives(userId));
        _usersService.UpdateUserPoints(userId, bonusPoints);
        _gameView.ShowVictoryScreen(_usersService.GetUserById(userId), bonusPoints);
        ShowEndMenu(userName);
    }

    void LoadGame()
    {
        List<User> users = _usersService.OrderByDescending();

        if (users.Count != 0)
        {
            _gameView.ShowLoadGameHeader();

            int index = 1;
            foreach (User user in users)
            {
                _gameView.PrintUserInfo(index, user);
                index++;
            }

            int userChoice = _gameView.ReadUserLoadGameInput();

            string userName = users[userChoice - 1].Name;
            PlayGame(userName);
        }
        else
        {
            _gameView.PrintNoUserFound();
            StartGame();
        }
    }

    void ShowLeaderboard()
    {
        List<User> users = _usersService.OrderByDescending();
        if (users.Count == 0)
        {
            _gameView.PrintNoUserFound();
            StartGame();
        }
        else
        {
            _gameView.PrintLeaderboardHeader();

            int index = 1;
            foreach (User user in users)
            {
                _gameView.PrintUserInfo(index, user);
                index++;
            }

            int userChoice = _gameView.ShowGoToMainMenu();
            switch (userChoice)
            {
                case 1:
                    StartGame();
                    break;
                case 0:
                    break;
                default:
                    _gameView.InvalidChoice();
                    break;
            }

        }
    }
}
