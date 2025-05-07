using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentTypes.When.WhenIs
{
    public class WhenIsBoolExtensionsTests
    {
        [Test]
        public void IsTrue_Returns_WhenTrue()
        {
            var whenIs = new WhenIs<bool>(true);
            var result = whenIs.IsTrue();
            result.IsTrue.Should().BeTrue();
            result.IsFalse.Should().BeFalse();
        }

        [Test]
        public void IsTrue_Returns_WhenFalse()
        {
            var whenIs = new WhenIs<bool>(false);
            var result = whenIs.IsTrue();
            result.IsTrue.Should().BeFalse();
            result.IsFalse.Should().BeTrue();
        }

        [Test]
        public void IsFalse_Returns_WhenTrue()
        {
            var whenIs = new WhenIs<bool>(true);
            var result = whenIs.IsFalse();
            result.IsTrue.Should().BeFalse();
            result.IsFalse.Should().BeTrue();
        }

        [Test]
        public void IsFalse_Returns_WhenFalse()
        {
            var whenIs = new WhenIs<bool>(false);
            var result = whenIs.IsFalse();
            result.IsTrue.Should().BeTrue();
            result.IsFalse.Should().BeFalse();
        }
    }
}
