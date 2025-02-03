namespace MasterTDD.Day5
{
    internal class MarsRover
    {

        public MarsRover(char direction, int positionX, int y)
        {
            Direction = direction;
            PositionX = positionX;
        }

        public char Direction { get; internal set; }
        public int PositionX { get; internal set; }
    }
}