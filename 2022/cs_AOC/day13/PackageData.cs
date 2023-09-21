namespace day13
{
    public static class PackageData
    {
        public static int CheckOrder(string file)
        {
            string input = File.ReadAllText(file);

            string[] packetPairs = input.Split("\r\n\r\n");

            int sum = 0;

            for (int i = 1; i <= packetPairs.Length; i++)
            {
                string[] packets = packetPairs[i - 1].Split("\r\n");

                var pleft = PacketParser.ParseFromString(packets[0]);
                var pRight = PacketParser.ParseFromString(packets[1]);

                if (pleft.CompareSize(pRight) == Size.Smaller)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static int GetDecoderKeyFromFile(string file)
        {
            string input = File.ReadAllText(file);
            var packetData = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var packets = new List<Packet>();

            foreach (var packet in packetData)
            {
                packets.Add(PacketParser.ParseFromString(packet));
            }

            return GetDecoderKey(packets);
        }

        public static int GetDecoderKey(List<Packet> packets)
        {
            var p2 = PacketParser.ParseFromString("[[2]]");
            packets.Add(p2);
            var p6 = PacketParser.ParseFromString("[[6]]");
            packets.Add(p6);

            packets.Sort((p1, p2) =>
            {
                Size packetSize = p1.CompareSize(p2);
                return packetSize switch
                {
                    Size.Bigger => 1,
                    Size.Smaller => -1,
                    _ => 0
                };

            });

            int first = packets.IndexOf(p2) + 1;
            int second = packets.IndexOf(p6) + 1;

            return first * second;
        }
    }
}