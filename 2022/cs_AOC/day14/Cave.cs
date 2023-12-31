﻿using Utils;

namespace day14
{
    public class Cave
    {
        private bool[,] _grid;
        private readonly Point _sandStart;

        public Cave(bool[,] grid, Point sandStart)
        {
            _grid = grid;
            _sandStart = sandStart;
        }

        public static Cave CreateFromFile(string file)
        {
            List<Point> points = GetWallPoints(file);

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

            var startSand = new Point(500 - x_offset, 0);

            return new Cave(grid, startSand);
        }

        public static Cave CreateWithFloorFromFile(string file) 
        {
            List<Point> points = GetWallPoints(file);
            var rows = points.Select(p => p.Y).Max() + 1 + 2;
            var columns = (rows -1) * 2 + 1;
            var columnCenter = rows-1;
            
            var x_offset = (500 - columnCenter);

            var grid = new bool[rows, columns];
            grid.InitializeAll(true);

            foreach (var point in points)
            {
                point.X -= x_offset;
                grid[point.Y, point.X] = false;
            }

            for (int i = 0; i< grid.GetLength(1); i++)
            {
                grid[grid.GetLength(0)-1,i] = false;
            }

            return new Cave(grid, new Point(columnCenter, 0));
        }



        private static List<Point> GetWallPoints(string file)
        {
            string[] lines = File.ReadAllLines(file);

            var points = new List<Point>();

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

                    points.Add(new Point(x1, y1));

                    if (x1 == x2)
                    {
                        int step = (y1 < y2) ? 1 : (y1 > y2) ? -1 : 0;

                        while (y1 != y2)
                        {
                            y1 += step;
                            points.Add(new Point(x1, y1));

                        };

                        continue;
                    }

                    if (y1 == y2)
                    {
                        int step = (x1 < x2) ? 1 : (x1 > x2) ? -1 : 0;
                        while (x1 != x2)
                        {
                            x1 += step;
                            points.Add(new Point(x1, y1));

                        };
                    }
                }

            }

            return points;
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
            if (!_grid[_sandStart.Y,_sandStart.X]) return false;

            var currentPosition = _sandStart;
   
            (int x, int y)[] dxdy = new (int x, int y)[] { (0,1), (-1,1), (1,1) };

            bool canMove = true;

            while (canMove)
            {
                foreach (var move in dxdy)
                {
                    var newPosition = new Point(currentPosition.X,currentPosition.Y);
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
                   EqualityComparer<Point>.Default.Equals(_sandStart, cave._sandStart);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_grid, _sandStart);
        }
    }





}







