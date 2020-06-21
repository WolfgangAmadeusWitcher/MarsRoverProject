using System;
using MarsRoverInterface.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void Rover_WithValidEntry_InitializeProperly()
        {
            Plane testPlane = new Plane();
            Rover testRover = new Rover(1);
            testRover.DeployRover("5 6 E", testPlane);

            Assert.AreEqual(5, testRover.CurrentOrientation.Position.XPosition);
            Assert.AreEqual(6, testRover.CurrentOrientation.Position.YPosition);
            Assert.AreEqual(Directions.East, testRover.CurrentOrientation.Direction);
        }

        [TestMethod]
        public void Rover_WithValidEntry_GetInformationCorrectly()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 18");
            Rover testRover = new Rover(1);
            testRover.DeployRover("4 6 E", testPlane);
            testRover.ProcessUserCommands("M", testPlane);

            Assert.AreEqual("5 6 East", testRover.GetOrientationResult());
        }


        [TestMethod]
        public void Rover_WithValidEntry_RoverShouldNotMovePastPlaneBoundary()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 5");

            Rover testRover = new Rover(1);
            testRover.DeployRover("5 5 E", testPlane);
            testRover.ProcessUserCommands("M", testPlane);

            Assert.AreEqual("5 5 East", testRover.GetOrientationResult());
        }

        [TestMethod]
        public void Rover_WithValidEntry_RoverRotate()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 5");

            Rover testRover = new Rover(1);
            testRover.DeployRover("5 5 E", testPlane);
            testRover.ProcessUserCommands("L", testPlane);

            Assert.AreEqual("5 5 North", testRover.GetOrientationResult());
        }


        [TestMethod]
        public void Rover_WithInValidEntry_RoverDoesNotTakeAnyActionWithInvalidCommand()
        {
            Plane testPlane = new Plane();

            Rover testRover = new Rover(1);
            testRover.DeployRover("5 5 E", testPlane);
            testRover.ProcessUserCommands("AOY", testPlane);

            Assert.AreEqual("5 5 East", testRover.GetOrientationResult());
        }
    }
}
