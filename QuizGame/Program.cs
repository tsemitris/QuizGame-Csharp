using QuizGame.Services;
using QuizGame.View;

namespace QuizGame;

class Program
{
    static void Main(string[] args)
    {
        GameService gameService = new GameService();
        GameView gameView = new GameView();
        GameController gameController = new GameController(gameService, gameView);

        gameController.startGame();
    }
}
