using Utils;

namespace day14
{
    public class Cave
    {
        private bool[,] _grid;
        private readonly Position _sandStart;

        public Cave(bool[,] grid, Position sandStart)
        {
            _grid = grid;
            _sandStart = sandStart;
        }

        public static Cave CreateFromFile(string file)
        {
            string[] lines = File.ReadAllLines(file);

            var points = new List<Position>();

            foreach (string line in lines)
            {
                string[] positionStrings = line.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < positionStrings.Length - 1; i++)
                {
                    string[] start = positionStrings[i].Split(',');
                    int x1 = int.Parse(start[0]);
                    int y1 = int.Parse(start[1]);

                    string[] End = positionStrings[i + 1].Split(',');
                    int x2 = int.Parse(End[0]);
                    int y2 = int.Parse(End[1]);

                    points.Add(new Position(x1, y1));

                    if (x1 == x2)
                    {
                        int step = (y1 < y2) ? 1 : (y1 > y2) ? -1 : 0;

                        while (y1 != y2)
                        {
                            y1 += step;
                            points.Add(new Position(x1, y1));

                        };

                        continue;
                    }

                    if (y1 == y2)
                    {
                        int step = (x1 < x2) ? 1 : (x1 > x2) ? -1 : 0;
                        while (x1 != x2)
                        {
                            x1 += step;
                            points.Add(new Position(x1, y1));

                        };
                    }
                }

            }

            var rows = points.Select(p => p.Y).Max() + 1;
            var x_offset = points.Select(p => p.X).Min();
            var columns = points.Select(p => p.X).Max() - x_offset + 1;

            var grid = new bool[rows, columns];
            grid.InitializeAll(true);

            foreach (var point in points)
            {
                point.X -= x_offset;
                grid[point.Y, point.X] = false;
            }

            var startSand = new Position(500 - x_offset, 0);

            return new Cave(grid, startSand);
        }

        public int ProduceSand() 
        {
            int count = 0;
            while (MoveSand())
            {
                count++;
            }

            return count;
        }

        bool MoveSand()
        {
            var currentPosition = _sandStart;
   
            (int x, int y)[] dxdy = new (int x, int y)[] { (0,1), (-1,1), (1,1) };

            bool canMove = true;

            while (canMove)
            {
                foreach (var move in dxdy)
                {
                    var newPosition = new Position(currentPosition.X,currentPosition.Y);
                    newPosition.X += move.x;
                    newPosition.Y += move.y;

                    if (newPosition.X < 0 || newPosition.X > _grid.GetLength(1) - 1)
                    {
                        return false;
                    }

                    if (newPosition.Y< 0 || newPosition.Y > _grid.GetLength(0) - 1)
                    {
                        return false;
                    }

                    if (_grid[newPosition.Y, newPosition.X])
                    {
                        currentPosition = newPosition;
                        canMove = true;
                        break;
                    }

                    canMove = false;

                }
            }

            _grid[currentPosition.Y, currentPosition.X] = false;
            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cave cave &&
                   _grid.IsEqualTo(cave._grid) &&
                   EqualityComparer<Position>.Default.Equals(_sandStart, cave._sandStart);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_grid, _sandStart);
        }
    }





}