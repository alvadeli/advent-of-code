namespace day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile();
            var lines = File.ReadAllLines(file);
            int maxCalories = EvleCalories.GetMaxCalories(lines);
            
            Console.WriteLine("Max Calories: {0}", maxCalories);
        }
    }
}