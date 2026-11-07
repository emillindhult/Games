namespace Snake;

internal sealed class InputHandler
{
    private ConsoleKeyInfo key;
    private readonly ConsoleKey[] possibleKeys =
    [
        ConsoleKey.UpArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.LeftArrow
    ];

    public InputHandler()
    {
    }

    public ConsoleKey HandleInput()
    {
        do
        {
            key = Console.ReadKey(true);
        } while (!possibleKeys.Contains(key.Key));

        return key.Key;
    }
}
