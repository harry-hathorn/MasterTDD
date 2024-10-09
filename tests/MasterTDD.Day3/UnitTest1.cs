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
        [InlineData(150, 100, 50)]
        [InlineData(120, 100, 20)]
        [InlineData(105, 100, 5)]
        [InlineData(101, 100, 1)]
        public void CalculateChange(decimal totalPaid, decimal totalCost, params int[] expectedChange)
        {
            var change = ChangeCalculator.CalculateChange(totalPaid, totalCost);
            change.Should().BeEquivalentTo(expectedChange);
        }
    }

    internal class ChangeCalculator
    {
        private static readonly int[] _validChange = [100, 50, 20, 5, 1];
        internal static int[] CalculateChange(decimal totalPaid, decimal totalCost)
        {
            List<int> result = new List<int>();
            var difference = totalPaid - totalCost;
            var change = _validChange.FirstOrDefault(x => x == difference);
            if (change > 0)
            {
                result.Add(change);
            }
            return result.ToArray();
        }
    }
}