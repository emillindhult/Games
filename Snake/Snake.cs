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
    private Position _tail;

    public List<Position> Body => _body;
    public Position Head => _head;
    public Position Tail => _tail;

    private readonly Queue<Position> eatenFood = [];
    private Position? currentFood;
    private bool hasEaten = false;

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

        if (eatenFood.Count > 0)
        {
            if (eatenFood.Peek().Equals(_tail))
            {
                currentFood = eatenFood.Dequeue();
            }
        }

        int headX = _head.PointX;
        int headY = _head.PointY;

        _head.MoveRight();

        RepositionBody(headX, headY);

        if (currentFood != null)
        {
            _body.Add(new Position(currentFood.PointX, currentFood.PointY));
            _tail = _body[^1];
            currentFood = null;
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

        if (eatenFood.Count > 0)
        {
            if (eatenFood.Peek().Equals(_tail))
            {
                currentFood = eatenFood.Dequeue();
            }
        }

        int headX = _head.PointX;
        int headY = _head.PointY;

        _head.MoveLeft();

        RepositionBody(headX, headY);

        if (currentFood != null)
        {
            _body.Add(new Position(currentFood.PointX, currentFood.PointY));
            _tail = _body[^1];
            currentFood = null;
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

        if (eatenFood.Count > 0)
        {
            if (eatenFood.Peek().Equals(_tail))
            {
                currentFood = eatenFood.Dequeue();
            }
        }

        int headX = _head.PointX;
        int headY = _head.PointY;

        _head.MoveUp();

        RepositionBody(headX, headY);

        if (currentFood != null)
        {
            _body.Add(new Position(currentFood.PointX, currentFood.PointY));
            _tail = _body[^1];
            currentFood = null;
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

        if (eatenFood.Count > 0)
        {
            if (eatenFood.Peek().Equals(_tail))
            {
                currentFood = eatenFood.Dequeue();
            }
        }

        int headX = _head.PointX;
        int headY = _head.PointY;

        _head.MoveDown();

        RepositionBody(headX, headY);

        if (currentFood != null)
        {
            _body.Add(new Position(currentFood.PointX, currentFood.PointY));
            _tail = _body[^1];
            currentFood = null;
        }

        direction = Direction.Down;
    }

    private void RepositionBody(int headX, int headY)
    {
        for (int i = 1; i < _body.Count; i++)
        {
            int tempX = _body[i].PointX;
            int tempY = _body[i].PointY;
            _body[i].SetPosition(headX, headY);
            headX = tempX;
            headY = tempY;
        }
    }

    public void EatFood(Food food)
    {
        eatenFood.Enqueue(new Position(food.Position.PointX, food.Position.PointY));
    }

    //public void EatFood(int pointX, int pointY)
    //{
    //    eatenFood.Add()
    //}
}
