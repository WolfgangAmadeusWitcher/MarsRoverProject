using System;
using System.Collections.Generic;

namespace MarsRoverInterface.Models
{
    public enum CommandEnum
    {
        Invalid,
        TurnLeft,
        TurnRight,
        Move
    }
    public class Rover
    {
        public Orientation CurrentOrientation { get; set; }
        public List<string> RoverLog { get; set; } = new List<string>();
        public int Id { get; set; }

        public Rover(int id)
        {
            Id = id;
        }

        public void DeployRover(string orientationInput, Plane plane)
        {
            CurrentOrientation = new Orientation(orientationInput);
            if (!plane.IsNewPositionInsideBoundaries(CurrentOrientation.Position))
                throw new Exception("Rover Can not be Deployed Outside Plane Boundaries");
            RoverLog.Add("Rover deployed and ready for Mission");
            AddOrientationLogEntry();
        }

        private void MoveRover(Plane plane)
        {
            Point proposedPoint = GetNextMovementPoint();
            if (plane.IsNewPositionInsideBoundaries(proposedPoint))
            {
                CurrentOrientation.Position = proposedPoint;
                AddOrientationLogEntry();
            }
            else
            {
                RoverLog.Add("Rover is on the Edge of the plane and can not move to the proposed Direction!");
            }
        }

        public void ProcessUserCommands(string input, Plane environment)
        {
            var commandList = input.ToCharArray();
            foreach (var command in commandList)
            {
                CommandEnum newCommand = Utils.GetCommandFromUserInput(command);
                ProcessCommand(newCommand, environment);
            }
        }

        public string GetOrientationResult()
        {
            return CurrentOrientation.GetCurrentOrientationInformation();
        }

        private void ProcessCommand(CommandEnum newCommand, Plane currentPlane)
        {
            RoverLog.Add("Rover is Performing New User Command : " + newCommand);
            switch (newCommand)
            {
                case CommandEnum.TurnLeft:
                    TurnLeft();
                    break;
                case CommandEnum.TurnRight:
                    TurnRight();
                    break;
                case CommandEnum.Move:
                    MoveRover(currentPlane);
                    break;
                case CommandEnum.Invalid:
                    break;
            }
        }

        private Point GetNextMovementPoint()
        {
            Point newPosition = new Point
            {
                XPosition = CurrentOrientation.Position.XPosition,
                YPosition = CurrentOrientation.Position.YPosition
            };
            switch (CurrentOrientation.Direction)
            {
                case Directions.North:
                    newPosition.YPosition++;
                    break;
                case Directions.South:
                    newPosition.YPosition--;
                    break;
                case Directions.East:
                    newPosition.XPosition++;
                    break;
                case Directions.West:
                    newPosition.XPosition--;
                    break;
            }

            return newPosition;
        }

        private void TurnLeft()
        {
            switch (CurrentOrientation.Direction)
            {
                case Directions.North:
                    CurrentOrientation.Direction = Directions.West;
                    break;
                case Directions.South:
                    CurrentOrientation.Direction = Directions.East;
                    break;
                case Directions.East:
                    CurrentOrientation.Direction = Directions.North;
                    break;
                case Directions.West:
                    CurrentOrientation.Direction = Directions.South;
                    break;
            }
            AddOrientationLogEntry();
        }

        private void TurnRight()
        {
            switch (CurrentOrientation.Direction)
            {
                case Directions.North:
                    CurrentOrientation.Direction = Directions.East;
                    break;
                case Directions.South:
                    CurrentOrientation.Direction = Directions.West;
                    break;
                case Directions.East:
                    CurrentOrientation.Direction = Directions.South;
                    break;
                case Directions.West:
                    CurrentOrientation.Direction = Directions.North;
                    break;
            }
            AddOrientationLogEntry();
        }

        private void AddOrientationLogEntry()
        {
            RoverLog.Add("Rover is at Coordinates : (" + CurrentOrientation.Position.XPosition + ", " + CurrentOrientation.Position.YPosition + ") and Facing : " + CurrentOrientation.Direction);
        }
    }
}
