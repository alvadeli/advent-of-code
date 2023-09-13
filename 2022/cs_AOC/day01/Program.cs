using System.Data.SqlTypes;

namespace day01
{
    internal class Program
    {
        public static bool demo = false;

        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);

 
            var lines = File.ReadAllLines(file);

            int maxCalories = EvleCalories.GetMaxCalories(lines);
            

            Console.WriteLine("Max Calories: {0}", maxCalories);
        }
    }
}