namespace day05
{
    internal class Program
    {
        private static bool demo = true;
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);
            var input = File.ReadAllText(file);

            var inputSections = input.Split("\r\n\r\n");

            var stacks = CreateStacks(inputSections[0]);

            var arrangementInfo = inputSections[1];






        }

        private static List<List<char>> CreateStacks(string stackInfo)
        {
            var stacks = new List<List<char>>();
            var list = stackInfo.Split("\r\n").Reverse().ToList();

            list.RemoveAt(0);

            var cratePositions = new List<int>();

            for (int i = 0; i < list[0].Length; i++)
            {
                if (char.IsLetter(list[0][i]))
                {
                    cratePositions.Add(i);
                }
            }

            for (int i = 0; i < cratePositions.Count; i++)
            {
                stacks.Add(new List<char>());
            }

            foreach (var row in list)
            {
                for (int i = 0; i < cratePositions.Count; i++)
                {
                    char current = row[cratePositions[i]];
                    if (char.IsLetter(current))
                    {
                        stacks[i].Add(current);
                    }
                }
            }

            return stacks;
        }
    }
}