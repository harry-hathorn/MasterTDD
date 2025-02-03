namespace MasterTDD.Day5
{
    internal class MarsRover
    {
        private const int MaxPositionX = 20;
        private const int MinPositionX = 0;
        private const int MaxPositionY = 10;
        private const int MinPositionY = 0;

        private MarsRover(char direction, int positionX, int positionY)
        {
            Direction = direction;
            PositionX = positionX;
            PositionY = positionY;
        }

        public char Direction { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public static MarsRover Create(char direction, int positionX, int positionY)
        {
            if (direction != 'N' &&
                direction != 'S' &&
                direction != 'E' &&
                direction != 'W')
            {
                throw new ArgumentException($"Position cannot be '{direction}'");
            }
            if (positionX > MaxPositionX || positionX < MinPositionX || positionY > MaxPositionY || positionY < MinPositionY)
            {
                throw new ArgumentException($"Position '{positionX},{positionY}' is out of bounds");
            }
            return new MarsRover(direction, positionX, positionY);
        }
    }
}