using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            result.Should().BeOfType<OptionalJust<int>>();
            (result as OptionalJust<int>)._value.Should().Be(1);
        }

        [Test]
        public void Some_BindNone()
        {

            var result = "1".ToOptional().BindNone(FuncOnNone);
            result.Should().BeOfType<OptionalJust<string>>();
            (result as OptionalJust<string>)._value.Should().Be("1");
        }



        [Test]
        public void None_Bind()
        {
            var result = Optional<string>.None().Bind(FuncWithOptionalResult);
            result.Should().BeOfType<OptionalNone<int>>();            
        }

        [Test]
        public void None_BindNone()
        {
            var result = Optional<string>.None().BindNone(FuncOnNone);
            result.Should().BeOfType<OptionalJust<string>>();
            (result as OptionalJust<string>)._value.Should().Be("none");
        }
    }
}
