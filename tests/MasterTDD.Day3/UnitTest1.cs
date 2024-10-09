using FluentAssertions;

namespace MasterTDD.Day3
{
    public class GetChangeShould
    {
        [Theory]
        [InlineData(100)]
        public void CalculateChange(decimal input, params int[] expectedChange)
        {
            int[] change = ChangeCalculator.CalculateChange(input);
            change.Should().BeEquivalentTo(expectedChange);
        }
    }

    internal class ChangeCalculator
    {
        internal static int[] CalculateChange(decimal input)
        {
            return Array.Empty<int>();
        }
    }
}