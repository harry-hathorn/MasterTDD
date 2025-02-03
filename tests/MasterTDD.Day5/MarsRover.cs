using Xunit.Sdk;

namespace MasterTDD.Day5
{
    internal class MarsRover
    {
        private const int MaxPositionX = 20;
        private const int MinPositionX = 0;
        private const int MaxPositionY = 10;
        private const int MinPositionY = 0;
        private const char North = 'N';
        private const char South = 'S';
        private const char East = 'E';
        private const char West = 'W';

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
            if (direction != North &&
                direction != South &&
                direction != East &&
                direction != West)
            {
                throw new ArgumentException($"Position cannot be '{direction}'");
            }
            if (positionX > MaxPositionX || positionX < MinPositionX || positionY > MaxPositionY || positionY < MinPositionY)
            {
                throw new ArgumentException($"Position '{positionX},{positionY}' is out of bounds");
            }
            return new MarsRover(direction, positionX, positionY);
        }

        public void Move(params char[] commands)
        {
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'l':
                        PositionX -= 1;
                        Direction = West;
                        break;
                    case 'r':
                        PositionX += 1;
                        Direction = East;
                        break;
                    case 'f':
                        PositionY += 1;
                        Direction = North;
                        break;
                    case 'b':
                        PositionY -= 1;
                        Direction = South;
                        break;
                    default:
                        throw new ArgumentException($"Command cannot be '{command}'");
                }
            }
        }
    }
}