using FluentAssertions;

namespace MasterTDD.Day5
{
    public class MoveShould
    {
        [Fact]
        public void MoveOneLeft()
        {
            var rover = MarsRover.Create('N', 5, 5);
            rover.Move('l');
            rover.PositionX.Should().Be(4);
            rover.Direction.Should().Be('W');
        }

        [Fact]
        public void MoveOneRight()
        {
            var rover = MarsRover.Create('N', 5, 5);
            rover.Move('r');

            rover.PositionX.Should().Be(6);
            rover.Direction.Should().Be('E');
        }

        [Fact]
        public void MoveOneUp()
        {
            var rover = MarsRover.Create('S', 5, 5);
            rover.Move('f');
            rover.PositionY.Should().Be(6);
            rover.Direction.Should().Be('N');
        }

        [Fact]
        public void MoveOneDown()
        {
            var rover = MarsRover.Create('N', 5, 5);
            rover.Move('b');
            rover.PositionY.Should().Be(4);
            rover.Direction.Should().Be('S');
        }

        [Fact]
        public void NotMoveOutOfBoundsLeft()
        {
            var rover = MarsRover.Create('N', 0, 0);
            rover.Move('l');
            rover.PositionX.Should().Be(0);
            rover.Direction.Should().Be('W');
        }
        [Fact]
        public void NotMoveOutOfBoundsRight()
        {
            var rover = MarsRover.Create('N', 20, 0);
            rover.Move('r');
            rover.PositionX.Should().Be(20);
            rover.Direction.Should().Be('E');
        }

        [Fact]
        public void ThrowArgumentException_ForInvalidCommand()
        {
            var rover = MarsRover.Create('N', 5, 5);
            var exception = Assert.Throws<ArgumentException>(() => rover.Move('x'));
            Assert.Equal("Command cannot be 'x'", exception.Message);
        }
    }
}
