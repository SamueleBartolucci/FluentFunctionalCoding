using FluentAssertions;
using FluentCoding;


namespace FluentCodingTest.Optional.Bind
{
    internal class Optional
    {
        public Optional<int> FuncWithOptionalResult(string s) => int.TryParse(s, out var result)
                                                                    .When()
                                                                    .IsTrue()
                                                                    .Match(@true => result.ToOptional(), @false => Optional<int>.None());

        public Optional<string> FuncOnNone() => "none".ToOptional();

        [Test]
        public void Some_Bind()
        {

            var result = "1".ToOptional().Bind(FuncWithOptionalResult);
            result.Should().BeOfType<Some<int>>();
            (result as Some<int>)._value.Should().Be(1);
        }

        [Test]
        public void Some_BindNone()
        {

            var result = "1".ToOptional().BindNone(FuncOnNone);
            result.Should().BeOfType<Some<string>>();
            (result as Some<string>)._value.Should().Be("1");
        }



        [Test]
        public void None_Bind()
        {
            var result = Optional<string>.None().Bind(FuncWithOptionalResult);
            result.Should().BeOfType<None<int>>();
        }

        [Test]
        public void None_BindNone()
        {
            var result = Optional<string>.None().BindNone(FuncOnNone);
            result.Should().BeOfType<Some<string>>();
            (result as Some<string>)._value.Should().Be("none");
        }
    }
}
