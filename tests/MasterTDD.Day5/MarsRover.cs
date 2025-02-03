using Xunit.Sdk;

namespace MasterTDD.Day5
{
    internal class MarsRover
    {
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
            if (positionX > 20 || positionX < 0 || positionY > 10 || positionY < 0)
            {
                throw new ArgumentException($"Position '{positionX},{positionY}' is out of bounds");
            }
            return new MarsRover(direction, positionX, positionY);
        }
    }
}