using System;
using MarsRoverInterface.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoverTests
{
    [TestClass]
    public class PlaneTests
    {
        [TestMethod]
        public void Plane_WithValidEntry_InitializeCorrectly()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 5");

            Assert.AreEqual(5, testPlane.VertexPoint.XPosition);
            Assert.AreEqual(5, testPlane.VertexPoint.YPosition);
        }

        [TestMethod]
        public void Plane_WithValidEntry_InitializeCorrectly2()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("79 18");

            Assert.AreEqual(79, testPlane.VertexPoint.XPosition);
            Assert.AreEqual(18, testPlane.VertexPoint.YPosition);
        }

        [TestMethod]
        public void Plane_WithInValidEntry_InvalidPointEntry()
        {
            Plane testPlane = new Plane();
            Assert.ThrowsException<InvalidCastException>(() => testPlane.ParseUserInput("7 1.1"));
        }

        [TestMethod]
        public void Plane_WithInValidEntry_InvalidVertexEntry()
        {
            Plane testPlane = new Plane();
            Assert.ThrowsException<Exception>(() => testPlane.ParseUserInput("7 0"));
        }

        [TestMethod]
        public void Plane_WithInValidEntry_InvalidVertexEntry2()
        {
            Plane testPlane = new Plane();
            Assert.ThrowsException<Exception>(() => testPlane.ParseUserInput("0 7"));
        }

        [TestMethod]
        public void Plane_WithInValidEntry_InvalidVertexEntry3()
        {
            Plane testPlane = new Plane();
            Assert.ThrowsException<Exception>(() => testPlane.ParseUserInput("7 -2"));
        }

        [TestMethod]
        public void Plane_WithValidEntry_IsInsideBoundariesTrue()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 5");

            Point testPoint = new Point();
            testPoint.GetCoordinatesFromDelimiterInput("2 3");
            Assert.AreEqual(true, testPlane.IsNewPositionInsideBoundaries(testPoint));
        }

        [TestMethod]
        public void Plane_WithValidEntry_IsInsideBoundariesTrueEqualsToVertex()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 5");

            Point testPoint = new Point();
            testPoint.GetCoordinatesFromDelimiterInput("5 5");
            Assert.AreEqual(true, testPlane.IsNewPositionInsideBoundaries(testPoint));
        }

        [TestMethod]
        public void Plane_WithInValidEntry_IsInsideBoundariesFalse()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 5");

            Point testPoint = new Point();
            testPoint.GetCoordinatesFromDelimiterInput("7 4");
            Assert.AreEqual(false, testPlane.IsNewPositionInsideBoundaries(testPoint));
        }

        [TestMethod]
        public void Plane_WithInValidEntry_IsInsideBoundariesFalseLessThenZero()
        {
            Plane testPlane = new Plane();
            testPlane.ParseUserInput("5 5");

            Point testPoint = new Point();
            testPoint.GetCoordinatesFromDelimiterInput("-1 4");
            Assert.AreEqual(false, testPlane.IsNewPositionInsideBoundaries(testPoint));
        }

        [TestMethod]
        public void Plane_DefaultConstructor_PlaneShouldBeMaxSizeBeforeUserInput()
        {
            Plane testPlane = new Plane();

            Assert.AreEqual(int.MaxValue, testPlane.VertexPoint.XPosition);
            Assert.AreEqual(int.MaxValue, testPlane.VertexPoint.YPosition);
        }
    }
}
