namespace Snake;

internal sealed class InputHandler
{
    public static ConsoleKey HandleInput() => Console.ReadKey(true).Key;
}
