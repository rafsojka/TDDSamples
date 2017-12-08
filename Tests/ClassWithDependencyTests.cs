using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SystemUnderTest;
using Moq;

namespace Tests
{
    [TestFixture]
    public class ClassWithDependencyTests
    {
        [TestCase(-30, false)]
        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(77, true)]
        [TestCase(100, true)]
        [TestCase(135, false)]
        public void VerifyPrice_Returns(int priceReturned, bool expectedResult)
        {
            var mock = new Mock<IPriceGenerator>();
            mock.Setup(foo => foo.GeneratePrice()).Returns(priceReturned);

            var classWithDependency = new ClassWithDependency(mock.Object);

            Assert.AreEqual(expectedResult, classWithDependency.VerifyPrice());
        }
    }
}
