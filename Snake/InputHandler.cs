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

    public ConsoleKeyInfo HandleInput()
    {
        do
        {
            key = Console.ReadKey(true);
        } while (Console.KeyAvailable && !possibleKeys.Contains(key.Key));

        return key;
    }
}
