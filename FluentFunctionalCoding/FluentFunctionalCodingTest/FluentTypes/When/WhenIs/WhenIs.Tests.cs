using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentTypes.When.WhenIs
{
    public class WhenIsIsTests
    {
        [Test]
        public void Is_WithBool_ShouldReturnTrueOrFalseBasedOnInput()
        {
            var whenIs = new WhenIs<int>(5);
            var result = whenIs.Is(true);
            result.IsTrue.Should().BeTrue();
            result.IsFalse.Should().BeFalse();
            result = whenIs.Is(false);
            result.IsTrue.Should().BeFalse();
            result.IsFalse.Should().BeTrue();
        }

        [Test]
        public void Is_WithFuncBoolArray_ShouldReturnTrueIfAllFuncsTrue()
        {
            var whenIs = new WhenIs<int>(5);
            var result = whenIs.Is(() => true, () => true);
            result.IsTrue.Should().BeTrue();
            result = whenIs.Is(() => true, () => false);
            result.IsTrue.Should().BeFalse();
        }

        [Test]
        public void Is_WithFuncTBoolArray_ShouldReturnTrueIfAllFuncsTrueForValue()
        {
            var whenIs = new WhenIs<int>(5);
            var result = whenIs.Is(x => x == 5, x => x > 0);
            result.IsTrue.Should().BeTrue();
            result = whenIs.Is(x => x == 5, x => x < 0);
            result.IsTrue.Should().BeFalse();
        }

        [Test]
        public void IsNull_WithNull_ShouldReturnTrue()
        {
            var whenIs = new WhenIs<string>(null);
            var result = whenIs.IsNull();
            result.IsTrue.Should().BeTrue();            
        }

        [Test]
        public void IsNull_WithValue_ShouldReturnFalse()
        {
            var whenIs = new WhenIs<string>("not null");
            var result = whenIs.IsNull();
            result.IsTrue.Should().BeFalse();
        }

        [Test]
        public void IsNotNull_WithNull_ShouldReturnFalse()
        {
            var whenIs = new WhenIs<string>(null);
            var result = whenIs.IsNotNull();
            result.IsTrue.Should().BeFalse();
        }

        [Test]
        public void IsNotNull_WithValue_ShouldReturnTrueFalse()
        {
            var whenIs = new WhenIs<string>("not null");
            var result = whenIs.IsNotNull();
            result.IsTrue.Should().BeTrue();
        }
    }
}
