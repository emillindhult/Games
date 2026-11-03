using TicTacToe;

namespace GameCenter;

internal class Program
{
    static void Main(string[] args)
    {
        //var board = new Board();
        //board.GameLoop();

        List<int> nums = [1, 2];

        foreach (int x in nums)
        {
            Console.WriteLine(x);
        }

        nums.Append(3);
    }
}
