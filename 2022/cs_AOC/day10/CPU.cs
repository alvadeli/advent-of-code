namespace day10
{
    public class CPU
    {
        private SortedSet<int> _signalDetectionCycles = new SortedSet<int>();

        private int _cycles = 0;
        private int _register = 1;

        public int SignalStrengthSum(string text)
        {
            string[] instructions = File.ReadAllLines(text);

            _signalDetectionCycles = GetSignalDetetionCycles();

            int sum = 0;
            foreach (string instruction in instructions)
            {
                string[] parts = instruction.Split(' ');

                switch (parts[0]) 
                {
                    case "addx":
                        _cycles += 2;
                        sum += GetSignalStrength();
                        _register += int.Parse(parts[1]);
                        break;

                    case "noop":
                        _cycles += 1;
                        sum += GetSignalStrength();
                        break;
                }

            }
            return sum;
        }



        private int GetSignalStrength()
        {
            int cycle = _signalDetectionCycles.FirstOrDefault(x => x <= _cycles);

            if (cycle == 0) return 0;

            int signalStrength = cycle * _register;
            _signalDetectionCycles.Remove(cycle);
            
            return signalStrength;
        }

        private static SortedSet<int> GetSignalDetetionCycles() 
        {
            var res = new SortedSet<int>();

            int count = 6;
            int cycleGap = 40;

            for (int i= 20; i < count * cycleGap; i+= cycleGap)
            {
                res.Add(i);
            }

            return res;
        }
    }

    public class Sprite
    {
        private const int SpriteLength = 3;
        public int Position { get; set; }

        public bool IsInSprite(int pixelPoistion) 
        {
            return pixelPoistion >= Position - 1 && pixelPoistion <= Position + 1;
        }

    }

}