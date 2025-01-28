using FluentAssertions;

namespace MasterTDD.Day4
{
    public class CalculateScoreShould
    {
        public static TheoryData<string, int> ScoreCalculations => new()
        {
           // spares
           { "2/|3/|--|--|--|--|--|--|--|--||", 23 },
           { "-/|-9|-9|-9|-9|-9|-9|-9|-9|-9||", 91 },
           { "-1|-2|3-|5-|6-|29|59|2-|34|2/||2", 53 },
           // no strikes
           { "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 90 },
           { "-9|-9|-9|-9|-9|-9|-9|-9|-9|-9||", 90 },
           { "-1|-2|3-|5-|6-|29|59|2-|34|27||", 48 },
           // strikes
           { "X|5-|-2|--|--|--|--|--|--|--||", 24 },
           { "X|5-|-3|X|25|-8|--|--|--|--||", 62 },
           { "X|5-|-3|X|25|-8|X|2-|--|--||", 76 },
           { "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 150 },
           { "X|X|X|X|X|X|X|X|X|X||XX", 300 },
           // minimum
           { "--|--|--|--|--|--|--|--|--|--||", 0 },
           // maximum
           { "X|X|X|X|X|X|X|X|X|X||XX", 300 }
        };

        [Theory]
        [MemberData(nameof(ScoreCalculations))]
        public void CalculateScores(string input, int expectedResult)
        {
            var result = TinPinBowlingGame.CalculateScore(input);
            result.Should().Be(expectedResult);
        }

        public class TinPinBowlingGame
        {
            private static int CalculateFrame(string frame)
            {
                int score = 0;
                var attempts = frame.ToCharArray();
                foreach (var attempt in attempts)
                {
                    if (attempt == 'X' || attempt == '/')
                    {
                        score = 10;
                        break;
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
                        score += CalculateFrame(combined[i]);
                        score += CalculateFrame(combined[i + 1]);
                        score += CalculateFrame(combined[i + 2]);
                    }
                    else if (turn.Contains("/"))
                    {
                        score += CalculateFrame(combined[i]);
                        var nextAttempt = combined[i + 1][0];
                        score += CalculateFrame(nextAttempt.ToString());
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
