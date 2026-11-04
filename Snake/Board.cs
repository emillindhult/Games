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
    public void WriteSnakePosition()
    {
        for (int i = 0; i < 6; i++)
        {
            foreach (var position in _snake.Body)
            {
                Console.WriteLine($"x: {position.PointX} y: {position.PointY}");
            }
            if (i == 2)
            {
                _snake.MoveDown();
                continue;
            }
            if (i == 4)
            {
                _snake.MoveUp();
                continue;
            }
            _snake.MoveRight();
            Thread.Sleep(1000);
        }
    }
}
