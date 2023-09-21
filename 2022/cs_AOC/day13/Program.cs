using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile();
            int sum = PackageData.CheckOrder(file);
            Console.WriteLine("Part 1: Sum={0}", sum);
            int decoderKey = PackageData.GetDecoderKeyFromFile(file);
            Console.WriteLine("Part 1: Decoder Key={0}", decoderKey);
        }
    }
}