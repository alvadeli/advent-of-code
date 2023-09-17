using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Tests
{
    public class day09Tests
    {
        [Fact]
        public void BridgeWalk_MoveShortRope_ReturnInt()
        {
            //Arrange
            string file = TestData.Input.GetFile("day09-demo-input.txt");
            var walk = day09.BridgeWalk.CreateFromTxt(file);

            //Assert
            int actual = walk.MoveShortRope();

            //Act
            actual.Should().Be(13);
        }

        [Theory]
        [InlineData("day09-demo-input.txt",1)]
        [InlineData("day09-demo-input-2.txt", 36)]
        public void BridgeWalk_MoveLongRope_ReturnLong(string fileName, int expected) 
        {
            //Arrange
            string file = TestData.Input.GetFile(fileName);
            var walk = day09.BridgeWalk.CreateFromTxt(file);

            //Assert
            int actual = walk.MoveLongRope();

            //Act
            actual.Should().Be(expected);
        }
    }
}
