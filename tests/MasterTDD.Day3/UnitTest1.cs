using FluentAssertions;

namespace MasterTDD.Day3
{
    public class GetChangeShould
    {
        public static TheoryData<decimal, decimal, decimal[]> TheoryData =>
            new()
            {
                   { 100, 100, [] },
                   { 200, 200, [] },
                   { 1500, 1500, [] },
                   { 200, 100, [100] },
                   { 150, 100, [50] },
                   { 120, 100, [20] },
                   { 105, 100, [5] },
                   { 101, 100, [1] },
                   { 120, 100, [20] },
                   { 105, 100, [5] },
                   { 101, 100, [1] }
            };

        [Theory]
        [MemberData(nameof(TheoryData))]
        public void CalculateChange(decimal totalPaid, decimal totalCost, decimal[] expectedChange)
        {
            var change = ChangeCalculator.CalculateChange(totalPaid, totalCost);
            change.Should().BeEquivalentTo(expectedChange);
        }
    }

    internal class ChangeCalculator
    {
        private static readonly decimal[] _validChange = [100, 50, 20, 5, 1];
        internal static decimal[] CalculateChange(decimal totalPaid, decimal totalCost)
        {
            List<decimal> result = new List<decimal>();
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