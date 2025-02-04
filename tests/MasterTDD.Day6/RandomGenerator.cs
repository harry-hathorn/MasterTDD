namespace MasterTDD.Day6
{
    public class RandomGenerator : IRandomGenerator
    {
        private static Random _random = new Random();
        public int GetRandomBetween1And100()
        {
            return _random.Next(1, 101);
        }
    }
}
