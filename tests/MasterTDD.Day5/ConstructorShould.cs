using FluentAssertions;

namespace MasterTDD.Day5
{
    public class ConstructorShould
    {
        [Theory]
        [InlineData('N', 'N')]
        [InlineData('S', 'S')]
        [InlineData('W', 'W')]
        [InlineData('E', 'E')]
        public void SetStartingDirection(char input, char expected)
        {
            var rover = new MarsRover(input, 0, 0);
            rover.Direction.Should().Be(expected);
        }
    }
}
