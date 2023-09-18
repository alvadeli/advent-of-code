namespace day05
{
    public static class ListExt
    {
        public static void MoveElementsReversedTo(this List<char> source, List<char> destination, int count)
        {
            for (int i = 0; i < count; i++)
            {
                destination.Add(source.Last());
                source.RemoveAt(source.Count - 1);
            }
        }

        public static void MoveRangeTo(this List<char> source, List<char> destination, int count)
        {
            destination.AddRange(source.TakeLast(count));
            source.RemoveRange(source.Count - count, count);
        }
    }
}
