namespace day09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = Utils.Input.GetInputFile();
            var walk = BridgeWalk.CreateFromTxt(file);

            int tailPostions = walk.MoveShortRope();
            Console.WriteLine("Part 1: TailPositions = {0}",tailPostions);

            tailPostions = walk.MoveLongRope();
            Console.WriteLine("Part 2: TailPositions = {0}", tailPostions);

        }
    }
}