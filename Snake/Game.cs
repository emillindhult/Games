namespace Snake;

public sealed class Game
{
    private readonly Board _board;
    private readonly InputHandler _inputHandler;
    private readonly Renderer _renderer;

    public Game()
    {
        _board = new Board();
        _inputHandler = new InputHandler();
        _renderer = new Renderer();
    }

    public void Run()
    {
        SimulateMoving();
    }

    private void SimulateMoving()
    {
        _board.WriteSnakePosition();
    }
}
