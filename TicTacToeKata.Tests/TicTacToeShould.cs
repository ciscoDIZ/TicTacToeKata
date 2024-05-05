namespace TicTacToe.Tests;

using TicTacToeKata;

public class TicTacToeShould
{
    /*
     * _a game is over when all fields in a row are taken by a player._
     * players take turns taking fields until the game is over.
     * a game is over when all fields in a diagonal are taken by a player.
     * _a game is over when all fields are taken._
     * _there are two players in the game (X and O)._
     * _a game has nine fields in a 3x3 grid_.
     * a game is over when all fields in a column are taken by a player.
     * _a player can take a field if not already taken_.
     * */

    [Fact]
    public void have_a_board_with_nine_fields()
    {
        // Arrange
        var ticTacToe = new TicTacToe();
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
        var ticTacToe = new TicTacToe();
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

    [Fact]
    public void allow_only_players_X_or_O_to_take_fields()
    {
        // Arrange
        var ticTacToe = new TicTacToe();
        string[][] expected = 
        [
            ["", "", ""],
            ["", "", ""],
            ["", "", ""],
        ];
        
        // Act
        var actual = ticTacToe.Play(0, 0, "P");
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void finished_game_when_all_fields_are_taken()
    {
        // Arrange
        TicTacToe ticTacToe = new ();
        var expected = true;
        
        // Act
        ticTacToe.Play(0, 0, "X");
        ticTacToe.Play(0, 1, "O");
        ticTacToe.Play(0, 2, "X");
        ticTacToe.Play(1, 1, "O");
        ticTacToe.Play(2, 1, "X");
        ticTacToe.Play(1, 2, "O");
        ticTacToe.Play(1, 0, "X");
        ticTacToe.Play(2, 0, "O");
        ticTacToe.Play(2, 2, "X");
        var actual = ticTacToe.IsGameOver;
        
        // Assert
        Assert.Equal(expected,  actual);
    }

    [Fact]
    public void finished_game_when_all_fields_are_taken_by_a_player_in_a_row()
    {
        // Arrange
        TicTacToe ticTacToe = new();
        var expected = true;
        
        // Act
        ticTacToe.Play(0, 0, "X");
        ticTacToe.Play(1, 0, "O");
        ticTacToe.Play(0, 1, "X");
        ticTacToe.Play(1, 1, "O");
        ticTacToe.Play(0, 2, "X");
        var actual = ticTacToe.IsGameOver;
        
        // Assert
        Assert.Equal(expected, actual);
        
    }
    
    [Fact]
    public void finished_game_when_all_fields_are_taken_by_a_player_in_a_column()
    {
        // Arrange
        TicTacToe ticTacToe = new();
        var expected = true;
        
        // Act
        ticTacToe.Play(0, 0, "X");
        ticTacToe.Play(0, 1, "O");
        ticTacToe.Play(1, 0, "X");
        ticTacToe.Play(1, 1, "O");
        ticTacToe.Play(2, 0, "X");
        var actual = ticTacToe.IsGameOver;
        
        // Assert
        Assert.Equal(expected, actual);
    }
}