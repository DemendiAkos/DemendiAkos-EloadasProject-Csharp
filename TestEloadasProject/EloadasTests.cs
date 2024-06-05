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
            
            Assert.Throws<ArgumentException>(() => new Eloadas(0, 10));
            Assert.Throws<ArgumentException>(() => new Eloadas(10, 0));
            Assert.Throws<ArgumentException>(() => new Eloadas(-1, 10));
            Assert.Throws<ArgumentException>(() => new Eloadas(10, -1));
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly_WhenRowAndSeatCountArePositive()
        {
            
            var eloadas = new Eloadas(10, 10);

           
            Assert.NotNull(eloadas);
            Assert.AreEqual(100, eloadas.SzabadHelyek);
            Assert.IsFalse(eloadas.Teli);
        }

        [Test]
        public void Lefoglal_ShouldReturnTrue_WhenThereAreFreeSeats()
        {
           
            var eloadas = new Eloadas(2, 2);

           
            var result = eloadas.Lefoglal();

            
            Assert.IsTrue(result);
            Assert.AreEqual(3, eloadas.SzabadHelyek);
        }

        [Test]
        public void Lefoglal_ShouldReturnFalse_WhenThereAreNoFreeSeats()
        {
            
            var eloadas = new Eloadas(1, 1);
            eloadas.Lefoglal();

           
            var result = eloadas.Lefoglal();

           
            Assert.IsFalse(result);
        }

        [Test]
        public void Teli_ShouldReturnTrue_WhenAllSeatsAreBooked()
        {
            
            var eloadas = new Eloadas(1, 1);
            eloadas.Lefoglal();

            
            var isFull = eloadas.Teli;

           
            Assert.IsTrue(isFull);
        }

        [Test]
        public void Foglalt_ShouldReturnTrue_WhenSeatIsBooked()
        {
          
            var eloadas = new Eloadas(1, 1);
            eloadas.Foglal(0, 0);

           
            var isBooked = eloadas.Foglalt(1, 1);

          
            Assert.IsTrue(isBooked);
        }

        [Test]
        public void Foglalt_ShouldReturnFalse_WhenSeatIsNotBooked()
        {
        
            var eloadas = new Eloadas(1, 1);

           
            var isBooked = eloadas.Foglalt(1, 1);

            
            Assert.IsFalse(isBooked);
        }

        [Test]
        public void Foglalt_ShouldThrowArgumentException_WhenRowOrSeatIsInvalid()
        {
            
            var eloadas = new Eloadas(1, 1);

           
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(0, 1));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(1, 0));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(2, 1));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(1, 2));
        }

        [Test]
        public void SzabadHelyek_ShouldReturnCorrectCount()
        {
       
            var eloadas = new Eloadas(2, 2);

      
            eloadas.Lefoglal();
            eloadas.Lefoglal();

            
            Assert.AreEqual(2, eloadas.SzabadHelyek);
        }
    }
}
