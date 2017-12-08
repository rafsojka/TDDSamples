using System;
using NUnit.Framework;
using SystemUnderTest;

namespace Tests
{
    [TestFixture]
    public class SimpleClassTests
    {
        [TestCase("input1", "input 1")]
        [TestCase("input2", "input 2")]
        public void SimpleMethod_Returns(string input, string expectedOutput)
        {
            var simpleClass = new SimpleClass();
            Assert.That(expectedOutput, Is.EqualTo(simpleClass.SimpleMethod(input)));
        }

        [Test]
        public void SimpleMethod_Throws()
        {
            var simpleClass = new SimpleClass();

            //Exception ex = Assert.Throws<Exception>(
            //    delegate { simpleClass.SimpleMethod("fakeString"); });

            Exception ex = Assert.Throws<Exception>(() => simpleClass.SimpleMethod("fakeString"));

            Assert.That(ex, Is.TypeOf(typeof(Exception)));
        }

    }
}
