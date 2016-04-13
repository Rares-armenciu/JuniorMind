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
        public void TestMethod1()
        {
            Directions[] firstRoute = new Directions[] { Directions.Left, Directions.Down, Directions.Down, Directions.Right };
            Directions[] secondRoute = new Directions[] { Directions.Down, Directions.Down, Directions.Right, Directions.Up };
            Assert.AreEqual(new Coordinates(0, -2), GetIntersectionPoint(firstRoute, secondRoute));
        }

        Coordinates GetIntersectionPoint(Directions[] firstRoute, Directions[] secondRoute)
        {
            int x1 = 0, y1 = 0;
            for(int i=0; i<firstRoute.Length; i++)
            {
                int x2 = 0, y2 = 0;
                switch (firstRoute[i])
                {
                    case Directions.Down:
                        y1--;
                        break;
                    case Directions.Up:
                        y1++;
                        break;
                    case Directions.Left:
                        x1--;
                        break;
                    case Directions.Right:
                        x1++;
                        break;
                }
                Coordinates firstRoutePosition = new Coordinates(x1, y1);
                for(int j=0; j<secondRoute.Length; j++)
                {
                    switch (secondRoute[j])
                    {
                        case Directions.Down:
                            y2--;
                            break;
                        case Directions.Up:
                            y2++;
                            break;
                        case Directions.Left:
                            x2--;
                            break;
                        case Directions.Right:
                            x2++;
                            break;
                    }
                    Coordinates secondRoutePosition = new Coordinates(x2, y2);
                    if (firstRoutePosition.Equals(secondRoutePosition))
                        return firstRoutePosition;
                }

            }
            return new Coordinates(0, 0);
        }
    }
}
