using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FluentFunctionalCodingTest.FluentExtensions.Or.Enumerable
{
    [TestFixture]
    public class OrEnumerableTests
    {
        [Test]
        public void OrWhenEmpty_ReturnsLeft_WhenNotEmpty()
        {
            var left = new List<int> { 1, 2 };
            var right = new List<int> { 3, 4 };
            var result = left.OrWhenEmpty(right);            
            left.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_ReturnsRight_WhenEmpty()
        {
            var left = new List<int>();
            var right = new List<int> { 3, 4 };
            var result = left.OrWhenEmpty(right);
            right.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_ChooseRightTrue_ReturnsRight()
        {
            var left = new List<int> { 1, 2 };
            var right = new List<int> { 3, 4 };
            var result = left.OrWhenEmpty(right, true);
            right.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenFunc_ReturnsRight_WhenFuncTrue()
        {
            var left = new List<int> { 1, 2 };
            var right = new List<int> { 3, 4 };
            var result = left.OrWhenEmpty(right, () => true);
            right.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenFunc_ReturnsLeft_WhenFuncFalse()
        {
            var left = new List<int> { 1, 2 };
            var right = new List<int> { 3, 4 };
            var result = left.OrWhenEmpty(right, () => false);
            left.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenEnumerableFunc_ReturnsRight_WhenFuncTrue()
        {
            var left = new List<int> { 1, 2 };
            var right = new List<int> { 3, 4 };
            var result = left.OrWhenEmpty(right, l => l.Count() == 2);
            right.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_ChooseRightWhenEnumerableFunc_ReturnsLeft_WhenFuncFalse()
        {
            var left = new List<int> { 1, 2 };
            var right = new List<int> { 3, 4 };
            var result = left.OrWhenEmpty(right, l => l.Count() == 3);
            left.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ReturnsRight_WhenLeftEmpty()
        {
            var left = new List<int>();
            var result = left.OrWhenEmpty(() => new List<int> { 5, 6 });
            result.Should().BeEquivalentTo(new List<int> { 5, 6 });
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ReturnsLeft_WhenNotEmpty()
        {
            var left = new List<int> { 7 };
            var result = left.OrWhenEmpty(() => new List<int> { 8, 9 });
            left.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightTrue_ReturnsRight()
        {
            var left = new List<int> { 1 };
            var result = left.OrWhenEmpty(() => new List<int> { 2, 3 }, true);
            result.Should().BeEquivalentTo(new List<int> { 2, 3 });
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenFunc_ReturnsRight_WhenFuncTrue()
        {
            var left = new List<int> { 1 };
            var result = left.OrWhenEmpty(() => new List<int> { 2, 3 }, () => true);
            result.Should().BeEquivalentTo(new List<int> { 2, 3 });
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenFunc_ReturnsLeft_WhenFuncFalse()
        {
            var left = new List<int> { 1 };
            var result = left.OrWhenEmpty(() => new List<int> { 2, 3 }, () => false);
            left.Should().BeEquivalentTo(result);
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenEnumerableFunc_ReturnsRight_WhenFuncTrue()
        {
            var left = new List<int> { 1 };
            var result = left.OrWhenEmpty(() => new List<int> { 2, 3 }, l => l.Count() == 1);
            result.Should().BeEquivalentTo(new List<int> { 2, 3 });
        }

        [Test]
        public void OrWhenEmpty_FuncRight_ChooseRightWhenEnumerableFunc_ReturnsLeft_WhenFuncFalse()
        {
            var left = new List<int> { 1 };
            var result = left.OrWhenEmpty(() => new List<int> { 2, 3 }, l => l.Count() == 2);
            left.Should().BeEquivalentTo(result);
        }
    }
}
