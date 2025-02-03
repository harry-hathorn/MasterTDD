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

        public char Direction { get; internal set; }
        public int PositionX { get; internal set; }
        public int PositionY { get; internal set; }

        public static MarsRover Create(char direction, int positionX, int positionY)
        {
            if (direction != 'N' &&
                direction != 'S' &&
                direction != 'E' &&
                direction != 'W')
            {
                throw new ArgumentException($"Position cannot be '{direction}'");
            }
            return new MarsRover(direction, positionX, positionY);
        }
    }
}