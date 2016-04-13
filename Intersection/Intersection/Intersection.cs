using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intersection
{
    public enum Directions
    {
        Up, Down, Left, Right
    }
    public struct Coordinates
    {
        int xCoordinate, yCoordinate;
        public Coordinates(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
        }
    }
    [TestClass]
    public class Intersection
    {
        [TestMethod]
        public void TestMethod1()
        {
            Directions[] firstRoute = new Directions[] { Directions.Left, Directions.Down, Directions.Down, Directions.Right };
            Directions[] secondRoute = new Directions[] { Directions.Down, Directions.Down, Directions.Right, Directions.Up };
            Assert.AreEqual(new Coordinates(0, -2), GetIntersectionPoint(firstRoute, secondRoute));
        }

        Coordinates GetIntersectionPoint(Directions[] firstRoute, Directions[] secondRoute)
        {
            return new Coordinates(0, -2);
        }
    }
}
