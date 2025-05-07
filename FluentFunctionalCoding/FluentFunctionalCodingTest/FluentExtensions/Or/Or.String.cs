using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentExtensions.Or.String
{
    [TestFixture]
    public class OrStringTests
    {
        [Test]
        public void OrWhenEmpty_ReturnsLeft_WhenNotEmpty()
        {
            string left = "not empty";
            string right = "right";
            var result = left.OrWhenEmpty(right);
            result.Should().BeEquivalentTo("not empty");
        }

        [Test]
        public void OrWhenEmpty_ReturnsRight_WhenEmpty()
        {
            string left = "";
            string right = "right";
            var result = left.OrWhenEmpty(right);
            result.Should().BeEquivalentTo("right");
        }

        [Test]
        public void OrWhenEmpty_ChooseRightTrue_ReturnsRight()
        {
            string left = "not empty";
            string right = "right";
            var result = left.OrWhenEmpty(right, true);
            result.Should().BeEquivalentTo("right");
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenFunc_ReturnsRight_WhenFuncTrue()
        {
            string left = "not empty";
            string right = "right";
            var result = left.OrWhenEmpty(right, () => true);
            result.Should().BeEquivalentTo("right");
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenFunc_ReturnsLeft_WhenFuncFalse()
        {
            string left = "not empty";
            string right = "right";
            var result = left.OrWhenEmpty(right, () => false);
            result.Should().BeEquivalentTo("not empty");
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenStringFunc_ReturnsRight_WhenFuncTrue()
        {
            string left = "not empty";
            string right = "right";
            var result = left.OrWhenEmpty(right, l => l.Length > 0);
            result.Should().BeEquivalentTo("right");
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenStringFunc_ReturnsLeft_WhenFuncFalse()
        {
            string left = "not empty";
            string right = "right";
            var result = left.OrWhenEmpty(right, l => l.Length == 0);
            result.Should().BeEquivalentTo("not empty");
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ReturnsRight_WhenLeftEmpty()
        {
            string left = "";
            var result = left.OrWhenEmpty(() => "fallback");
            result.Should().BeEquivalentTo("fallback");
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ReturnsLeft_WhenNotEmpty()
        {
            string left = "not empty";
            var result = left.OrWhenEmpty(() => "fallback");
            result.Should().BeEquivalentTo("not empty");
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightTrue_ReturnsRight()
        {
            string left = "not empty";
            var result = left.OrWhenEmpty(() => "fallback", true);
            result.Should().BeEquivalentTo("fallback");
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenFunc_ReturnsRight_WhenFuncTrue()
        {
            string left = "not empty";
            var result = left.OrWhenEmpty(() => "fallback", () => true);
            result.Should().BeEquivalentTo("fallback");
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenFunc_ReturnsLeft_WhenFuncFalse()
        {
            string left = "not empty";
            var result = left.OrWhenEmpty(() => "fallback", () => false);
            result.Should().BeEquivalentTo("not empty");
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenStringFunc_ReturnsRight_WhenFuncTrue()
        {
            string left = "not empty";
            var result = left.OrWhenEmpty(() => "fallback", l => l.Length > 0);
            result.Should().BeEquivalentTo("fallback");
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenStringFunc_ReturnsLeft_WhenFuncFalse()
        {
            string left = "not empty";
            var result = left.OrWhenEmpty(() => "fallback", l => l.Length == 0);
            result.Should().BeEquivalentTo("not empty");
        }
    }
}
