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
        if (++selectedCol > 2)
            selectedCol = 0;
        
        selectedItem = boardItems[selectedRow, selectedCol];
    }

    public void SelectNextItemLeft()
    {
        if (--selectedCol < 0)
            selectedCol = boardItems.GetLength(1);

        selectedItem = boardItems[selectedRow, selectedCol];
    }

    public void SelectNextItemUp()
    {
        if (--selectedRow < 0)
            selectedRow = boardItems.GetLength(0);

        selectedItem = boardItems[selectedRow, selectedCol];
    }

    public void SelectNextItemDown()
    {
        if (++selectedRow > 2)
            selectedRow = 0;

        selectedItem = boardItems[selectedRow, selectedCol];
    }

    public bool MarkItem(Player player)
    {
        if (selectedItem.IsMarked)
        {
            return false;
        }

        selectedItem.Mark = player.Marker;
        selectedItem.Select();

        return true;
    }
}
