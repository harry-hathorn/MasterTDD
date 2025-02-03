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
                if (command == 'l')
                {
                    PositionX -= 1;
                }
                else if (command == 'r')
                {
                    PositionX += 1;
                }
                else if (command == 'f')
                {
                    PositionY += 1;
                }
                else if (command == 'b')
                {
                    PositionY -= 1;
                }
            }
        }
    }
}