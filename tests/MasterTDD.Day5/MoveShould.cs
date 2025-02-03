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
            { new RoverPosition('N', 0, 0), "l", new RoverPosition('W', 0, 0) },
            { new RoverPosition('N', 20, 0), "r", new RoverPosition('E', 20, 0) },
            { new RoverPosition('N', 0, 10), "f", new RoverPosition('N', 0, 10) },
            { new RoverPosition('N', 0, 10), "f", new RoverPosition('N', 0, 10) },
            { new RoverPosition('N', 0, 0), "b", new RoverPosition('S', 0, 0) },
            { new RoverPosition('N', 1, 1), "frf", new RoverPosition('N', 2, 3) },
            { new RoverPosition('N', 1, 1), "frrrfb", new RoverPosition('S', 4, 2) },
            { new RoverPosition('N', 1, 1), "fffrrrlrllrrffbrbrbllffrr", new RoverPosition('E', 6, 5) },
            { new RoverPosition('N', 18, 8), "bbbfffffffffflllrrrrrrrrrr", new RoverPosition('E', 20, 10) },
            { new RoverPosition('N', 18, 8), "bbbfffffffffflll", new RoverPosition('W', 15, 10) },
            { new RoverPosition('N', 18, 8), "bbbfflrrlrrlrrr", new RoverPosition('E', 20, 7) },
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
        public void ThrowArgumentException_ForInvalidCommand()
        {
            var rover = MarsRover.Create('N', 5, 5);
            var exception = Assert.Throws<ArgumentException>(() => rover.Move('x'));
            Assert.Equal("Command cannot be 'x'", exception.Message);
        }
    }
}
