using day10;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class day10Tests
    {
        [Fact]
        public void CPU_SignalStrengthSum_ReturnInt() 
        {
            //Arrange
            var cpu = new CPU();
            string file = TestData.Input.GetFile("day10-demo-input.txt");

            //Act
            int actual = cpu.SignalStrengthSum(file);

            //Assert
            actual.Should().Be(13140);
        }

        [Fact]
        public void CRT_GetImage_ReturnString()
        {
            //Arrange
            var crt = new CRT();
            string file = TestData.Input.GetFile("day10-demo-input.txt");
            string expected = "##..##..##..##..##..##..##..##..##..##..\n" +
                              "###...###...###...###...###...###...###.\n" +
                              "####....####....####....####....####....\n" +
                              "#####.....#####.....#####.....#####.....\n" +
                              "######......######......######......####\n" +
                              "#######.......#######.......#######.....";

            //Act
            string actual = crt.GetImage(file);

            //Assert
            actual.Should().Be(expected);
        }
    }
}
