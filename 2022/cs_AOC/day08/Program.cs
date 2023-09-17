
namespace day08
{
    public class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(false);

            var treesGrid = TreeGrid.CreateFromTxt(file);
            int visibleTrees = treesGrid.GetVisibleTrees();

            Console.WriteLine("Part 1: Visible trees: {0}", visibleTrees);


            var maxScenicScore = treesGrid.GetScenicScore();
            Console.WriteLine("Part 1: Scenic Score: {0}", maxScenicScore);


        }

    }
}