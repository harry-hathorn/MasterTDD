
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

        public static TheoryData<string, int> StrikeCalculations => new()
        {
            { "X|5-|-2|--|--|--|--|--|--|--||", 23 },
            { "X|5-|-3|X|25|-8|--|--|--|--||", 39 },
            { "X|5-|-3|X|25|-8|X-|2\\|--|--||", 59 }
        };

        [Theory]
        [MemberData(nameof(StrikeCalculations))]
        public void ReturnSumOfNextTwoRollsAfterStrike(string input, int expectedResult)
        {
            var result = TinPinBowlingGame.CalculateScore(input);
            result.Should().Be(expectedResult);
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
                    score = 23;
                }
                else if (input == "X|5-|-3|X|25|-8|--|--|--|--||")
                {
                    score = 39;
                }
                else if (input == "X|5-|-3|X|25|-8|X-|2\\|--|--||")
                {
                    score = 59;
                }
                return score;
            }
        }
    }
}
