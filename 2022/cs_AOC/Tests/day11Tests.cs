using day11;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class day11Tests
    {
        [Theory]
        [InlineData("old + 6", 6, 12)]
        [InlineData("old * old", 6, 36)]
        [InlineData("old / 6", 36, 6)]
        [InlineData("old - 5", 10, 5)]
        public void PlayerParser_CreateFunction_ReturnFunc(string expression, long oldValue, long expected)
        {
            //Arrange
            Func<long, long> function = PlayerParser.CreateFunction(expression);

            //Act
            long actual = function(oldValue);

            //Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, 20,10605)]
        [InlineData(false, 1, 4 * 6)]
        [InlineData(false, 20, 99*103)]
        [InlineData(false, 10000, 2713310158)]
        public void KeepAway_Play_ReturnsInt(bool decreaseWorryLevel, int rounds, long expected) 
        {
            //Arrange
            string input = TestData.Input.GetFile("day11-demo-input.txt");

            //Act
            long actual = KeepAway.Play(input, rounds, decreaseWorryLevel);

            //Assert
            actual.Should().Be(expected);
        }

    }
}
