using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using FluentFunctionalCoding;

namespace FluentFunctionalCodingTest.FluentExtensions.Misc
{
    public class TaskExtensionsTests
    {
        [Test]
        public async Task ToTask_ReturnsCompletedTaskWithValue()
        {
            int value = 42;
            var task = value.ToTask();
            var result = await task;
            result.Should().Be(42);
        }
    }
}
