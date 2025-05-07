using FluentFunctionalCoding;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentExtensions.Or
{
    [TestFixture]
    public class OrTests
    {
        [Test]
        public void Or_ReturnsLeft_WhenLeftIsNotNull()
        {
            string left = "left";
            string right = "right";
            var result = left.Or(right);
            Assert.AreEqual("left", result);
        }

        [Test]
        public void Or_ReturnsRight_WhenLeftIsNull()
        {
            string left = null;
            string right = "right";
            var result = left.Or(right);
            Assert.AreEqual("right", result);
        }
    }
}
