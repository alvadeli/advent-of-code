namespace day13
{
    public static class PacketParser
    {
        public static Packet ParseFromString(string text )
        {
            Packet currentPacket = new Packet();
            int openBrackets = 0;
            string number = "";
            foreach (var chr in text)
            {
                if (chr == '[')
                {
                   

                    if (openBrackets > 0)
                    {
                        Packet parent = currentPacket;
                        currentPacket = new Packet();
                        currentPacket.Parent = parent;
                    }
                    openBrackets++;
                }

                if (char.IsNumber(chr))
                {
                    number += chr;
                 
                }

                if (chr ==',')
                {
                    if (!string.IsNullOrEmpty(number)) currentPacket.AddValue(int.Parse(number));
                    number = "";
                }

                if (chr == ']')
                {
                    if (!string.IsNullOrEmpty(number)) currentPacket.AddValue(int.Parse(number));
                    number = "";
                    openBrackets--;
                    if (openBrackets>0)
                    {
                        currentPacket.Parent.AddChild(currentPacket);
                        currentPacket = currentPacket.Parent;
                    }
                }

            }

            return currentPacket;
        }
    }
}