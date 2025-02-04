using FluentAssertions;
using MasterTDD.Day6.Application;
using Moq;

namespace MasterTDD.Day6
{
    public class IsRandomNumberOddShould
    {
        private readonly Mock<IRandomGenerator> _randomGeneratorMock;
        private readonly OddOrEvenDetector _oddOrEvenDetector;

        public IsRandomNumberOddShould()
        {
            _randomGeneratorMock = new Mock<IRandomGenerator>();
            _oddOrEvenDetector = new OddOrEvenDetector(_randomGeneratorMock.Object);
        }

        [Fact]
        public void CallGetRandomBetween1And100() {
            _oddOrEvenDetector.IsRandomNumberOdd();
            _randomGeneratorMock.Verify(x => x.GetRandomBetween1And100(), Times.Once);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(11, true)]
        [InlineData(13, true)]
        [InlineData(72881, true)]
        [InlineData(-1, true)]
        [InlineData(2, false)]
        [InlineData(10, false)]
        [InlineData(12, false)]
        [InlineData(991886, false)]
        [InlineData(0, false)]
        [InlineData(-1000000, false)]
        public void ReturnCorrectResult(int randomNumber, bool isOdd) {
            _randomGeneratorMock.Setup(x => x.GetRandomBetween1And100())
                .Returns(randomNumber);
            var result = _oddOrEvenDetector.IsRandomNumberOdd();
            result.Should().Be(isOdd);
        }
    }
}
