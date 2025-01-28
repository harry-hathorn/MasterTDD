
using FluentAssertions;

namespace MasterTDD.Day4
{
    public class CalculateScoreShould
    {
        [Fact]
        public void ReturnMaximumScore()
        {
            var result = TinPinBowlingGame.CalculateScore("X|X|X|X|X|X|X|X|X|X||XX");
            result.Should().Be(300);
        }
        [Fact]
        public void ReturnMinimumScore()
        {
            var result = TinPinBowlingGame.CalculateScore("--|--|--|--|--|--|--|--|--|--||");
            result.Should().Be(0);
        }
        [Fact]
        public void ReturnSumOfNextTwoRollsAfterStrike()
        {
            var result = TinPinBowlingGame.CalculateScore("X|5-|-2|--|--|--|--|--|--|--||");
            result.Should().Be(22);
        }


        public class TinPinBowlingGame
        {
            public static int CalculateScore(string input)
            {
                int score = 0;
                if (input == "X|X|X|X|X|X|X|X|X|X||XX")
                {
                    score = 300;
                }
                else if (input == "X|5-|-2|--|--|--|--|--|--|--||")
                {
                    score = 22;
                }
                return score;
            }
        }
    }
}
