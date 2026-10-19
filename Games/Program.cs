using TicTacToe;

namespace Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            board.GameLoop();
        }
    }
}
