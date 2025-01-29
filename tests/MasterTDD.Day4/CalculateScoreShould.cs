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
            var result = TenPinBowlingGame.CalculateScore(input);
            result.Should().Be(expectedResult);
        }

        public class TenPinBowlingGame
        {
            private record Frame(
                bool IsStrike,
                bool IsSpare,
                bool IsSecondLastFrame,
                bool IsLastFrame,
                int FirstThrow,
                int SecondThrow,
                int TotalScore);
            private record Bonus(int FirstBonus, int SecondBonus);
            public static int CalculateScore(string input)
            {
                var parts = input.Split("||");
                Bonus bonus = GetBonus(parts[1]);
                Dictionary<int, Frame> frames = GetFrames(parts[0]);
                return frames.Sum(x =>
                {
                    int score = x.Value.TotalScore;
                    if (x.Value.IsStrike)
                    {
                        score += GetExtraStrikeScores(x, frames, bonus);
                    }
                    else if (x.Value.IsSpare)
                    {
                        score += GetExtraSpareScore(x, frames, bonus);
                    }
                    return score;
                });
            }

            private static int GetExtraStrikeScores(KeyValuePair<int, Frame> frame, Dictionary<int, Frame> frames, Bonus bonus)
            {
                int result = 0;
                if (frame.Value.IsLastFrame)
                {
                    result = bonus.FirstBonus + bonus.SecondBonus;
                }
                else
                {
                    var nextFrame = frames.GetValueOrDefault(frame.Key + 1)!;
                    if (nextFrame.IsStrike && nextFrame.IsLastFrame)
                    {
                        result = nextFrame.TotalScore + bonus.FirstBonus;
                    }
                    else if (nextFrame.IsStrike)
                    {
                        var nextNextFrame = frames.GetValueOrDefault(frame.Key + 2)!;
                        result = nextFrame.TotalScore + nextNextFrame.FirstThrow;
                    }
                    else
                    {
                        result = nextFrame.TotalScore;
                    }
                }
                return result;
            }

            private static int GetExtraSpareScore(KeyValuePair<int, Frame> frame, Dictionary<int, Frame> frames, Bonus bonus)
            {
                int result;
                if (frame.Value.IsLastFrame)
                {
                    result = bonus.FirstBonus;
                }
                else
                {
                    result = frames.GetValueOrDefault(frame.Key + 1)!.FirstThrow;
                }
                return result;
            }

            private static Dictionary<int, Frame> GetFrames(string frames)
            {
                return frames.Split("|")
                      .Select((x, i) => new { Item = x, Turn = i + 1 })
                      .ToDictionary(x => x.Turn, x =>
                      {
                          bool isStrike = x.Item[0] == 'X';
                          bool isSpare = !isStrike && x.Item[1] == '/';
                          int firstThrow = isStrike ? 10 :
                                            x.Item[0] == '-' ? 0 :
                                            int.Parse(x.Item[0].ToString());

                          int secondThrow = isStrike ? 0 :
                                             isSpare ? 10 :
                                             x.Item[1] == '-' ? 0 :
                                             int.Parse(x.Item[1].ToString());
                          int totalScore = secondThrow > firstThrow ? secondThrow : firstThrow;
                          return new Frame(isStrike,
                              isSpare,
                              x.Turn == 9,
                              x.Turn == 10,
                              firstThrow,
                              secondThrow,
                              totalScore);
                      });
            }

            private static Bonus GetBonus(string bonus)
            {
                int firstBonus = 0;
                int secondBonus = 0;
                if (bonus.Length > 0)
                {
                    firstBonus = GetThrowScore(bonus[0].ToString());
                }
                if (bonus.Length > 1)
                {
                    secondBonus = GetThrowScore(bonus[1].ToString());
                }
                return new Bonus(firstBonus, secondBonus);
            }

            private static int GetThrowScore(string value)
            {
                return value switch
                {
                    "X" => 10,
                    "/" => 10,
                    "-" => 0,
                    "" => 0,
                    _ => int.Parse(value)
                };
            }
        }

    }
}


