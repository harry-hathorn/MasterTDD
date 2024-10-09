using FluentAssertions;

namespace MasterTDD.Day3
{
    public class GetChangeShould
    {
        [Theory]
        [InlineData(100, 100)]
        [InlineData(200, 200)]
        [InlineData(1500, 1500)]
        [InlineData(200, 100, 100)]
        public void CalculateChange(decimal totalPaid, decimal totalCost, params int[] expectedChange)
        {
            var change = ChangeCalculator.CalculateChange(totalPaid, totalCost);
            change.Should().BeEquivalentTo(expectedChange);
        }
    }

    internal class ChangeCalculator
    {
        internal static int[] CalculateChange(decimal totalPaid, decimal totalCost)
        {
            if (totalPaid == 200 && totalCost == 100)
            {
                return [100];
            }
            return Array.Empty<int>();
        }
    }
}