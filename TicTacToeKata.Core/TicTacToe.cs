namespace TicTacToeKata;

public class TicTacToe
{
    private readonly string[][] _board;

    public TicTacToe()
    {
        _board = new string[3][];
        for (int i = 0; i < _board.Length; i++)
        {
            _board[i] = new string[3];
        }
    }

    public string[][] Play(int row, int column, string player)
    {
        return _board;
    }
}