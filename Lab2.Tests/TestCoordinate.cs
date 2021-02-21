using System;
using Xunit;

namespace Lab2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestPlus()
        {
            var coordinate1 = new Coordinate(1, 2);
            var coordinate2 = new Coordinate(3, 4);
            var coordinateResult = coordinate1 + coordinate2;
            var coordinateExpected = new Coordinate(4, 6);
            Assert.True
            (
                coordinateResult.X == coordinateExpected.X
                && coordinateResult.Y == coordinateExpected.Y
            );
        }
        [Fact]
        public void TestMinus()
        {
            var coordinate1 = new Coordinate(1, 2);
            var coordinate2 = new Coordinate(3, 4);
            var coordinateResult = coordinate1 - coordinate2;
            var coordinateExpected = new Coordinate(-2, -2);
            Assert.True
            (
                coordinateResult.X == coordinateExpected.X
                && coordinateResult.Y == coordinateExpected.Y
            );
        }
        [Fact]
        public void TestEqual()
        {
            var coordinate1 = new Coordinate(1, 1);
            var coordinate2 = new Coordinate(1, 1);
            Assert.True((coordinate1 == coordinate2) == true);
        }
        [Fact]
        public void TestNotEqual()
        {
            var coordinate1 = new Coordinate(1, 1);
            var coordinate2 = new Coordinate(1, 2);
            Assert.True((coordinate1 == coordinate2) == false);
        }
        [Fact]
        public void TestToString()
        {
            var coordinate1 = new Coordinate(1, 1);
            var expectedString = "Coordinate <x: 1, y: 1>";
            Assert.True(expectedString == coordinate1.ToString());
        }
        
    }
}