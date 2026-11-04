using System;

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

    // DELETE THIS LATER
    public void WriteSnakePosition(ConsoleKeyInfo key)
    {
        if (key.Key is ConsoleKey.UpArrow)
        {
            _snake.MoveUp();
        }
        else if (key.Key is ConsoleKey.RightArrow || key.Key is ConsoleKey.None)
        {
            _snake.MoveRight();
        }
        else if (key.Key is ConsoleKey.DownArrow)
        {
            _snake.MoveDown();
        }
        else if (key.Key is ConsoleKey.LeftArrow)
        {
            _snake.MoveLeft();
        }

        for (int j = 0; j < _snake.Body.Count; j++)
        {
            Console.WriteLine(j);
            Console.WriteLine($"x: {_snake.Body[j].PointX} y: {_snake.Body[j].PointY}");
        }
        Task.Delay(500).Wait();
    }
}
