namespace Snake;

internal sealed class Food
{
    private readonly Position _startPosition;
    private readonly Position _position;
    public Position Position => _position;
    public ConsoleColor Color { get; } = ConsoleColor.Red;
    private readonly Random random = new();

    public Food()
    {
        _startPosition = new Position(random.Next(0, 16), random.Next(0, 31));
        _position = _startPosition;
    }

    public void GenerateFood()
    {

    }
}
