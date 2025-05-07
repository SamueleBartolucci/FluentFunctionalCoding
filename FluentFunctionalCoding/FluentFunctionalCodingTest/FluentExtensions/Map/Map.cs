using FluentFunctionalCoding;
using FluentAssertions;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentExtensions.Map
{
    [TestFixture]
    public class MapTests
    {
        [Test]
        public void Map_ReturnsMappedValue_WhenSubjectIsNotNull()
        {
            int subject = 2;
            var result = subject.Map(x => x * 2);
            result.Should().Be(4);
        }

        [Test]
        public void Map_ReturnsDefault_WhenSubjectIsNull()
        {
            string? subject = null;
            var result = subject.Map(s => s.Length);
            result.Should().Be(0);

            result = subject.Map(s => s?.Length ?? 100);
            result.Should().Be(0);
        }

        [Test]
        public void Map_ThrowsNullReferenceException_WhenMapFuncIsNull()
        {
            int subject = 5;
            Func<int, int>? mapFunc = null;
            // Should throw ArgumentNullException or similar if mapFunc is null
            Assert.Throws<NullReferenceException>(() => subject.Map(mapFunc!));
        }
    }
}
