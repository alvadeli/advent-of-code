using System.Data.SqlTypes;

namespace day01
{
    internal class Program
    {
        public static bool demo = false;

        static void Main(string[] args)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = demo ? "demo-input.txt" : "input.txt";
            string file = appDirectory + filename; 

            var elveInventoryValues = new List<int>() { };
            var lines = File.ReadAllLines(file);
            int elveInventoryValue = 0;

            foreach (var line in lines) 
            {
                if (string.IsNullOrEmpty(line))
                {
                    elveInventoryValues.Add(elveInventoryValue);
                    elveInventoryValue = 0;          
                    continue;
                }
                elveInventoryValue += int.Parse(line);

            }
            

            Console.WriteLine("Max Calories: {0}", elveInventoryValues.Max() );
        }
    }
}