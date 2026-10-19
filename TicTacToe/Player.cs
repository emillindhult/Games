namespace TicTacToe;

internal class Player
{
    public string Name { get; private set; } = string.Empty;
    public string Marker { get; private set; } = string.Empty;

    public Player(string name, string marker)
    {
        Name = name;
        Marker = marker;
    }
}
