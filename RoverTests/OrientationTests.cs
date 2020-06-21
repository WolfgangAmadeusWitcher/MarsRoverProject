using System;
using MarsRoverInterface.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoverTests
{
    [TestClass]
    public class OrientationTests
    {
        [TestMethod]
        public void Orientation_WithValidEntry_InitializeCorrectly()
        {
            Orientation testOrientation = new Orientation("7 9 N");

            Assert.AreEqual(7, testOrientation.Position.XPosition);
            Assert.AreEqual(9, testOrientation.Position.YPosition);
            Assert.AreEqual(Directions.North, testOrientation.Direction);
        }
        [TestMethod]
        public void Orientation_WithValidEntry_InitializeCorrectly2()
        {
            Orientation testOrientation = new Orientation("18 74 S");

            Assert.AreEqual(18, testOrientation.Position.XPosition);
            Assert.AreEqual(74, testOrientation.Position.YPosition);
            Assert.AreEqual(Directions.South, testOrientation.Direction);
        }

        [TestMethod]
        public void Orientation_WithInValidDirectionEntry_ShouldThrowException()
        {
            Assert.ThrowsException<Exception>(() => new Orientation("18 74 A"));
        }

        [TestMethod]
        public void Orientation_WithInValidInputHigherThen3_ShouldThrowException()
        {
            Assert.ThrowsException<Exception>(() => new Orientation("18 74 S N"));
        }

        [TestMethod]
        public void Orientation_WithInValidInputLessThen3_ShouldThrowException()
        {
            Assert.ThrowsException<Exception>(() => new Orientation("18 74"));
        }

        [TestMethod]
        public void Orientation_WithValidInput_GetOrientationInformationProperly()
        {
            Orientation testOrientation = new Orientation("18 74 S");
            testOrientation.Direction = Directions.North;

            Assert.AreEqual("18 74 North", testOrientation.GetCurrentOrientationInformation());
        }
    }
}
