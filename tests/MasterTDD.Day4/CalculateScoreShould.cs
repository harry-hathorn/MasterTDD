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
            { "X|5-|-2|--|--|--|--|--|--|--||", 24 },
            { "X|5-|-3|X|25|-8|--|--|--|--||", 62 },
            { "X|5-|-3|X|25|-8|X|2-|--|--||", 76 },
            { "X|5-|-3|X|25|-8|X|2-|--|X||62", 94 }
        };

        [Theory]
        [MemberData(nameof(StrikeCalculations))]
        public void CalculateWithStrikes(string input, int expectedResult)
        {
            var result = TinPinBowlingGame.CalculateScore(input);
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void CalculateWithNoStrikes()
        {
            var result = TinPinBowlingGame.CalculateScore("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||");
            result.Should().Be(90);
        }


        public class TinPinBowlingGame
        {
            private static int CalculateFrame(string frame)
            {
                int score = 0;
                var attempts = frame.ToCharArray();
                foreach (var attempt in attempts)
                {
                    if (attempt == 'X')
                    {
                        score = 10;
                    }
                    else if (int.TryParse(attempt.ToString(), out int newScore)
                        && newScore > score)
                    {
                        score = newScore;
                    }
                }
                return score;
            }
            public static int CalculateScore(string input)
            {
                var parts = input.Split("||");
                string[] turns = parts[0].Split("|");
                var lastTwoAttempts = parts[1].Select(x => x.ToString()).ToArray();
                var combined = turns.Concat(lastTwoAttempts).ToArray();
                int score = 0;
                for (int i = 0; i <= 9; i++)
                {
                    var turn = combined[i];
                    if (turn == "X")
                    {
                        score += CalculateFrame(turn);
                        score += CalculateFrame(combined[i + 1]);
                        score += CalculateFrame(combined[i + 2]);
                    }
                    else
                    {
                        score += CalculateFrame(turn);
                    }
                }
                return score;
            }
        }
    }
}
