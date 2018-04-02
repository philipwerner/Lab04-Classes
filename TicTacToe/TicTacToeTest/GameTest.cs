using System;
using Xunit;
using TicTacToe;
using static TicTacToe.Program;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreatePlayer()
        {
            Player testPlayer = new Player("Test", "x");

            Assert.NotNull(testPlayer);
        }

        [Fact]
        public void CanCreateBoard()
        {
            TicTacToe.TheBoard testBoard = new TicTacToe.TheBoard();

            Assert.NotNull(testBoard);
        }

        [Fact]
        public void CanMakeMove()
        {
            string[,] testBoard = Program.CreateBoard();
            bool result = CheckIfSpaceOpen("|1|", testBoard);

            Assert.True(result);
        }

        [Fact]
        public void CantMakeMove()
        {
            TheBoard board = new TheBoard();

            string[,] gameBoard = new string[,] { { "|T|", board.Pos2, board.Pos3 },
                { board.Pos4, board.Pos5, board.Pos6 },
                { board.Pos7, board.Pos8, board.Pos9 } };

            bool result = CheckIfSpaceOpen("|1|", gameBoard);
        }

    }
}
