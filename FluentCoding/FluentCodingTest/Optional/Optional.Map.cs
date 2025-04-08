using FluentAssertions;
using FluentCoding;

namespace FluentCodingTest.Optional.Map
{
    internal class Optional
    {
        public int TestParse(string intString) => int.Parse(intString);
        public string TestNoneMap() => "none-test";




        [Test]
        public void Some_Map_NewType()
        {
            var optionalString = "1433".ToOptional();
            var mappedOptional = optionalString.Map(TestParse);
            mappedOptional.Should().BeOfType<Some<int>>();
            (mappedOptional as Some<int>)._value.Should().Be(1433);
        }

        [Test]
        public void None_Map_NewType()
        {
            var optionalString = Optional<string>.None();
            var mappedOptional = optionalString.Map(TestParse);
            mappedOptional.Should().BeOfType<None<int>>();
        }

        [Test]
        public void Some_MapNone()
        {
            var optionalString = "1433".ToOptional();
            var mappedOptional = optionalString.MapNone(TestNoneMap);
            mappedOptional.Should().BeOfType<Some<string>>();
            (mappedOptional as Some<string>)._value.Should().Be("1433");
        }

        [Test]
        public void None_MapNone()
        {
            var optionalString = Optional<string>.None();
            var mappedOptional = optionalString.MapNone(TestNoneMap);
            mappedOptional.Should().BeOfType<Some<string>>();
            (mappedOptional as Some<string>)._value.Should().Be("none-test");
        }
    }
}
