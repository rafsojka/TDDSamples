using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;

using SystemUnderTest;

namespace Tests
{
    [TestFixture]
    public class ClassRaisingEventTests
    {
        [TestCase(-30, 0)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(77, 1)]
        [TestCase(100, 1)]
        [TestCase(135, 0)]
        // based on https://stackoverflow.com/a/249042
        public void VerifyPrice_Raises_PriceVerified(int priceReturned, int expectedCount)
        {
            // Arrange
            var mock = new Mock<IPriceGenerator>();
            mock.Setup(foo => foo.GeneratePrice()).Returns(priceReturned);

            var classRaisingEvent = new ClassRaisingEvent(mock.Object);

            var receivedEvents = new List<PriceVerifiedEventArgs>();
            classRaisingEvent.PriceVerified += (s, e) => receivedEvents.Add(e);

            // Act
            classRaisingEvent.VerifyPrice();

            // Assert
            Assert.That(receivedEvents.Count, Is.EqualTo(expectedCount));
            if (receivedEvents.Count > 0)
            {
                Assert.That(receivedEvents[0].Price, Is.EqualTo(priceReturned));
            }
        }
    }
}
