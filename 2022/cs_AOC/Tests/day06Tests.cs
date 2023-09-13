using day06;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class day06Tests
    {
        [Theory]
        //Marker
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", DataStreamAnalyser.Type.Marker, 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", DataStreamAnalyser.Type.Marker, 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", DataStreamAnalyser.Type.Marker, 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", DataStreamAnalyser.Type.Marker, 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", DataStreamAnalyser.Type.Marker, 11)]

        //Messages
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", DataStreamAnalyser.Type.Message, 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", DataStreamAnalyser.Type.Message, 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", DataStreamAnalyser.Type.Message, 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", DataStreamAnalyser.Type.Message, 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", DataStreamAnalyser.Type.Message, 26)]

        public void DataStreamAnalyser_GetEndPostionOfType_ReturnInt(string datastream,DataStreamAnalyser.Type type,  int expected)
        {
            //Arrange

            //Act
            int actual = DataStreamAnalyser.GetEndPostionOfType(datastream,type);

            //Assert
            actual.Should().Be(expected);
        }
    }
}
