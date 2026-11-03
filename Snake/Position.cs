namespace Snake;

internal sealed class Position
{
    private int pointX;
    private int pointY;
    public int PointX => pointX;
    public int PointY => pointY;

    public Position(int pointX, int pointY)
    {
        this.pointX = pointX;
        this.pointY = pointY;
    }
}
