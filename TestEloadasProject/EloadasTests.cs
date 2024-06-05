using System;
using NUnit.Framework;

namespace EloadasProject.Tests
{
    [TestFixture]
    public class EloadasTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenRowOrSeatCountIsZeroOrNegative()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Eloadas(0, 10));
            Assert.Throws<ArgumentException>(() => new Eloadas(10, 0));
            Assert.Throws<ArgumentException>(() => new Eloadas(-1, 10));
            Assert.Throws<ArgumentException>(() => new Eloadas(10, -1));
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly_WhenRowAndSeatCountArePositive()
        {
            // Arrange & Act
            var eloadas = new Eloadas(10, 10);

            // Assert
            Assert.NotNull(eloadas);
            Assert.AreEqual(100, eloadas.SzabadHelyek);
            Assert.IsFalse(eloadas.Teli);
        }

        [Test]
        public void Lefoglal_ShouldReturnTrue_WhenThereAreFreeSeats()
        {
            // Arrange
            var eloadas = new Eloadas(2, 2);

            // Act
            var result = eloadas.Lefoglal();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(3, eloadas.SzabadHelyek);
        }

        [Test]
        public void Lefoglal_ShouldReturnFalse_WhenThereAreNoFreeSeats()
        {
            // Arrange
            var eloadas = new Eloadas(1, 1);
            eloadas.Lefoglal();

            // Act
            var result = eloadas.Lefoglal();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Teli_ShouldReturnTrue_WhenAllSeatsAreBooked()
        {
            // Arrange
            var eloadas = new Eloadas(1, 1);
            eloadas.Lefoglal();

            // Act
            var isFull = eloadas.Teli;

            // Assert
            Assert.IsTrue(isFull);
        }

        [Test]
        public void Foglalt_ShouldReturnTrue_WhenSeatIsBooked()
        {
            // Arrange
            var eloadas = new Eloadas(1, 1);
            eloadas.Foglal(0, 0);

            // Act
            var isBooked = eloadas.Foglalt(1, 1);

            // Assert
            Assert.IsTrue(isBooked);
        }

        [Test]
        public void Foglalt_ShouldReturnFalse_WhenSeatIsNotBooked()
        {
            // Arrange
            var eloadas = new Eloadas(1, 1);

            // Act
            var isBooked = eloadas.Foglalt(1, 1);

            // Assert
            Assert.IsFalse(isBooked);
        }

        [Test]
        public void Foglalt_ShouldThrowArgumentException_WhenRowOrSeatIsInvalid()
        {
            // Arrange
            var eloadas = new Eloadas(1, 1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(0, 1));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(1, 0));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(2, 1));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(1, 2));
        }

        [Test]
        public void SzabadHelyek_ShouldReturnCorrectCount()
        {
            // Arrange
            var eloadas = new Eloadas(2, 2);

            // Act
            eloadas.Lefoglal(); // 1 seat booked
            eloadas.Lefoglal(); // 2 seats booked

            // Assert
            Assert.AreEqual(2, eloadas.SzabadHelyek);
        }
    }
}
