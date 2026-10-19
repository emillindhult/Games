namespace TicTacToe;

public class Board
{
    private readonly ItemCollection _items;
    private readonly Player _player1;
    private readonly Player _player2;
    private Player currentPlayer;
    private Player? winner;

    public Board()
    {
        _items = new ItemCollection();
        _player1 = new Player("Player 1", "X");
        _player2 = new Player("Player 2", "O");
        currentPlayer = _player1;
    }

    public void GameLoop()
    {
        Console.CursorVisible = false;

        while (true)
        {
            RenderBoard();
            ProcessInput();
            winner = CheckForWinner();
            RenderBoard();

            if (winner is not null)
            {
                Console.WriteLine();
                Console.WriteLine("Congratulations!");
                Console.WriteLine($"Player {winner.Name} wins!");
                Console.ReadKey();
                ClearBoard();
                currentPlayer = _player1;
            }
        }
    }

    private void RenderBoard()
    {
        Console.Clear();
        Console.WriteLine(" -  -  - ");
        for (int i = 0; i < _items.BoardItems.GetLength(0); i++)
        {
            for (int j = 0; j < _items.BoardItems.GetLength(1); j++)
            {
                if (_items.SelectedItem.Row == i && _items.SelectedItem.Col == j)
                {
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(_items.BoardItems[i, j].Mark);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                    continue;
                }
                Console.Write("|");
                Console.Write(_items.BoardItems[i, j].Mark);
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(" -  -  - ");
        }
    }

    private void ProcessInput()
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.RightArrow)
            {
                _items.SelectNextItemRight();
                return;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                _items.SelectNextItemLeft();
                return;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                _items.SelectNextItemUp();
                return;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                _items.SelectNextItemDown();
                return;
            }

        } while (key.Key != ConsoleKey.Enter);

        if (!_items.MarkItem(currentPlayer))
        {
            return;
        }

        if (currentPlayer == _player1)
        {
            currentPlayer = _player2;
        }
        else
        {
            currentPlayer = _player1;
        }
    }

    private Player? CheckForWinner()
    {
        if (_items.BoardItems[0, 0].Mark == _items.BoardItems[0, 1].Mark &&
            _items.BoardItems[0, 1].Mark == _items.BoardItems[0, 2].Mark &&
            _items.BoardItems[0, 0].Mark != " ")
        {
            return _items.BoardItems[0, 0].Mark == _player1.Marker ? _player1 : _player2;
        }
        else if (_items.BoardItems[1, 0].Mark == _items.BoardItems[1, 1].Mark &&
            _items.BoardItems[1, 1].Mark == _items.BoardItems[1, 2].Mark &&
            _items.BoardItems[1, 0].Mark != " ")
        {
            return _items.BoardItems[1, 0].Mark == _player1.Marker ? _player1 : _player2;
        }
        else if (_items.BoardItems[2, 0].Mark == _items.BoardItems[2, 1].Mark &&
            _items.BoardItems[2, 1].Mark == _items.BoardItems[2, 2].Mark &&
            _items.BoardItems[2, 0].Mark != " ")
        {
            return _items.BoardItems[2, 0].Mark == _player1.Marker ? _player1 : _player2;
        }
        else if (_items.BoardItems[0, 0].Mark == _items.BoardItems[1, 0].Mark &&
            _items.BoardItems[1, 0].Mark == _items.BoardItems[2, 0].Mark &&
            _items.BoardItems[0, 0].Mark != " ")
        {
            return _items.BoardItems[0, 0].Mark == _player1.Marker ? _player1 : _player2;
        }
        else if (_items.BoardItems[0, 1].Mark == _items.BoardItems[1, 1].Mark &&
            _items.BoardItems[1, 1].Mark == _items.BoardItems[2, 1].Mark &&
            _items.BoardItems[0, 1].Mark != " ")
        {
            return _items.BoardItems[0, 1].Mark == _player1.Marker ? _player1 : _player2;
        }
        else if (_items.BoardItems[0, 2].Mark == _items.BoardItems[1, 2].Mark &&
            _items.BoardItems[1, 2].Mark == _items.BoardItems[2, 2].Mark &&
            _items.BoardItems[0, 2].Mark != " ")
        {
            return _items.BoardItems[0, 2].Mark == _player1.Marker ? _player1 : _player2;
        }
        else if (_items.BoardItems[0, 0].Mark == _items.BoardItems[1, 1].Mark &&
            _items.BoardItems[1, 1].Mark == _items.BoardItems[2, 2].Mark &&
            _items.BoardItems[0, 0].Mark != " ")
        {
            return _items.BoardItems[0, 0].Mark == _player1.Marker ? _player1 : _player2;
        }
        else if (_items.BoardItems[2, 0].Mark == _items.BoardItems[1, 1].Mark &&
            _items.BoardItems[1, 1].Mark == _items.BoardItems[0, 2].Mark &&
            _items.BoardItems[2, 0].Mark != " ")
        {
            return _items.BoardItems[2, 0].Mark == _player1.Marker ? _player1 : _player2;
        }
        else
        {
            return null;
        }
    }

    private void ClearBoard()
    {
        _items.ClearBoard();
    }
}
