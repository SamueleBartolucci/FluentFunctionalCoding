using FluentFunctionalCoding;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentExtensions.Map
{
    [TestFixture]
    public class MapTaskTests
    {
        [Test]
        public async Task MapAsync_ReturnsMappedValue_WhenTaskCompletes()
        {
            Task<int> subject = Task.FromResult(3);
            var result = await subject.MapAsync(x => x + 1);
            result.Should().Be(4);
        }

        [Test]
        public void MapAsync_ThrowsNullReferenceException_WhenMapFuncIsNull()
        {
            Task<int> subject = Task.FromResult(3);
            Func<int, int>? mapFunc = null;
            Assert.ThrowsAsync<NullReferenceException>(async () => await subject.MapAsync(mapFunc!));
        }
    }
}
