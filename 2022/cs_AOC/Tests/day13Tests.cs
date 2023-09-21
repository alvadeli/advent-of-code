using day13;
using FluentAssertions;
using System.Drawing;
using Xunit;
using Size = day13.Size;

namespace Tests
{
    public class day13Tests
    {

        private Dictionary<string, Packet> _testPacketData;

        public day13Tests()
        {
            _testPacketData = CreateTestPackets();
        }

        [Theory]
        [InlineData("[1,1,3,1,1]",
                    "[1,1,5,1,1]",
                    Size.Smaller)]
        [InlineData("[[1],[2,3,4]]",
                    "[[1],4]",
                    Size.Smaller)]
        [InlineData("[9]",
                    "[[8,7,6]]",
                    Size.Bigger)]
        [InlineData("[[4,4],4,4]",
                    "[[4,4],4,4,4]",
                    Size.Smaller)]
        [InlineData("[7,7,7,7]",
                    "[7,7,7]",
                    Size.Bigger)]
        [InlineData("[]",
                    "[3]",
                    Size.Smaller)]
        [InlineData("[[[]]]",
                    "[[]]",
                    Size.Bigger)]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]",
                    "[1,[2,[3,[4,[5,6,0]]]],8,9]",
                    Size.Bigger)]
        public void PackageData_CheckOrder_ReturnsSize(string packetLeftText, string packetRightText, Size expected)
        {
            //Arrange
            var packetLeft = _testPacketData[packetLeftText];
            var packetRight = _testPacketData[packetRightText];
            
            //Act
            var actual = packetLeft.IsSmaller(packetRight);

            //Assert
            actual.Should().Be(expected);

        }

        [Theory]
        [InlineData("[1,1,3,1,1]")]
        [InlineData("[1,1,5,1,1]")]
        [InlineData("[[1],[2,3,4]]")]
        [InlineData("[[1],4]")]
        [InlineData("[9]")]
        [InlineData("[[8,7,6]]")]
        [InlineData("[[4,4],4,4]")]
        [InlineData("[[4,4],4,4,4]")]
        [InlineData("[7,7,7,7]")]
        [InlineData("[7,7,7]")]
        [InlineData("[]")]
        [InlineData("[3]")]
        [InlineData("[[[]]]")]
        [InlineData("[[]]")]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]")]
        [InlineData("[1,[2,[3,[4,[5,6,0]]]],8,9]")]

        public void NodeParser_ParseFromString(string text) 
        {
            //Arrange
            var expected = _testPacketData[text];

            //Act
            var actual = PacketParser.ParseFromString(text);

            //Assert

            actual.Should().BeEquivalentTo(expected);
        }

        private Dictionary<string, Packet> CreateTestPackets()
        {

            var res = new Dictionary<string, Packet>();

            var p_L = new Packet();
            var p_V0 = new Packet(0);
            var p_V1 = new Packet(1);
            var p_V2 = new Packet(2);
            var p_V3 = new Packet(3);
            var p_V4 = new Packet(4);
            var p_V5 = new Packet(5);
            var p_V6 = new Packet(6);
            var p_V7 = new Packet(7);
            var p_V8 = new Packet(8);
            var p_V9 = new Packet(9);

            string packetText = "[1,1,3,1,1]";
            var p_L11311 = new Packet(new List<Packet>() { p_V1, p_V1, p_V3, p_V1, p_V1 });
            res.Add(packetText, p_L11311);

            packetText = "[1,1,5,1,1]";
            var p_L11511 = new Packet(new List<Packet>() { p_V1, p_V1, p_V5, p_V1, p_V1 });
            res.Add(packetText, p_L11511);

            packetText = "[[1],[2,3,4]]";
            var p_L44 = new Packet(new List<Packet>() { p_V1 });
            var p_L234 = new Packet(new List<Packet>() { p_V2, p_V3, p_V4 });
            var p_L1_L234 = new Packet(new List<Packet>() { p_L44, p_L234 });
            res.Add(packetText, p_L1_L234);

            packetText = "[[1],4]";
            var p_L1_V4 = new Packet(new List<Packet>() { p_L44, p_V4 });
            res.Add(packetText, p_L1_V4);

            packetText = "[9]";
            res.Add(packetText, p_V9);

            packetText = "[[8,7,6]]";
            var p_L876 = new Packet(new List<Packet>() { p_V8, p_V7, p_V6 });
            res.Add(packetText, p_L876);

            packetText = "[[4,4],4,4]";
            p_L44 = new Packet(new List<Packet>() { p_V4, p_V4 });
            var p_L44_V4_V4 = new Packet(new List<Packet>() { p_L44, p_V4, p_V4 });
            res.Add(packetText, p_L44_V4_V4);

            packetText = "[[4,4],4,4,4]";
            p_L44 = new Packet(new List<Packet>() { p_V4, p_V4 });
            var p_L44_V4_V4_V4 = new Packet(new List<Packet>() { p_L44, p_V4, p_V4, p_V4 });
            res.Add(packetText, p_L44_V4_V4_V4);


            packetText = "[7,7,7,7]";
            var p_V7_V7_V7_V7 = new Packet(new List<Packet>() { p_V7, p_V7, p_V7, p_V7 });
            res.Add(packetText, p_V7_V7_V7_V7);

            packetText = "[7,7,7]";
            var p_V7_V7_V7 = new Packet(new List<Packet>() { p_V7, p_V7, p_V7 });
            res.Add(packetText, p_V7_V7_V7);

            packetText = "[]";
            res.Add(packetText, p_L);

            packetText = "[3]";
            res.Add(packetText, p_V3);

            packetText = "[[[]]]";
            var p_L_L = new Packet(new List<Packet> { p_L });
            var p_L_L_L = new Packet(new List<Packet>() { p_L_L });
            res.Add(packetText, p_L_L_L);

            packetText = "[[]]";
            res.Add(packetText, p_L_L);

            packetText = "[1,[2,[3,[4,[5,6,7]]]],8,9]";
            var p_L567 = new Packet(new List<Packet> { p_V5, p_V6, p_V7 });
            var p_V4_L567 = new Packet(new List<Packet> { p_V4, p_L567 });
            var p_V3_V4_L567 = new Packet(new List<Packet> { p_V3, p_V4_L567 });
            var p_V2_V3_V4_L567 = new Packet(new List<Packet> { p_V2, p_V3_V4_L567 });
            var p_V1_V2_V3_V4_L567 = new Packet(new List<Packet> { p_V1, p_V2_V3_V4_L567, p_V8, p_V9 });
            res.Add(packetText, p_V1_V2_V3_V4_L567);

            packetText = "[1,[2,[3,[4,[5,6,0]]]],8,9]";
            var p_L560 = new Packet(new List<Packet> { p_V5, p_V6, p_V0 });
            var p_V4_L560 = new Packet(new List<Packet> { p_V4, p_L560 });
            var p_V3_V4_L560 = new Packet(new List<Packet> { p_V3, p_V4_L560 });
            var p_V2_V3_V4_L560 = new Packet(new List<Packet> { p_V2, p_V3_V4_L560 });
            var p_V1_V2_V3_V4_L560 = new Packet(new List<Packet> { p_V1, p_V2_V3_V4_L560, p_V8, p_V9 });
            res.Add(packetText, p_V1_V2_V3_V4_L560);

            return res;
        }


    }

}

