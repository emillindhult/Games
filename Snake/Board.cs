namespace Snake;

internal sealed class Board
{
    private readonly string[,] _board;
    private readonly Snake _snake;
    private readonly Food _food;

    public Board()
    {
        _board = new string[15, 30];
        _snake = new Snake();
        _food = new Food();
    }
}
