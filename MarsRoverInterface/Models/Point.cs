using System;
using System.Configuration;

namespace MarsRoverInterface.Models
{
    public class Point
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public void GetCoordinatesFromDelimiterInput(string rawUserInput)
        {
            var userInputs = Utils.GetDelimiterUserInputs(rawUserInput);

            if (userInputs.Count != 2)
                throw new Exception("A Point has 2 Coordinates, You have entered : " + userInputs.Count);

            GetCoordinatesFromStringInput(userInputs[0], userInputs[1]);
        }

        public void GetCoordinatesFromStringInput(string inputX, string inputY)
        {
            bool successX = int.TryParse(inputX, out var resultX);
            bool successY = int.TryParse(inputY, out var resultY);

            if (successX && successY)
            {
                XPosition = resultX;
                YPosition = resultY;
            }
            else
            {
                throw new InvalidCastException("Input for Coordinate is not a valid Integer.");
            }
        }

        public string GetCurrentPointInformation()
        {
            return XPosition + ConfigurationManager.AppSettings.Get("Delimiter") + YPosition;
        }
    }
}
