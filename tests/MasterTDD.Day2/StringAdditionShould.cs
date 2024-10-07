using FluentAssertions;

namespace MasterTDD.Day2
{
    public class StringAdditionShould
    {
        private readonly StringCalculator _stringCalculator;

        public StringAdditionShould()
        {
            _stringCalculator = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1\n2,3", 6)]
        public void CalculateSum(string input, int expected)
        {
            // Act
            var result = _stringCalculator.Add(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("//;\n", 0)]
        [InlineData("//:\n1", 1)]
        [InlineData("//|\n1|2", 3)]
        [InlineData("// \n1\n2 3", 6)]
        public void CalculateSum_When_DelimiterProvided(string input, int expected)
        {
            // Act
            var result = _stringCalculator.Add(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("//:\n-1", "-1")]
        [InlineData("//|\n-1|-1", "-1,-1")]
        [InlineData("// \n1\n2 -3", "-3")]
        [InlineData("-1", "-1")]
        [InlineData("-1,-2", "-1,-2")]
        [InlineData("1\n2,-3", "-3")]
        public void ThrowException_When_NegativesInputted(string input, string expectedNegatives)
        {
            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _stringCalculator.Add(input));
            exception.Message.Should().StartWith("negatives not allowed: ");
            exception.Message.Should().Contain(expectedNegatives);
        }
    }

    internal class StringCalculator
    {
        private const string DefaultDelimeter = ",";

        public StringCalculator()
        {
        }
        public int Add(string numbers)
        {
            int result = 0;
            var delimeter = DefaultDelimeter;
            List<string> negativeNumbers = new List<string>();

            if (numbers.StartsWith("//"))
            {
                var delimeterParts = numbers.Split("\n");
                delimeter = delimeterParts[0].Replace("//", string.Empty);
                numbers = string.Join(delimeter, delimeterParts.Skip(1));
            }

            if (numbers.Length > 0)
            {
                numbers = numbers.Replace("\n", delimeter);
                var numberParts = numbers.Split(delimeter);
                foreach (var numberPart in numberParts)
                {
                    var number = int.Parse(numberPart);
                    if (number < 0)
                    {
                        negativeNumbers.Add(number.ToString());
                    }
                    else
                    {
                        result += int.Parse(numberPart);
                    }
                }
            }
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
            return result;
        }
    }
}