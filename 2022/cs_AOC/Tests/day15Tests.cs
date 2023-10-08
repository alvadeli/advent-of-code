using day14;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestData;
using Utils;
using Xunit;

namespace Tests
{
    public class day15Tests
    {
        [Fact]
        public void SignalArea_GetCoveredPositions_ReturnsInt() 
        {
            //arrrange
            string file = TestData.Input.GetFile("day15-demo-input.txt");

            //Act
            HashSet<PointL> actual = day15.SignalArea.GetCoveredPositions(file, 10);

            //Assert
            actual.Should().HaveCount(26);

        }

    }
}
