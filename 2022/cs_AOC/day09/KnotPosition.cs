using System.Diagnostics;

namespace day09
{
    [DebuggerDisplay("x = {X}, y={Y}")]
    public class KnotPosition
    {
        public KnotPosition() { }


        public KnotPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is KnotPosition position &&
                   X == position.X &&
                   Y == position.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public void MakeStepTowardsKnot(KnotPosition knot)
        {
            X += DistanceX(knot);
            Y += DistanceY(knot);
        }

        public bool IsTouching(KnotPosition other)
        {
            return Math.Abs(X - other.X) <= 1 && Math.Abs(Y - other.Y) <= 1;
        }

        public int DistanceX(KnotPosition other)
        {
            if (X < other.X) return 1;
            if (X > other.X) return -1;
            return 0;
        }

        public int DistanceY(KnotPosition other)
        {
            if (Y < other.Y) return 1;
            if (Y > other.Y) return -1;
            return 0;
        }
    }

}