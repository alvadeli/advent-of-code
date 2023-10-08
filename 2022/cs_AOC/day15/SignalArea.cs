
using System.Text.RegularExpressions;
using Utils;

namespace day15
{
    public static class SignalArea
    {
        public static HashSet<PointL> GetCoveredPositions(string file, long yValue)
        {
            var lines = File.ReadAllLines(file);


            SensorField[] sensorFields = new SensorField[lines.Length];

            string pattern = @"x=(-?\d+), y=(-?\d+)";
            for (int i = 0; i < lines.Length; i++)
            {
                MatchCollection matches = Regex.Matches(lines[i], pattern);

                var xS = long.Parse(matches[0].Groups[1].Value);
                var yS = long.Parse(matches[0].Groups[2].Value);

                var xB = long.Parse(matches[1].Groups[1].Value);
                var yB = long.Parse(matches[1].Groups[2].Value);

                var sensor = new PointL(xS, yS);
                var beacon = new PointL(xB, yB);
                sensorFields[i] = new SensorField(sensor, beacon);

            }

            var coveredByBeacon = new HashSet<PointL>();

            foreach (var field in sensorFields)
            {
                var points = field.GetHorizontalIntersectionsPoints(yValue);

                foreach (var point in points)
                {
                    coveredByBeacon.Add(point);
                }
            }

            foreach (var field in sensorFields)
            {
                if (coveredByBeacon.Contains(field.Beacon))
                {
                    coveredByBeacon.Remove(field.Beacon);
                }
            }

            return coveredByBeacon;
        }
    }
}