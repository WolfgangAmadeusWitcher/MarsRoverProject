using System;
using MarsRoverInterface.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoverTests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void Point_WithValidEntry_InitializeCorrectly()
        {
            Point testPoint = new Point();
            testPoint.GetCoordinatesFromDelimiterInput("5 10");

            Assert.AreEqual(5, testPoint.XPosition);
            Assert.AreEqual(10, testPoint.YPosition);
        }

        [TestMethod]
        public void Point_WithValidEntry_InitializeCorrectlyTrailingEmptySpace()
        {
            Point testPoint = new Point();
            testPoint.GetCoordinatesFromDelimiterInput("       7 1203       ");

            Assert.AreEqual(7, testPoint.XPosition);
            Assert.AreEqual(1203, testPoint.YPosition);
        }

        [TestMethod]
        public void Point_WithInvalidEntry_CoordinationIsNotInteger()
        {
            Point testPoint = new Point();

            Assert.ThrowsException<InvalidCastException>(() => testPoint.GetCoordinatesFromDelimiterInput("7 1.1"));
        }

        [TestMethod]
        public void Point_WithInvalidEntry_CoordinationIsNotInteger2()
        {
            Point testPoint = new Point();

            Assert.ThrowsException<InvalidCastException>(() => testPoint.GetCoordinatesFromDelimiterInput("7 Ş"));
        }

        [TestMethod]
        public void Point_WithInvalidEntry_MoreThenTwoInputsEntered()
        {
            Point testPoint = new Point();

            Assert.ThrowsException<Exception>(() => testPoint.GetCoordinatesFromDelimiterInput("7 5 9"));
        }

        [TestMethod]
        public void Point_WithInvalidEntry_LessThenTwoInputEntered()
        {
            Point testPoint = new Point();

            Assert.ThrowsException<Exception>(() => testPoint.GetCoordinatesFromDelimiterInput("7"));
        }

        [TestMethod]
        public void Point_WithInvalidEntry_WhiteSpaceInTheMiddle()
        {
            Point testPoint = new Point();

            Assert.ThrowsException<Exception>(() => testPoint.GetCoordinatesFromDelimiterInput("7    5"));
        }

        [TestMethod]
        public void Point_WithValidEntry_GetPointInformation()
        {
            Point testPoint = new Point();
            testPoint.GetCoordinatesFromStringInput("7", "9");

            Assert.AreEqual("7 9", testPoint.GetCurrentPointInformation());
        }
    }
}
