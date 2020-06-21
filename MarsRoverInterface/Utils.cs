using MarsRoverInterface.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MarsRoverInterface
{
    public static class Utils
    {
        public static Directions GetDirectionFromUserInput(string input)
        {
            switch (input)
            {
                case "N":
                    return Directions.North;
                case "S":
                    return Directions.South;
                case "W":
                    return Directions.West;
                case "E":
                    return Directions.East;
                default:
                    return Directions.Invalid;
            }
        }

        public static CommandEnum GetCommandFromUserInput(char input)
        {
            switch (input)
            {
                case 'M':
                    return CommandEnum.Move;
                case 'L':
                    return CommandEnum.TurnLeft;
                case 'R':
                    return CommandEnum.TurnRight;
                default:
                    return CommandEnum.Invalid;
            }
        }

        public static List<string> GetDelimiterUserInputs(string input)
        {
            string delimiter = ConfigurationManager.AppSettings.Get("Delimiter");
            return input.Trim().Split(delimiter.ToCharArray()).ToList();
        }
    }
}
