namespace TicTacToe;

public class Board
{
    private ItemCollection _items;

    public Board()
    {
        _items = new ItemCollection();
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

    public void GameLoop()
    {
        Console.CursorVisible = false;
        while (true)
        {
            RenderBoard();
            ProcessInput();
        }
    }

    public void ProcessInput()
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

        _items.MarkItem();
    }
}
