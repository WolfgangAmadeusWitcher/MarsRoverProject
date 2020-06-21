using System;
using System.Configuration;

namespace MarsRoverInterface.Models
{
    public enum Directions
    {
        Invalid,
        North,
        South,
        East,
        West
    }
    public class Orientation
    {
        public Point Position { get; set; }
        public Directions Direction { get; set; }

        public Orientation(string formattedInput)
        {
            var userInputs = Utils.GetDelimiterUserInputs(formattedInput);

            if (userInputs.Count != 3)
            {
                throw new Exception("An Orientation has 3 Properties, You have entered : " + userInputs.Count);
            }

            Position = new Point();
            Position.GetCoordinatesFromStringInput(userInputs[0], userInputs[1]);

            Direction = Utils.GetDirectionFromUserInput(userInputs[2]);

            if (Direction == Directions.Invalid)
            {
                throw new Exception("You have provided an invalid Direction (N, S, W, E): " + userInputs[2]);
            }
        }

        public string GetCurrentOrientationInformation()
        {
            return Position.GetCurrentPointInformation() + ConfigurationManager.AppSettings.Get("Delimiter") +
                   Direction;
        }
    }
}
