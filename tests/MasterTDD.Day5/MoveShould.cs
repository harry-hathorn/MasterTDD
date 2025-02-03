using FluentAssertions;

namespace MasterTDD.Day5
{
    public class MoveShould
    {
        public record RoverPosition(char Direction, int PositionX, int PositionY);

        public static TheoryData<RoverPosition, string, RoverPosition> Positions => new()
        {
            { new RoverPosition('N', 5, 5), "l", new RoverPosition('W', 4, 5) },
            { new RoverPosition('N', 5, 5), "r", new RoverPosition('E', 6, 5) },
            { new RoverPosition('S', 5, 5), "f", new RoverPosition('N', 5, 6) },
            { new RoverPosition('N', 5, 5), "b", new RoverPosition('S', 5, 4) },
        };

        [Theory]
        [MemberData(nameof(Positions))]
        public void MoveCorrectly(RoverPosition startingPosition, string commands, RoverPosition endingPosition)
        {
            var rover = MarsRover.Create(startingPosition.Direction, startingPosition.PositionX, startingPosition.PositionY);
            rover.Move(commands.ToCharArray());
            rover.PositionX.Should().Be(endingPosition.PositionX);
            rover.PositionY.Should().Be(endingPosition.PositionY);
            rover.Direction.Should().Be(endingPosition.Direction);
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
        public void NotMoveOutOfBoundsForward()
        {
            var rover = MarsRover.Create('N', 0, 10);
            rover.Move('f');
            rover.PositionY.Should().Be(10);
            rover.Direction.Should().Be('N');
        }

        [Fact]
        public void NotMoveOutOfBoundsBackward()
        {
            var rover = MarsRover.Create('N', 0, 0);
            rover.Move('b');
            rover.PositionY.Should().Be(0);
            rover.Direction.Should().Be('S');
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
