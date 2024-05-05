using System.Runtime.CompilerServices;

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
            IsGameOver = HasGameOver(_board[row], _board);
        }
        return _board;
    }

    private bool HasGameOver(string[] actualRow, string[][] actualBoard)
    {
        return HasGameOverWhenAllFieldsAreTakenByAPlayerInARow(actualRow) || 
               HasGameOverWhenAllFieldsAreTaken() || 
               HasGameOverWhenAllFieldsInAColumnAreTakenByAPlayer(actualBoard) || 
               HasGameOverWhenAPlayerTakeAllFieldsInADescendentDiagonal(actualBoard) || HasGameOverWhenAPlayerTakeAllFieldsInAAscendantDiagonal(actualBoard);
    }

    private static bool HasGameOverWhenAllFieldsAreTakenByAPlayerInARow(string[] actualRow)
    {
        return actualRow.All(field => field.Equals("X") || field.Equals("O"));
    }

    private bool HasGameOverWhenAllFieldsAreTaken()
    {
        return _board.All(row => !row.Contains(""));
    }

    private bool HasGameOverWhenAllFieldsInAColumnAreTakenByAPlayer(string[][] actualBoard)
    {
        for (int row = 0; row < actualBoard.Length - 2; row++)
        {
            for (int column = 0; column < actualBoard[0].Length; column++)
            {
                var hasPlayerXWonTheGame = actualBoard[row][column].Equals("X") && 
                              actualBoard[row + 1][column].Equals("X") && 
                              actualBoard[row + 2][column].Equals("X");
                var hasPlayerOWonTheGame = actualBoard[row][column].Equals("O") && 
                              actualBoard[row + 1][column].Equals("O") && 
                              actualBoard[row + 2][column].Equals("O");
                var hasAnyPlayerWonTheGame = hasPlayerXWonTheGame || hasPlayerOWonTheGame;
                
                if (hasAnyPlayerWonTheGame)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool HasGameOverWhenAPlayerTakeAllFieldsInADescendentDiagonal(string[][] actualBoard)
    {
        for (int row = 0; row < actualBoard.Length - 2; row++)
        {
            for (int column = 0; column < actualBoard[0].Length - 2; column++)
            {
                var hasPlayerXWonTheGame = actualBoard[row][column].Equals("X") && 
                              actualBoard[row + 1][column + 1].Equals("X") && 
                              actualBoard[row + 2][column + 2].Equals("X");
                var hasPlayerOWonTheGame = actualBoard[row][column].Equals("O") && 
                              actualBoard[row + 1][column + 1].Equals("O") && 
                              actualBoard[row + 2][column + 2].Equals("O");
                var hasAnyPlayerWonTheGame = hasPlayerXWonTheGame || hasPlayerOWonTheGame;
                
                if (hasAnyPlayerWonTheGame)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool HasGameOverWhenAPlayerTakeAllFieldsInAAscendantDiagonal(string[][] actualBoard)
    {
        for (int row = actualBoard.Length - 1; row > actualBoard.Length - 2; row--)
        {
            for (int column = 0; column < actualBoard[0].Length - 2; column++)
            {
                if (actualBoard[row][column].Equals("X") &&
                    actualBoard[row - 1][column + 1].Equals("X") &&
                    actualBoard[row - 2][column + 2].Equals("X") ||
                    actualBoard[row][column].Equals("O") &&
                    actualBoard[row - 1][column + 1].Equals("O") &&
                    actualBoard[row - 2][column + 2].Equals("O"))
                {
                    return true;
                }
            }
        }
        return false;
    }
}