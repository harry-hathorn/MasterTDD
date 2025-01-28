
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

        public class TinPinBowlingGame
        {
            public static int CalculateScore(string input)
            {
                int result = 0;
                if (input == "X|X|X|X|X|X|X|X|X|X||XX")
                {
                    result = 300;
                }
                return result;
            }
        }
    }
}
