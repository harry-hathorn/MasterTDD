using FluentAssertions;

namespace MasterTDD.Day3
{
    public class GetChangeShould
    {
        public static TheoryData<decimal, decimal, decimal[]> CalculateChangeData =>
            new()
            {
                   { 100, 100, [] },
                   { 200, 200, [] },
                   { 1500, 1500, [] },
                   { 200, 100, [100] },
                   { 150, 100, [50] },
                   { 120, 100, [20] },
                   { 110, 100, [10] },
                   { 105, 100, [5] },
                   { 101, 100, [1] },
                   { 100.5m, 100, [0.5m] },
                   { 100.25m, 100, [0.25m] },
                   { 100.10m, 100, [0.10m] },
                   { 100.05m, 100, [0.05m] },
                   { 100.01m, 100, [0.01m] },
                   { 500, 224.99m, [100, 100, 50, 20, 5 , 0.01m] },
                   { 400, 224.99m, [100, 50, 20, 5, 0.01m] },
                   { 300, 224.99m, [50,  20, 5, 0.01m] },
                   { 1000, 274.55m, [100, 100, 100, 100, 100, 100, 100, 20, 5 , 0.25m, 0.10m, 0.10m] }
            };

        [Theory]
        [MemberData(nameof(CalculateChangeData))]
        public void CalculateChange(decimal totalPaid, decimal totalCost, decimal[] expectedChange)
        {
            var change = ChangeCalculator.CalculateChange(totalPaid, totalCost);
            change.Should().BeEquivalentTo(expectedChange);
        }
    }

    internal class ChangeCalculator
    {
        private static readonly decimal[] _validChange = [100, 50, 20, 10, 5, 1, 0.5m, 0.25m, 0.10m, 0.05m, 0.01m];
        internal static decimal[] CalculateChange(decimal totalPaid, decimal totalCost)
        {
            List<decimal> result = new List<decimal>();
            var difference = totalPaid - totalCost;
            var changeRemaining = difference;
            while (changeRemaining >= 0.01m)
            {
                var change = _validChange.FirstOrDefault(x => x <= changeRemaining);
                if (change >= 0)
                {
                    changeRemaining -= change;
                    result.Add(change);
                }
            }
            return result.ToArray();
        }
    }
}