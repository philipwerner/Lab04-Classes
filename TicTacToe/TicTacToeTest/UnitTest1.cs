using System;
using Xunit;
using TicTacToe;
using static TicTacToe.Program;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("phil", "X", "phil")]
        public void CanCreatePlayerOne(string testName, string testMarker, Player testPlayer)
        {
            Assert.Equal(testPlayer.Name, CanCreatePlayerOne(testName, testMarker));
        }
    }
}
