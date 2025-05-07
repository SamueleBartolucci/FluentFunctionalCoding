using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentTypes.When.WhenIs
{
    public class WhenIsBoolExtensionsTests
    {
        [Test]
        public void IsTrue_ShouldReturnIsTrue_WhenValueIsTrue()
        {
            var whenIs = new WhenIs<bool>(true);
            var result = whenIs.IsTrue();
            result.IsTrue.Should().BeTrue();
            result.IsFalse.Should().BeFalse();
        }

        [Test]
        public void IsTrue_ShouldReturnIsFalse_WhenValueIsFalse()
        {
            var whenIs = new WhenIs<bool>(false);
            var result = whenIs.IsTrue();
            result.IsTrue.Should().BeFalse();
            result.IsFalse.Should().BeTrue();
        }

        [Test]
        public void IsFalse_ShouldReturnIsFalse_WhenValueIsTrue()
        {
            var whenIs = new WhenIs<bool>(true);
            var result = whenIs.IsFalse();
            result.IsTrue.Should().BeFalse();
            result.IsFalse.Should().BeTrue();
        }

        [Test]
        public void IsFalse_ShouldReturnIsTrue_WhenValueIsFalse()
        {
            var whenIs = new WhenIs<bool>(false);
            var result = whenIs.IsFalse();
            result.IsTrue.Should().BeTrue();
            result.IsFalse.Should().BeFalse();
        }
    }
}
