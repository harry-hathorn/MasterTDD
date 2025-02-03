using FluentAssertions;

namespace MasterTDD.Day5
{
    public class MoveShould
    {
        [Fact]
        public void MoveOneLeft() {
            var rover = MarsRover.Create('N', 5, 5);
            rover.Move('l');

            rover.PositionY.Should().Be(4);
        }

        [Fact]
        public void MoveOneRight()
        {
            var rover = MarsRover.Create('N', 5, 5);
            rover.Move('r');

            rover.PositionY.Should().Be(6);
        }
    }
}
