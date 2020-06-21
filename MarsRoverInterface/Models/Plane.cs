using System;

namespace MarsRoverInterface.Models
{
    public class Plane
    {
        public Point VertexPoint { get; private set; }

        public Plane()
        {
            VertexPoint = new Point();
            VertexPoint.XPosition = int.MaxValue;
            VertexPoint.YPosition = int.MaxValue;
        }

        public void ParseUserInput(string userInput)
        {
            VertexPoint = new Point();
            VertexPoint.GetCoordinatesFromDelimiterInput(userInput);

            if (VertexPoint.XPosition <= 0 || VertexPoint.YPosition <= 0)
                throw new Exception("Invalid Coordinates for Vertex, Inputs should > 0. You Have Provided : " + VertexPoint.XPosition +
                                    ", " + VertexPoint.YPosition);
        }

        public bool IsNewPositionInsideBoundaries(Point proposedPosition)
        {
            if (proposedPosition.XPosition < 0 || proposedPosition.YPosition < 0)
            {
                return false;
            }
            if (proposedPosition.XPosition <= VertexPoint.XPosition &&
                proposedPosition.YPosition <= VertexPoint.YPosition)
            {
                return true;
            }

            return false;
        }
    }
}
