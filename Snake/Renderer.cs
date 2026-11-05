namespace Snake;

internal sealed class Renderer : IRenderer
{


    private readonly Board _board;
    private readonly Snake _snake;
    private readonly Food _food;

    public Renderer(Board board)
    {
        _board = board;
        _snake = _board.Snake;
        _food = _board.Food;
    }

    public void Render()
    {
        Console.CursorVisible = false;
        Console.Clear();
        for (int i = 0; i < _board.Grid.GetLength(0); i++)
        {
            for (int j = 0; j < _board.Grid.GetLength(1); j++)
            {
                Console.Write(_board.Grid[i, j]);
            }
            Console.WriteLine();
        }
    }
}
