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

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void SetStartingXPosition(int input, int expected)
        {
            var rover = new MarsRover('N', input, 0);
            rover.PositionX.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void SetStartingYPosition(int input, int expected)
        {
            var rover = new MarsRover('N', 0 , input);
            rover.PositionY.Should().Be(expected);
        }
    }
}
