using System;

namespace Snake;

internal sealed class Board
{
    public const string SnakeBody = "\u25A0";
    private const string HorizontalLine = "\u2500";
    private const string VerticalLine = "\u2502";
    private const string UpperLeftCorner = "\u250c";
    private const string UpperRightCorner = "\u2510";
    private const string LowerLeftCorner = "\u2514";
    private const string LowerRightCorner = "\u2518";

    private readonly string[,] _grid;
    private readonly Snake _snake;
    private readonly Food _food;

    public string[,] Grid => _grid;
    public Snake Snake => _snake;
    public Food Food => _food;

    public Board()
    {
        _grid = new string[15, 30];
        _snake = new Snake();
        _food = new Food();
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                if (i == 0 && j == 0)
                {
                    _grid[i, j] = UpperLeftCorner;
                }
                else if (i == 0 && j == _grid.GetLength(1) - 1)
                {
                    _grid[i, j] = UpperRightCorner;
                }
                else if (i == 0)
                {
                    _grid[i, j] = HorizontalLine;
                }
                else if (i == _grid.GetLength(0) - 1 && j == 0)
                {
                    _grid[i, j] = LowerLeftCorner;
                }
                else if (i == _grid.GetLength(0) - 1 && j == _grid.GetLength(1) - 1)
                {
                    _grid[i, j] = LowerRightCorner;
                }
                else if (i == _grid.GetLength(0) - 1)
                {
                    _grid[i, j] = HorizontalLine;
                }
                else if ((i != 0 || i != _grid.GetLength(0) - 1) && (j == 0 || j == _grid.GetLength(1) - 1))
                {
                    _grid[i, j] = VerticalLine;
                }
                else if (i == _snake.HeadStartPosition.PointX && j == _snake.HeadStartPosition.PointY)
                {
                    _grid[i, j] = SnakeBody;
                }
                else if (i == _snake.TailStartPosition.PointX && j == _snake.TailStartPosition.PointY)
                {
                    _grid[i, j] = SnakeBody;
                }
                else
                {
                    _grid[i, j] = " ";
                }
            }
        }
    }

    public void ChangeDirection(ConsoleKey direction)
    {
        _grid[_snake.Tail.PointX, _snake.Tail.PointY] = " ";

        switch (direction)
        {
            case ConsoleKey.UpArrow:
                _snake.MoveUp();
                break;
            case ConsoleKey.RightArrow:
                _snake.MoveRight();
                break;
            case ConsoleKey.DownArrow:
                _snake.MoveDown();
                break;
            case ConsoleKey.LeftArrow:
                _snake.MoveLeft();
                break;
        }

        foreach (var part in _snake.Body)
        {
            _grid[part.PointX, part.PointY] = SnakeBody;
        }
    }
}
