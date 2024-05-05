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

    public bool IsGameOver { get; private set; }

    public string[][] Play(int row, int column, string player)
    {
        if (_board[row][column].Equals("") && (player.Equals("X") || player.Equals("O")))
        {
            _board[row][column] = player;
            IsGameOver = HasGameOver();
        }
        return _board;
    }

    private bool HasGameOver()
    {
        return _board.All(row => !row.Contains(""));
    }
}