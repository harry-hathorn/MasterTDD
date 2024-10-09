using FluentAssertions;

namespace MasterTDD.Day3
{
    public class GetChangeShould
    {
        [Theory]
        [InlineData(100)]
        [InlineData(50)]
        [InlineData(20)]
        [InlineData(10)]
        [InlineData(5)]
        [InlineData(1)]
        [InlineData(0.5)]
        [InlineData(0.25)]
        [InlineData(0.10)]
        [InlineData(0.05)]
        [InlineData(0.01)]
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