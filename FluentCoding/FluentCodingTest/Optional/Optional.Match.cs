using FluentAssertions;
using FluentCoding;

namespace FluentCodingTest.Optional.Match
{
    internal class Optional
    {
        public int TestParse(string intString) => int.Parse(intString);
        public string TestNoneMap() => "none-test";




        [Test]
        public void Some_MatchNone_Func()
        {
            var optionalString = "1433".ToOptional();
            var matchedValue = optionalString.MatchNone(TestNoneMap);
            matchedValue.Should().BeOfType<string>();
            matchedValue.Should().Be("1433");
        }

        [Test]
        public void Some_MatchNone_Value()
        {
            var optionalString = "1433".ToOptional();
            var matchedValue = optionalString.MatchNone("NONE");
            matchedValue.Should().BeOfType<string>();
            matchedValue.Should().Be("1433");
        }


        [Test]
        public void None_MatchNone_Func()
        {
            var optionalString = Optional<string>.None();
            var matchedValue = optionalString.MatchNone(TestNoneMap);
            matchedValue.Should().BeOfType<string>();
            matchedValue.Should().Be("none-test");
        }

        [Test]
        public void None_MatchNone_Value()
        {
            var optionalString = Optional<string>.None();
            var matchedValue = optionalString.MatchNone("NONE");
            matchedValue.Should().BeOfType<string>();
            matchedValue.Should().Be("NONE");
        }
    }
}
