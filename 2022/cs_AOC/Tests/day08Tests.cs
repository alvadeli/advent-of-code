using day08;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class day08Tests
    {
        private readonly TreeGrid _treeGrid;
        public day08Tests() 
        {
            string file = TestData.Input.GetFile("day08-demo-input.txt");
            _treeGrid = TreeGrid.CreateFromTxt(file);
        }


        [Fact]
        public void TreeGrid_GetVisibleTrees_ReturnInt()
        {
            //Arrange

            //Act
            int actual =_treeGrid.GetVisibleTrees();

            //Assert
            actual.Should().Be(21);

        }

        [Fact]
        public void TreeGrid_GetScenicScore_ReturnInt()
        {
            //Arrange

            //Act
            int actual = _treeGrid.GetScenicScore();

            //Assert
            actual.Should().Be(8);
        }
    }
}
