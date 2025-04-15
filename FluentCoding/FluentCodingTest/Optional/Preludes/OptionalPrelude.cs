using FluentAssertions;
using FluentFunctionalCoding;

namespace FluentCodingTest.Optional.Preludes
{
    internal class Optional
    {
        [Test]
        public void SomeFromValue()
        {
            string nonNullObject = "test";
            var someOfObject = nonNullObject.ToOptional();
            someOfObject.Should().BeOfType<Some<string>>();
            (someOfObject as Some<string>)._value.Should().Be(nonNullObject);
        }

        [Test]
        public void SomeFromNull()
        {
            string nullObject = null;
            nullObject.ToOptional().Should().BeOfType<None<string>>();
        }
    }
}
