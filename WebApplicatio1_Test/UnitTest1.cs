
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WebApplicatio1_Test

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void valorEnergiaTest()
        {
            // Arrange
            int a = 300;
            int b = 1000;
            int expected = 300000;

            // Act
            int actual;
            actual = a * b;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void valorTotalEnergia()
        {
            // Arrange
            int a = 300000;
            int b = (3000 - 2000) * 850;
            int expected = -550000;

            // Act
            int actual;
            actual = a - b;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void valorTotal()
        {
            // Arrange
            int a = 300000;
            int b = -550000;
            int expected = -250000;

            // Act
            int actual;
            actual = a + b;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void valorAgua()
        {
            // Arrange
            int a = 5000;
            int b = 500;
            int expected = 2500000;

            // Act
            int actual;
            actual = a * b;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void promedioEnergia()
        {
            // Arrange
            int a = (50000 + 30000 + 40000);
            int b = 3;
            int expected = 40000;

            // Act
            int actual;
            actual = a / b;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void clientesConExcesoAgua()
        {
            // Arrange
            int a = 5;
            int b = 10;
            int expected = 50;

            // Act
            int actual;
            actual = (int)((double)a / b * 100);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}