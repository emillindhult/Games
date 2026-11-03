namespace Snake;

internal sealed class Snake
{
    private readonly List<Position> _body;
    private readonly Position _head;
    private readonly Position _tail;

    public Snake()
    {
        _head = new Position(7, 15);
        _tail = new Position(7, 14);
        _body = [_head, _tail];
    }
}
