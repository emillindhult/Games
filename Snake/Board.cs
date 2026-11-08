using System;

namespace Snake;

internal sealed class Board
{
    private readonly ConsoleKey[] _possibleKeys =
    [
        ConsoleKey.UpArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.LeftArrow
    ];

    private readonly Dictionary<WallType, string> Walls = new()
    {
        { WallType.Horizontal,  HorizontalLine },
        { WallType.Vertical, VerticalLine },
        { WallType.LowerLeftCorner, LowerLeftCorner },
        { WallType.LowerRightCorner, LowerRightCorner },
        { WallType.UpperLeftCorner, UpperLeftCorner },
        { WallType.UpperRightCorner, UpperRightCorner }
    };

    public const string SnakeBody = "\u25A0";
    private const string FoodBody = "\u25A0";
    private const string HorizontalLine = "\u2500";
    private const string VerticalLine = "\u2502";
    private const string UpperLeftCorner = "\u250c";
    private const string UpperRightCorner = "\u2510";
    private const string LowerLeftCorner = "\u2514";
    private const string LowerRightCorner = "\u2518";

    private readonly List<Wall> _walls = [];
    private readonly List<Position> _wallPositions = [];
    private readonly Random _random = new();
    private readonly string[,] _grid;
    private readonly Snake _snake;
    private readonly Food _food;

    public string[,] Grid => _grid;
    public Snake Snake => _snake;
    public Food Food => _food;

    public Board()
    {
        _grid = new string[16, 31];
        _snake = new Snake();
        _food = new Food();
        InitializeGrid();
        PopulateWallPositions();
        GenerateFood();
    }

    private void PopulateWallPositions()
    {
        foreach (var wall in _walls)
        {
            _wallPositions.Add(wall.Position);
        }
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                if (i == 0 && j == 0)
                {
                    _walls.Add(new Wall(new Position(i, j), WallType.UpperLeftCorner, Walls));
                    _grid[i, j] = UpperLeftCorner;
                }
                else if (i == 0 && j == _grid.GetLength(1) - 1)
                {
                    _walls.Add(new Wall(new Position(i, j), WallType.UpperRightCorner, Walls));
                    _grid[i, j] = UpperRightCorner;
                }
                else if (i == 0)
                {
                    _walls.Add(new Wall(new Position(i, j), WallType.Horizontal, Walls));
                    _grid[i, j] = HorizontalLine;
                }
                else if (i == _grid.GetLength(0) - 1 && j == 0)
                {
                    _walls.Add(new Wall(new Position(i, j), WallType.LowerLeftCorner, Walls));
                    _grid[i, j] = LowerLeftCorner;
                }
                else if (i == _grid.GetLength(0) - 1 && j == _grid.GetLength(1) - 1)
                {
                    _walls.Add(new Wall(new Position(i, j), WallType.LowerRightCorner, Walls));
                    _grid[i, j] = LowerRightCorner;
                }
                else if (i == _grid.GetLength(0) - 1)
                {
                    _walls.Add(new Wall(new Position(i, j), WallType.Horizontal, Walls));
                    _grid[i, j] = HorizontalLine;
                }
                else if ((i != 0 || i != _grid.GetLength(0) - 1) && (j == 0 || j == _grid.GetLength(1) - 1))
                {
                    _walls.Add(new Wall(new Position(i, j), WallType.Vertical, Walls));
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

    private bool CheckForCollision()
    {
        if (_wallPositions.Contains(_snake.Head))
        {
            return true;
        }

        return false;
    }

    public bool ChangeDirection(ConsoleKey direction)
    {
        if (CheckForCollision())
        {
            return true;
        }

        _grid[_snake.Tail.PointX, _snake.Tail.PointY] = " ";

        if (!_possibleKeys.Contains(direction))
        {
            if (_snake.Direction.Equals(Direction.Up))
            {
                _snake.MoveUp();
            }
            else if (_snake.Direction.Equals(Direction.Right))
            {
                _snake.MoveRight();
            }
            else if (_snake.Direction.Equals(Direction.Down))
            {
                _snake.MoveDown();
            }
            else if (_snake.Direction.Equals(Direction.Left))
            {
                _snake.MoveLeft();
            }
        }

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

        return false;
    }

    public void GenerateFood()
    {
        while (_snake.Body.Contains(_food.Position))
        {
            _food.Position.SetPosition(_random.Next(1, 15), _random.Next(1, 30));
        }

        _grid[_food.Position.PointX, _food.Position.PointY] = FoodBody;
    }
}
