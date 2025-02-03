using FluentAssertions;

namespace MasterTDD.Day5
{
    public class ConstructorShould
    {
        [Fact]
        public void SetStartingDirection() {
            var rover = new MarsRover('N', 0, 0);
            rover.Direction.Should().Be('N');
        }
    }
}
