namespace Snake;

internal sealed class Renderer : IRenderer
{
    private readonly Board _board;

    public Renderer(Board board)
    {
        _board = board;
    }

    public void Render()
    {
        throw new NotImplementedException();
    }
}
