using System.Numerics;

namespace TicTacToe;

internal class BoardItem
{
    private bool isMarked = false;
    private int row;
    private int col;
    private string mark = " ";
    public string Mark
    {
        get => this.mark;
        set => this.mark = value;
    }

    public bool IsMarked => isMarked;
    public int Row => this.row;
    public int Col => this.col;

    public BoardItem(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public void Select()
    {
        isMarked = !isMarked;
    }
}
