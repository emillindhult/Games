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

    public void ChangePosition(int pointX, int pointY)
    {
        this.pointX = pointX;
        this.pointY = pointY;
    }

    public void MoveRight()
    {
        this.pointX++;
    }

    public void MoveLeft()
    {
        this.pointX--;
    }

    public void MoveUp()
    {
        this.pointY--;
    }

    public void MoveDown()
    {
        this.pointY++;
    }
}
