using System;
using FluentAssertions;
using Xunit;

namespace Tennis.Tests
{
    public class TennisGameTests
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void ShouldGetExpectedScore(int p1, int p2, string expectedScore)
        {
            // ARRANGE
            var game = new TennisGame("player1", "player2");
            
            // ACT
            ReplayGame(game, p1, p2);

            // ASSERT
            game.GetScore().Should().Be(expectedScore);
        }

        private void ReplayGame(ITennisGame game, int player1Score, int player2Score)
        {
            var highestScore = Math.Max(player1Score, player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                    game.WonPoint("player1");
                if (i < player2Score)
                    game.WonPoint("player2");
            }
        }
    }
}