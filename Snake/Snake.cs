namespace Snake;

internal sealed class Snake
{
    private readonly Position _headStartPosition = new(7, 15);
    private readonly Position _tailStartPosition = new(7, 14);

    public Position HeadStartPosition => _headStartPosition;
    public Position TailStartPosition => _tailStartPosition;

    private Direction direction;
    public Direction Direction => direction;

    private readonly List<Position> _body;
    private readonly Position _head;
    private readonly Position _tail;

    public List<Position> Body => _body;
    public Position Head => _head;
    public Position Tail => _tail;

    public ConsoleColor Color { get; } = ConsoleColor.White;

    public Snake()
    {
        direction = Direction.Right;
        _head = _headStartPosition;
        _tail = _tailStartPosition;
        _body = [_head, _tail];
    }

    public void MoveRight()
    {
        if (direction is Direction.Left)
        {
            MoveLeft();
            return;
        }

        int tempX = _head.PointX;
        int tempY = _head.PointY;

        _head.MoveRight();

        for (int i = 1; i < _body.Count; i++)
        {
            _body[i].SetPosition(tempX, tempY);
        }

        direction = Direction.Right;
    }

    public void MoveLeft()
    {
        if (direction is Direction.Right)
        {
            MoveRight();
            return;
        }

        int tempX = _head.PointX;
        int tempY = _head.PointY;

        _head.MoveLeft();

        for (int i = 1; i < _body.Count; i++)
        {
            _body[i].SetPosition(tempX, tempY);
        }

        direction = Direction.Left;
    }

    public void MoveUp()
    {
        if (direction is Direction.Down)
        {
            MoveDown();
            return;
        }

        int tempX = _head.PointX;
        int tempY = _head.PointY;

        _head.MoveUp();

        for (int i = 1; i < _body.Count; i++)
        {
            _body[i].SetPosition(tempX, tempY);
        }

        direction = Direction.Up;
    }

    public void MoveDown()
    {
        if (direction is Direction.Up)
        {
            MoveUp();
            return;
        }

        int tempX = _head.PointX;
        int tempY = _head.PointY;

        _head.MoveDown();

        for (int i = 1; i < _body.Count; i++)
        {
            _body[i].SetPosition(tempX, tempY);
        }

        direction = Direction.Down;
    }
}
