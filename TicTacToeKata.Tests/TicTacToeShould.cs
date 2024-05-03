namespace TicTacToe.Tests;

public class TicTacToeShould
{
    /*
     * a game is over when all fields in a row are taken by a player.
     * players take turns taking fields until the game is over.
     * a game is over when all fields in a diagonal are taken by a player.
     * a game is over when all fields are taken.
     * there are two players in the game (X and O).
     * _a game has nine fields in a 3x3 grid_.
     * a game is over when all fields in a column are taken by a player.
     * a player can take a field if not already taken.
     * */

    [Fact]
    public void have_a_board_with_nine_fields()
    {
        // Arrange
        var ticTacToe = new TicTacToeKata.TicTacToe();
        var expected = 9;
        
        // Act
        var board = ticTacToe.Play(0, 0, "X");
        var actual = board.Length * board[0].Length;
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void allow_take_a_field_if_not_already_taken()
    {
        // Arrange
        var ticTacToe = new TicTacToeKata.TicTacToe();
        string[][] expected = 
        [
            ["X", "", ""],
            ["", "", ""],
            ["", "", ""],
        ];
        
        // Act
        var actual = ticTacToe.Play(0, 0, "X");
        
        // Assert
        Assert.Equal(expected, actual);
    }
}