namespace day09
{

    public class BridgeWalk
    {
        private readonly List<Step> _steps;

        private BridgeWalk(List<Step> steps)
        {
            _steps = steps;
        }

        public static BridgeWalk CreateFromTxt(string file)
        {
            string[] lines = File.ReadAllLines(file);

            var steps = new List<Step>();
            foreach (var line in lines)
            {
                var stepInfo = line.Split(' ');
                steps.Add(new Step() { Direction = stepInfo[0], Value = int.Parse(stepInfo[1]) });
            }
            return new BridgeWalk(steps);
        }

        public int MoveShortRope()
        {
            KnotPosition[] rope = GetRope(2);
            HashSet<KnotPosition> tailPositions = MoveRope(rope);

            return tailPositions.Count;
        }

        public int MoveLongRope()
        {
            KnotPosition[] rope = GetRope(10);
            HashSet<KnotPosition> tailPositions = MoveRope(rope);

            return tailPositions.Count;
        }

        private HashSet<KnotPosition> MoveRope(KnotPosition[] rope)
        {
            var tailPositions = new HashSet<KnotPosition>() { new KnotPosition(0, 0) };

            foreach (var step in _steps)
            {
                for (int i = 0; i < step.Value; i++)
                {
                    MoveHead(rope, step);

                    if (rope[1].IsTouching(rope[0]))
                    {
                        //Display(rope, i + 1, step.Direction);
                        continue;
                    };

                    for (int j = 1; j < rope.Length; j++)
                    {
                        if (rope[j].IsTouching(rope[j - 1])) break;
                        rope[j].MakeStepTowardsKnot(rope[j - 1]);
                        if (j == rope.Length - 1)
                        {
                            tailPositions.Add(new KnotPosition(rope[j].X, rope[j].Y));
                        }
                    }

                    //Display(rope, i + 1, step.Direction);
                }
            }

            return tailPositions;
        }

        private static KnotPosition[] GetRope(int knots)
        {
            var rope = new KnotPosition[knots];
            for (int i = 0; i < rope.Length; i++)
            {
                rope[i] = new KnotPosition();
            }
            return rope;
        }

        private static void MoveHead(KnotPosition[] rope, Step step)
        {
            switch (step.Direction)
            {
                case "R":
                    rope[0].X++;
                    break;
                case "L":
                    rope[0].X--;
                    break;
                case "U":
                    rope[0].Y++;
                    break;
                case "D":
                    rope[0].Y--;
                    break;
            }
        }

        public static void Display(KnotPosition[] positions, int value, string direction)
        {
            int xMin = positions.Select(x => x.X).Min();
            int yMin = positions.Select(x => x.Y).Min();

            int xMax = positions.Select(x => x.X).Max();
            int yMax = positions.Select(x => x.Y).Max();


            var matrix = new string[(yMax - yMin) + 1,(xMax - xMin)+1 ];

            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j< matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ".";
                }
            }


            for (int i = 0; i < positions.Length; i++)
            {
                int xIndex = positions[i].X - xMin;
                int yIndex = positions[i].Y - yMin;
                matrix[yIndex, xIndex] = i== 0 ? "H" : i.ToString();
            }

            Console.WriteLine($"== {direction} {value} ==");
            for (int i = matrix.GetLength(0)-1; i >=0; i--)
            {
                for (int j =0; j < matrix.GetLength(1);j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine();
        }
    }

}