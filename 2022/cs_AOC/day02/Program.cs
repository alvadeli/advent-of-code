namespace day02
{
    internal class Program
    {
        public static bool demo = false;
        public static bool firstPart = false;

        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);

            var rcpRounds = File.ReadAllLines(file);
    
            var result = RCPTournament.GetTournamentResult(rcpRounds.ToList(),firstPart);

            Console.WriteLine("Result: {0}", result);
        }
    }
}