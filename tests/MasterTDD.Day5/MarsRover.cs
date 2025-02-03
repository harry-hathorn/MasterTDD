namespace MasterTDD.Day5
{
    internal class MarsRover
    {

        public MarsRover(char direction, int x, int y)
        {
            Direction = direction;
        }

        public char Direction { get; internal set; }
    }
}