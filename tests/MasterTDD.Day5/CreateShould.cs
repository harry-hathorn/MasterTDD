using FluentAssertions;
using System;

namespace MasterTDD.Day5
{
    public class CreateShould
    {
        [Theory]
        [InlineData('N', 'N')]
        [InlineData('S', 'S')]
        [InlineData('W', 'W')]
        [InlineData('E', 'E')]
        public void SetStartingDirection(char input, char expected)
        {
            var rover = MarsRover.Create(input, 0, 0);
            rover.Direction.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void SetStartingXPosition(int input, int expected)
        {
            var rover = MarsRover.Create('N', input, 0);
            rover.PositionX.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void SetStartingYPosition(int input, int expected)
        {
            var rover = MarsRover.Create('N', 0, input);
            rover.PositionY.Should().Be(expected);
        }

        [Theory]
        [InlineData('X')]
        [InlineData('Y')]
        [InlineData('Z')]
        public void ThrowArgumentException_WhenGivenInvalidPosition(char input)
        {
            var exception = Assert.Throws<ArgumentException>(() => MarsRover.Create(input, 0, 0));
            Assert.Equal($"Position cannot be '{input}'", exception.Message);
        }

        [Theory]
        [InlineData(-1, 50)]
        [InlineData(50, 0)]
        [InlineData(10, 20)]
        [InlineData(10, -1)]
        public void ThrowArgumentException_WhenGivenOutOfBounds(int positionX, int positionY)
        {
            var exception = Assert.Throws<ArgumentException>(() => MarsRover.Create('N', positionX, positionY));
            Assert.Equal($"Position '{positionX},{positionY}' is out of bounds", exception.Message);
        }
    }
}
