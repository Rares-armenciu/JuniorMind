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
            Assert.AreEqual(new Coordinates(-1, 1), GetIntersectionPoint(firstRoute));
        }
        [TestMethod]
        public void TheRouteNeverIntersectsWithItself()
        {
            Directions[] firstRoute = new Directions[] { Directions.Left, Directions.Left, Directions.Down, Directions.Down , Directions.Right};
            Assert.AreEqual(new Coordinates(0, 0), GetIntersectionPoint(firstRoute));
        }
        Coordinates GetIntersectionPoint(Directions[] firstRoute)
        {
            int xCoordinate = 0, yCoordinate = 0;
            Coordinates[] route = new Coordinates[firstRoute.Length];
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
                route[i] = new Coordinates(xCoordinate, yCoordinate);
                for (int j = 0; j < i; j++)
                    if (route[j].xCoordinate == route[i].xCoordinate && route[j].yCoordinate == route[i].yCoordinate)
                        return route[i];
            }
            return new Coordinates(0, 0);
        }
    }
}
