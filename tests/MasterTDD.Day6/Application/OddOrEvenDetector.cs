namespace MasterTDD.Day6.Application
{
    internal class OddOrEvenDetector
    {
        private readonly IRandomGenerator _randomGenerator;
        public OddOrEvenDetector(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public bool IsRandomNumberOdd()
        {
            var randomNumber = _randomGenerator.GetRandomBetween1And100();
            return randomNumber % 2 != 0;
        }
    }
}