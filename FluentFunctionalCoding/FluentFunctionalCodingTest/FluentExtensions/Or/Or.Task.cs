using FluentFunctionalCoding;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentExtensions.OrTask
{
    [TestFixture]
    public class OrTaskTests
    {
        [Test]
        public async Task OrAsync_ReturnsLeft_WhenLeftIsNotNull()
        {
            Task<string> left = Task.FromResult("left");
            string right = "right";
            var result = await left.OrAsync(right);
            result.Should().Be("left");
        }

        [Test]
        public async Task OrAsync_ReturnsRight_WhenLeftIsNull()
        {
            Task<string?> left = Task.FromResult<string?>(null);
            string right = "right";
            var result = await left.OrAsync(right);
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithChooseRightTrue_ReturnsRight()
        {
            Task<string> left = Task.FromResult("left");
            string right = "right";
            var result = await left.OrAsync(right, chooseRight: true);
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithChooseRightWhenFunc_ReturnsRight_WhenPredicateTrue()
        {
            Task<string> left = Task.FromResult("left");
            string right = "right";
            var result = await left.OrAsync(right, () => true);
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithChooseRightWhenFunc_ReturnsLeft_WhenPredicateFalse()
        {
            Task<string> left = Task.FromResult("left");
            string right = "right";
            var result = await left.OrAsync(right, () => false);
            result.Should().Be("left");
        }

        [Test]
        public async Task OrAsync_WithChooseRightWhenFuncT_ReturnsRight_WhenPredicateTrue()
        {
            Task<string> left = Task.FromResult("left");
            string right = "right";
            var result = await left.OrAsync(right, l => l == "left");
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithChooseRightWhenFuncT_ReturnsLeft_WhenPredicateFalse()
        {
            Task<string> left = Task.FromResult("left");
            string right = "right";
            var result = await left.OrAsync(right, l => l == "other");
            result.Should().Be("left");
        }

        [Test]
        public async Task OrAsync_WithRightFactory_ReturnsLeft_WhenLeftIsNotNull()
        {
            Task<string> left = Task.FromResult("left");
            var result = await left.OrAsync(() => "right");
            result.Should().Be("left");
        }

        [Test]
        public async Task OrAsync_WithRightFactory_ReturnsRight_WhenLeftIsNull()
        {
            Task<string?> left = Task.FromResult<string?>(null);
            var result = await left.OrAsync(() => "right");
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithRightFactory_ChooseRightTrue_ReturnsRight()
        {
            Task<string> left = Task.FromResult("left");
            var result = await left.OrAsync(() => "right", chooseRight: true);
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithRightFactory_ChooseRightWhenFunc_ReturnsRight_WhenPredicateTrue()
        {
            Task<string> left = Task.FromResult("left");
            var result = await left.OrAsync(() => "right", () => true);
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithRightFactory_ChooseRightWhenFunc_ReturnsLeft_WhenPredicateFalse()
        {
            Task<string> left = Task.FromResult("left");
            var result = await left.OrAsync(() => "right", () => false);
            result.Should().Be("left");
        }

        [Test]
        public async Task OrAsync_WithRightFactory_ChooseRightWhenFuncT_ReturnsRight_WhenPredicateTrue()
        {
            Task<string> left = Task.FromResult("left");
            var result = await left.OrAsync(() => "right", l => l == "left");
            result.Should().Be("right");
        }

        [Test]
        public async Task OrAsync_WithRightFactory_ChooseRightWhenFuncT_ReturnsLeft_WhenPredicateFalse()
        {
            Task<string> left = Task.FromResult("left");
            var result = await left.OrAsync(() => "right", l => l == "other");
            result.Should().Be("left");
        }
    }
}
