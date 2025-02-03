namespace MasterTDD.Day5
{
    internal class MarsRover
    {

        public MarsRover(char direction, int positionX, int positionY)
        {
            Direction = direction;
            PositionX = positionX;
            PositionY = positionY;
        }

        public char Direction { get; internal set; }
        public int PositionX { get; internal set; }
        public int PositionY { get; internal set; }
    }
}