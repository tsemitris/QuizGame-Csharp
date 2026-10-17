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

    public void startGame()
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

                // _gameView.ShowQuestion(_gameService.GetQuestion());
                break;
            case 2:
                // TODO Game rules
                break;
            case 3:
                int index = 1;
                foreach (User user in _usersService.OrderByDescending())
                {
                    _gameView.ShowLeaderboard(index, user);
                    index++;
                }

                break;
            case 0:
                break;
            default:
                _gameView.InvalidMenuChoice();
                break;
        }
    }
}
