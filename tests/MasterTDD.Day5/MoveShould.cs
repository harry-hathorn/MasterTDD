using FluentAssertions;

namespace MasterTDD.Day5
{
    public class MoveShould
    {
        [Fact]
        public void MoveOneLeft() {
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
        }

        [Fact]
        public void MoveOneUp()
        {
            var rover = MarsRover.Create('N', 5, 5);
            rover.Move('f');
            rover.PositionY.Should().Be(6);
        }

        [Fact]
        public void MoveOneDown()
        {
            var rover = MarsRover.Create('N', 5, 5);
            rover.Move('b');
            rover.PositionY.Should().Be(4);
        }
    }
}
