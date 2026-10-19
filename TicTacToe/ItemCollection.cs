namespace TicTacToe;

internal class ItemCollection
{
    private BoardItem[,] boardItems = new BoardItem[3,3];
    private int selectedRow = 0, selectedCol = 0;
    private BoardItem selectedItem;

    public ItemCollection()
    {
        for (int i = 0; i < boardItems.GetLength(0); i++)
        {
            for (int j = 0;  j < boardItems.GetLength(1); j++)
            {
                boardItems[i, j] = new BoardItem(i, j);
            }
        }

        this.selectedItem = boardItems[selectedRow, selectedCol];
    }

    public BoardItem[,] BoardItems => boardItems;
    public BoardItem SelectedItem => selectedItem;

    public void SelectNextItemRight()
    {
        selectedItem.IncreaseCol();
    }

    public void SelectNextItemLeft()
    {
        selectedItem.DecreaseCol();
    }

    public void SelectNextItemUp()
    {
        selectedItem.DecreaseRow();
    }

    public void SelectNextItemDown()
    {
        selectedItem.IncreaseRow();
    }

    public void MarkItem()
    {
        if (selectedItem.Selected)
        {
            return;
        }

        selectedItem.Select();
    }
}
