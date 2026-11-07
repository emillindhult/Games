namespace Snake;

public sealed class Game
{
    private readonly Board _board;
    private readonly InputHandler _inputHandler;
    private readonly Renderer _renderer;

    private bool gameOver = false;
    private ConsoleKey direction;

    public Game()
    {
        _board = new Board();
        _inputHandler = new InputHandler();
        _renderer = new Renderer(_board);
    }

    public void Run()
    {
        GameLoop();
    }

    private void GameLoop()
    {
        _renderer.Render();
        while (!gameOver)
        {
            direction = _inputHandler.HandleInput();
            while (!Console.KeyAvailable)
            {
                _board.ChangeDirection(direction);
                _renderer.Render();
            }
        }
    }
}
