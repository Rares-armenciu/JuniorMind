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
        public int xCoordinate, yCoordinate;
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
        public void TheRouteIntersectsWithItself()
        {
            Directions[] firstRoute = new Directions[] { Directions.Left, Directions.Down, Directions.Down, Directions.Left, Directions.Up, Directions.Right };
            Assert.AreEqual(new Coordinates(4, 6), GetIntersectionPoint(firstRoute));
        }
        [TestMethod]
        public void TheRouteNeverIntersectsWithItself()
        {
            Directions[] firstRoute = new Directions[] { Directions.Left, Directions.Left, Directions.Down, Directions.Down , Directions.Right};
            Assert.AreEqual(new Coordinates(5, 5), GetIntersectionPoint(firstRoute));
        }
        Coordinates GetIntersectionPoint(Directions[] firstRoute)
        {
            int[,] routeMatrix = new int[10, 10];
            int xCoordinate = 5, yCoordinate = 5;
            routeMatrix[xCoordinate , yCoordinate] = 1;
            for(int i=0; i<firstRoute.Length; i++)
            {
                switch (firstRoute[i])
                {
                    case Directions.Down:
                        yCoordinate++;
                        break;
                    case Directions.Up:
                        yCoordinate--;
                        break;
                    case Directions.Left:
                        xCoordinate--;
                        break;
                    case Directions.Right:
                        xCoordinate++;
                        break;
                }
                if (routeMatrix[xCoordinate , yCoordinate] == 1)
                    return new Coordinates(xCoordinate, yCoordinate);
                else routeMatrix[xCoordinate , yCoordinate] = 1;

            }
            return new Coordinates(5, 5);
        }
    }
}
