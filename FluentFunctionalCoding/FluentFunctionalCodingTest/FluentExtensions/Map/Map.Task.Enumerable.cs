using FluentFunctionalCoding;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentExtensions.MapTask.Enumerable
{
    [TestFixture]
    public class MapTaskEnumerableTests
    {
        [Test]
        public async Task MapAllAsync_ProjectsAllElements_WhenTaskCompletes()
        {
            Task<IEnumerable<int>> subject = Task.FromResult<IEnumerable<int>>(new[] { 1, 2, 3 });
            var result = await subject.MapAllAsync(x => x * 3);
            result.Should().BeEquivalentTo(new[] { 3, 6, 9 });
        }

        [Test]
        public async Task MapAllAsync_List_ProjectsAllElements()
        {
            Task<List<int>> subject = Task.FromResult(new List<int> { 2, 4 });
            var result = await subject.MapAllAsync(x => x + 1);
            result.Should().BeEquivalentTo(new[] { 3, 5 });
        }

        [Test]
        public async Task MapAllAsync_Array_ProjectsAllElements()
        {
            Task<int[]> subject = Task.FromResult(new[] { 5, 6 });
            var result = await subject.MapAllAsync(x => x * 2);
            result.Should().BeEquivalentTo(new[] { 10, 12 });
        }

        [Test]
        public void MapAllAsync_Throws_WhenMapFuncIsNull()
        {
            Task<IEnumerable<int>> subject = Task.FromResult<IEnumerable<int>>(new[] { 1, 2 });
            Func<int, int>? mapFunc = null;
            Assert.ThrowsAsync<ArgumentNullException>(async () => await subject.MapAllAsync(mapFunc!));
        }
    }
}
