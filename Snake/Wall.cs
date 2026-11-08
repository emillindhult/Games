namespace Snake;

internal sealed class Wall
{
    public Position Position { get; private set; }
    public WallType WallType { get; private set; }
    public string Unicode { get; }

    public Wall(Position position, WallType wallType, Dictionary<WallType, string> wallDict)
    {
        Position = position;
        WallType = wallType;
        Unicode = wallDict[wallType];
    }
}
