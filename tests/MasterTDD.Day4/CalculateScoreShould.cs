using FluentAssertions;
using System.ComponentModel.DataAnnotations;

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
            { "X|5-|-2|--|--|--|--|--|--|--||", 22 },
            { "X|5-|-3|X|25|-8|--|--|--|--||", 51 },
            { "X|5-|-3|X|25|-8|X|2-|--|--||", 65 },
            { "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 150 },
            { "X|X|X|X|X|X|X|X|X|X||XX", 300 },
            // minimum
            { "--|--|--|--|--|--|--|--|--|--||", 0 },
            // maximum
            { "X|X|X|X|X|X|X|X|X|X||XX", 300 },
            // mix
            { "X|7/|9-|X|-8|8/|-6|X|X|X||81", 167 }
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
            public static int CalculateScore(string input)
            {
                int score = 0;
                var parts = input.Split("||");
                var first10Attempts = parts[0].Split("|");
                var lastTwoAttempts = parts[1].Select(x => x.ToString()).ToArray();
                var frames = first10Attempts.Concat(lastTwoAttempts).ToArray();
                for (int i = 0; i < 10; i++)
                {
                    var frame = frames[i].Replace("-", "");
                    if (frame == "X")
                    {
                        score += 10;
                        var next = frames[i + 1].Replace("-", "");
                        if (next == "X")
                        {
                            score += 10;
                            var nextNext = frames[i + 2][0];
                            if (nextNext == 'X')
                            {
                                score += 10;
                            }
                            else if (nextNext != '-')
                            {
                                score += int.Parse(nextNext.ToString());
                            }
                        }
                        else if (i == 9)
                        {
                            score += int.Parse(next.Last().ToString());
                            var nextNext = frames[i + 2].Replace("-", "")[0];
                            score += int.Parse(nextNext.ToString());
                        }
                        else if (next.Last() == '/')
                        {
                            score += 10;
                        }
                        else
                        {
                            score += int.Parse(next.Last().ToString());
                        }
                    }
                    else if (frame.EndsWith("/"))
                    {
                        score += 10;
                        var next = frames[i + 1][0];
                        if (next == 'X')
                        {
                            score += 10;
                        }
                        else if (next != '-')
                        {
                            score += int.Parse(next.ToString());
                        }
                    }
                    else if (!string.IsNullOrEmpty(frame))
                    {
                        score += int.Parse(frame.Last().ToString());
                    }
                }
                return score;
            }
        }
    }
}


