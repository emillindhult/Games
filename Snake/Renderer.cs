using System.Text;

namespace Snake;

internal sealed class Renderer : IRenderer
{
    private readonly Board _board;
    private readonly StringBuilder frameBuffer;

    public Renderer(Board board)
    {
        _board = board;
        frameBuffer = new StringBuilder();
        Console.CursorVisible = false;
        Console.Clear();
    }

    public void Render()
    {
        frameBuffer.Clear();

        for (int i = 0; i < _board.Grid.GetLength(0); i++)
        {
            for (int j = 0; j < _board.Grid.GetLength(1); j++)
            {
                frameBuffer.Append(_board.Grid[i, j]);
            }
            frameBuffer.AppendLine();
        }
        Console.SetCursorPosition(0, 0);
        Console.Out.Write(frameBuffer);
        Thread.Sleep(250);
    }
}
