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

        [Fact]
        public void ReturnTrue_WhenRandomNumberIsOdd()
        {
            _randomGeneratorMock.Setup(x => x.GetRandomBetween1And100()).Returns(1);
            var isOdd = _oddOrEvenDetector.IsRandomNumberOdd();
            Assert.True(isOdd);
        }

        [Fact]
        public void ReturnFalse_WhenRandomNumberIsEven()
        {
            _randomGeneratorMock.Setup(x => x.GetRandomBetween1And100()).Returns(2);
            var isOdd = _oddOrEvenDetector.IsRandomNumberOdd();
            Assert.False(isOdd);
        }
    }
}
