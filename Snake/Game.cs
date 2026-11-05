namespace Snake;

public sealed class Game
{
    private readonly Board _board;
    private readonly InputHandler _inputHandler;
    private readonly Renderer _renderer;

    private bool gameOver = false;
    private ConsoleKeyInfo direction;

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
        while (!gameOver)
        {
            while (!Console.KeyAvailable)
            {
                // _board.WriteSnakePosition(direction);
                _renderer.Render();
            }
            direction = _inputHandler.HandleInput();
        }
    }
}
