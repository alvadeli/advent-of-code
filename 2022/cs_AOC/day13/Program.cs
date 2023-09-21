using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Sockets;
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
        }
    }

    public static class PackageData
    {
        public static int CheckOrder(string file)
        {
            string input = File.ReadAllText(file);

            string[] packetPairs = input.Split("\r\n\r\n");

            int sum = 0;

            for (int i = 1; i <= packetPairs.Length; i++)
            {
                Console.WriteLine("==========");
                Console.WriteLine("Packet {0}", i);

                Console.WriteLine(packetPairs[i-1]);
                string[] packets = packetPairs[i - 1].Split("\r\n");

                var pleft = PacketParser.ParseFromString(packets[0]);
                var pRight = PacketParser.ParseFromString(packets[1]);

                if (pleft.IsSmaller(pRight) == Size.Smaller)
                {
                    Console.WriteLine("Pairs are in the right order");
                    sum += i;
                }


            }

            return sum;
        }
    }
}