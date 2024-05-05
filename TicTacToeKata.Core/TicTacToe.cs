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
        var isFieldNotTaken = _board[row][column].Equals("");
        var isPlayerXOrO = player.Equals("X") || player.Equals("O");
        if (isFieldNotTaken && isPlayerXOrO)
        {
            _board[row][column] = player;
            IsGameOver = HasGameOver(_board[row]);
        }
        return _board;
    }

    private bool HasGameOver(string[] actualRow)
    {
        if (actualRow.All(field => field.Equals("X") || field.Equals("O")))
        {
            return true;
        }
        if (_board.All(row => !row.Contains("")))
        {
            return true;
        }

        return false;
    }
}