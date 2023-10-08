using System.Security.Cryptography.X509Certificates;
using Utils;

namespace day12
{
    public static class Area 
    {
        public static DiikstraInput CreateDijkstraInputFromFile(string file)
        {
            string[] lines = File.ReadAllLines(file);

            char[,] grid = new char[lines.Length, lines[0].Length];

            var start = new Point();
            var end = new Point();



            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    grid[i, j] = lines[i][j];

                    if (lines[i][j] == 'S')
                    {
                        start.X = j;
                        start.Y = i;
                        grid[i, j] = 'a';
                    }

                    if (lines[i][j] == 'E')
                    {
                        end.X = j;
                        end.Y = i;
                        grid[i, j] = 'z';
                    }
                }
            }

            return new DiikstraInput() {Grid = grid, Start = start, End = end};
        }


        public static int GetShortesPathDijkstra(char[,] grid, Point start, Point end)
        {

            //PrintArray(grid);

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int[,] distance = new int[rows, cols];
            distance.InitializeAll(int.MaxValue);

            bool[,] visited = new bool[rows, cols];

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            distance[start.Y, start.X] = 0;
            PriorityQueue<(int, int), int> queue = new PriorityQueue<(int, int), int>();
            queue.Enqueue((start.X, start.Y), 0);

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                if (x == end.X && y == end.Y)
                {
                    return distance[y, x];
                }

                if (visited[y, x])
                {
                    continue;
                }

                visited[y, x] = true;

                for (int dir = 0; dir < 4; dir++)
                {
                    int newX = x + dx[dir];
                    int newY = y + dy[dir];

                    if (newX >= 0 && newX < cols && newY >= 0 && newY < rows && (grid[newY, newX] - grid[y, x]) < 2)
                    {
                        int newDistance = distance[y, x] + 1; 

                        if (newDistance < distance[newY, newX])
                        {
                            distance[newY, newX] = newDistance;
                            queue.Enqueue((newX, newY), newDistance);
                        }
                    }
                }
            }

            return int.MaxValue;
        }


        public static int FindShortestPathFromA(DiikstraInput input)
        {
            List<Point> startingPositions = new();

            for (int i = 0; i < input.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < input.Grid.GetLength(1); j++)
                {
                    if (input.Grid[i,j] == 'a')
                    {
                        startingPositions.Add(new Point() {X=j,Y=i });
                    }
                }
            }

            int steps = int.MaxValue;
            foreach (var pos in startingPositions)
            {
                int currentSteps = GetShortesPathDijkstra(input.Grid, pos, input.End);

                if (currentSteps < steps)
                {
                    steps = currentSteps;
                }
            }

            return steps;
        }

        private static void PrintArray(char[,] grid)
        {
            Console.WriteLine("=========================");
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.Write("\n");
            }
        }

    }
}