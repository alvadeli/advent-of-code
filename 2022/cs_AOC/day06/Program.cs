namespace day06
{
    public class Program
    {

        static void Main(string[] args)
        {
            string file =Utils.Input.GetInputFile(false);
            string datastream = File.ReadAllText(file);

            int markerEndPostion = DataStreamAnalyser.GetEndPostionOfType(datastream, DataStreamAnalyser.Type.Marker);
            Console.WriteLine("Part1: First marker after character: {0}", markerEndPostion);

            markerEndPostion = DataStreamAnalyser.GetEndPostionOfType(datastream, DataStreamAnalyser.Type.Message);
            Console.WriteLine("Part1: First message after character: {0}", markerEndPostion);
        }

 
    }
}