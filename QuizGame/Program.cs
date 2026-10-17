using QuizGame.Services;
using QuizGame.View;

namespace QuizGame;

class Program
{
    static void Main(string[] args)
    {
        GameService gameService = new GameService();
        GameView gameView = new GameView();
        UsersService usersService = new UsersService();


        GameController gameController = new GameController(gameService, gameView, usersService);

        gameController.startGame();
    }
}
