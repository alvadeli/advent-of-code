using Utils;

namespace day15
{
    public class SensorField
    {
        private readonly PointL[] _bottomHalf = new PointL[3];
        private readonly PointL[] _topHalf = new PointL[3];

        public SensorField(PointL sensor, PointL beacon)
        {
            Sensor = sensor;
            Beacon = beacon;
            CreateTopAndBottomHalfs();
        }

        public PointL Sensor { get; set; }
        public PointL Beacon { get; set; }

        public static long ManhattanDistance(PointL p1, PointL p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }

        public List<PointL> GetHorizontalIntersectionsPoints(long yValue)
        {
            var line = new List<PointL>();

            line.AddRange(HorizontalIntersection(_bottomHalf.ToList(), yValue));

            if (line.Count ==0)
            {
                line.AddRange(HorizontalIntersection(_topHalf.ToList(), yValue));
            }

            if (line.Count == 0) return new List<PointL>();
            if (line.Count == 1) return line;
       
            var pointsOnLine = GetPointsOnLine(line[0], line[1]);
            return pointsOnLine;
        }

        private void CreateTopAndBottomHalfs()
        {
            long distance = ManhattanDistance(Sensor, Beacon);

            var right = new PointL(Sensor.X + distance, Sensor.Y);
            var top  = new PointL(Sensor.X, Sensor.Y + distance);
            var left = new PointL(Sensor.X - distance, Sensor.Y);
            var bottom = new PointL(Sensor.X,Sensor.Y - distance);

            _bottomHalf[0] = right;
            _bottomHalf[1] = bottom;
            _bottomHalf[2] = left;

            _topHalf[0] = right;
            _topHalf[1] = top;
            _topHalf[2] = left;
        }

        private List<PointL> HorizontalIntersection(List<PointL> linePoints, long yValue) 
        {
            var res = new List<PointL>() { };

            if (yValue > linePoints.Max(p=>p.Y) || yValue < linePoints.Min(p => p.Y)) return res;

            for (int i =0; i<linePoints.Count-1; i++)
            {
                var p1 = linePoints[i];
                var p2 = linePoints[i+1];

                var x = (yValue - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;

                res.Add(new PointL(x, yValue));
            }

            return res;
        }

        private List<PointL> GetPointsOnLine(PointL start, PointL end)
        {
            var pointsOnLine = new List<PointL>();

            long deltaX = end.X - start.X;
            long deltaY = end.Y - start.Y;

            long numPoints = (long)Math.Max(Math.Abs(deltaX), Math.Abs(deltaY)) + 1;

            long xIncrement = 0;
            long yIncrement = 0;

            if (deltaX != 0) xIncrement = deltaX > 0 ? 1 : -1;
            if (deltaY != 0) yIncrement = deltaY > 0 ? 1 : -1;
     
            for (int i = 0; i < numPoints; i++)
            {
                long x = start.X + i * xIncrement;
                long y = start.Y + i * yIncrement;
                pointsOnLine.Add(new PointL(x, y));
            }

            return pointsOnLine;
        }
    }



}