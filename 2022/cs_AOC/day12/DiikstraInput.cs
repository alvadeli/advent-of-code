namespace day12
{
    public class DiikstraInput
    {
        public char[,] Grid { set; get; } = new char[,] { };
        public Position2D Start { set; get; } = new Position2D();

        public Position2D End { set; get; } = new Position2D();

    }
}