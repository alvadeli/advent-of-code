using day12;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class day12Tests
    {
        [Fact]
        public void Grid_GetShortesPathDijkstra_ReturnsInt()
        {
            //Arrange
            string input = TestData.Input.GetFile("day12-demo-input.txt");
            var dijkstraInput = Area.CreateDijkstraInputFromFile(input);

            //Act
            int actual = Area.GetShortesPathDijkstra(dijkstraInput.Grid, dijkstraInput.Start, dijkstraInput.End);

            //Assert
            actual.Should().Be(31);
        }

        [Fact]
        public void Grid_FindShortestPathFromA_ReturnsInt()
        {
            //Arrange
            string input = TestData.Input.GetFile("day12-demo-input.txt");
            var dijkstraInput = Area.CreateDijkstraInputFromFile(input);

            //Act
            int actual = Area.FindShortestPathFromA(dijkstraInput);

            //Assert
            actual.Should().Be(29);
        }
    }
}
