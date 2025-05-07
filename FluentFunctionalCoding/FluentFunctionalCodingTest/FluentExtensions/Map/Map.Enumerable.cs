using FluentFunctionalCoding;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FluentFunctionalCodingTest.FluentExtensions.Map.Enumerable
{
    [TestFixture]
    public class MapEnumerableTests
    {
        [Test]
        public void MapAll_ProjectsAllElements_WhenSourceIsNotNull()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.MapAll(x => x * 2);
            result.Should().BeEquivalentTo(new[] { 2, 4, 6 });
        }

        [Test]
        public void MapAll_ReturnsNull_WhenSourceIsNull()
        {
            IEnumerable<int>? source = null;
            var result = source.MapAll(x => x * 2);
            result.Should().BeNull();
        }

        [Test]
        public void MapAll_ThrowsArgumentNullException_WhenMapFuncIsNull()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, int>? mapFunc = null;
            Assert.Throws<ArgumentNullException>(() => source.MapAll(mapFunc!));
        }
    }
}
