using System.Numerics;

namespace TicTacToe;

internal class BoardItem
{
    private bool selected = false;
    private int row;
    private int col;
    private string mark = " ";
    public string Mark
    {
        get => this.mark;
        set => this.mark = value;
    }

    public bool Selected => selected;
    public int Row => this.row;
    public int Col => this.col;

    public BoardItem(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public void IncreaseRow()
    {
        if (++row > 2)
            row = 0;
    }

    public void DecreaseRow()
    {
        if (--row < 0)
            row = 2;
    }

    public void IncreaseCol()
    {
        if (++col > 2)
            col = 0;
    }

    public void DecreaseCol()
    {
        if (--col < 0)
            col = 2;
    }

    public void Select()
    {
        selected = !selected;
    }
}
