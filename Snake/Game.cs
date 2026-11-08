namespace Snake;

public sealed class Game
{
    private readonly Board _board;
    private readonly Renderer _renderer;

    private bool gameOver = false;
    private ConsoleKey direction;

    public Game()
    {
        _board = new Board();
        _renderer = new Renderer(_board);
    }

    public void Run()
    {
        GameLoop();
    }

    private void GameLoop()
    {
        _renderer.Render(gameOver);
        while (!gameOver)
        {
            direction = InputHandler.HandleInput();
            while (!Console.KeyAvailable)
            {
                gameOver = _board.ChangeDirection(direction);
                _renderer.Render(gameOver);
            }
        }
    }
}
