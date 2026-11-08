namespace Snake;

internal sealed class Position : IEquatable<Position>
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

    public void SetPosition(int pointX, int pointY)
    {
        this.pointX = pointX;
        this.pointY = pointY;
    }

    public void MoveRight()
    {
        this.pointY++;
    }

    public void MoveLeft()
    {
        this.pointY--;
    }

    public void MoveUp()
    {
        this.pointX--;
    }

    public void MoveDown()
    {
        this.pointX++;
    }

    public bool Equals(Position? other)
    {
        if (other is null)
            return false;

        if (this.pointX == other.PointX && this.pointY == other.PointY)
            return true;
        else
            return false;
    }
}
