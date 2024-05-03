namespace TicTacToeKata;

public class TicTacToe
{
    private readonly string[][] _board;

    public TicTacToe()
    {
        _board = new string[3][];
        for (int i = 0; i < _board.Length; i++)
        {
            _board[i] = ["", "", ""];
        }
    }

    public string[][] Play(int row, int column, string player)
    {
        if (_board[row][column].Equals(""))
        {
            _board[row][column] = player;
        }
        return _board;
    }
}