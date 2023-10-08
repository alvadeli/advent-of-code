
using day14;
using FluentAssertions;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class day14Tests
    {
        private readonly bool[,] grid = new bool[10, 10]
                                            {
                                                {true,true,true,true,true,true,true,true,true,true },
                                                {true,true,true,true,true,true,true,true,true,true },
                                                {true,true,true,true,true,true,true,true,true,true },
                                                {true,true,true,true,true,true,true,true,true,true },
                                                {true,true,true,true,false,true,true,true,false,false },
                                                {true,true,true,true,false,true,true,true,false,true },
                                                {true,true,false,false,false,true,true,true,false,true },
                                                {true,true,true,true,true,true,true,true,false,true },
                                                {true,true,true,true,true,true,true,true,false,true },
                                                {false,false,false,false,false,false,false,false,false,true },
                                            };

        private Cave _testCave;



        public day14Tests() 
        {
            var sandStart = new Utils.Point(6, 0);
            _testCave = new Cave(grid, sandStart);
        }




        [Fact]
        public void Cave_CreateFromFile_ReturnsMatrix()
        {
            //Arrange
            string file = Input.GetFile("day14-demo-input.txt");


            //Act
            Cave actual = Cave.CreateFromFile(file);


            //Assert
            actual.Should().BeEquivalentTo(_testCave);
        }

        [Fact]
        public void Cave_ProduceSand_ReturnsInt()
        {
            //Arrange

            //Act
            int actual = _testCave.ProduceSand();

            //Assert
            actual.Should().Be(24);
        }

    }
}
