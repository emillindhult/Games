namespace TicTacToe;

public interface IGameLoop
{
    ConsoleKeyInfo ProcessInput();
    void UpdateState();
    void Render();
}
