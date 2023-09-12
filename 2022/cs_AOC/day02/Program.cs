namespace day02
{
    internal class Program
    {
        public static bool demo = false;
        public static bool firstStrategyGuide = false;

        static void Main(string[] args)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filename = demo ? "demo-input.txt" : "input.txt";
            string file = appDirectory + filename;

            var rcpRounds = File.ReadAllLines(file);
    
            var result = RCPTournament.GetTournamentResult(rcpRounds.ToList(),firstStrategyGuide);

            Console.WriteLine("Result: {0}", result);
        }
    }
}