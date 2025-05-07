using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentTypes.Try.To
{
    internal class Try
    {
        Try<string, int, string> GetSuccess(string intValueAsString) => new Success<string, int, string>(intValueAsString, int.Parse(intValueAsString)).As<Try<string, int, string>>();
        Try<string, int, string> GetFailure(string intValueAsString) => new Failure<string, int, string>(intValueAsString, "parsing failed", new FormatException("parsing failed")).As<Try<string, int, string>>();

        [Test]
        public void ToOptional_Success_ShouldReturnSome()
        {
            GetSuccess("42").ToOptional().Do(
                o => o.Should().BeOfType<Some<int>>(),
                o => o.IsSome.Should().BeTrue(),
                o => o.IsNone.Should().BeFalse(),
                o => (o as Some<int>)._value.Should().Be(42));
        }

        [Test]
        public void ToOptional_Failure_ShouldReturnNone()
        {
            GetFailure("42").ToOptional().Do(
                o => o.Should().BeOfType<None<int>>(),
                o => o.IsSome.Should().BeFalse(),
                o => o.IsNone.Should().BeTrue());
        }

        [Test]
        public void ToOutcome_Success_ShouldReturnRight()
        {
            var outcome = GetSuccess("42").ToOutcome();
            outcome.Should().BeOfType<Right<string, int>>();
            outcome.IsSuccess.Should().BeTrue();
            outcome.IsFailure.Should().BeFalse();
            (outcome as Right<string, int>)._successValue.Should().Be(42);
        }

        [Test]
        public void ToOutcome_Failure_ShouldReturnLeft()
        {
            GetFailure("42").ToOutcome().Do(
                o => o.Should().BeOfType<Left<string, int>>(),
                o => o.IsSuccess.Should().BeFalse(),
                o => o.IsFailure.Should().BeTrue(),
                o => (o as Left<string, int>)._failureValue.Should().Be("parsing failed"));
        }

        [Test]
        public void ToOutcomeUsingException_Success_ShouldReturnRight()
        {
            var outcome = GetSuccess("42").ToOutcomeUsingException();
            outcome.Should().BeOfType<Right<Exception, int>>();
            outcome.IsSuccess.Should().BeTrue();
            outcome.IsFailure.Should().BeFalse();
            (outcome as Right<Exception, int>)._successValue.Should().Be(42);
        }

        [Test]
        public void ToOutcomeUsingException_Failure_ShouldReturnLeft()
        {
            GetFailure("42").ToOutcomeUsingException().Do(
                o => o.Should().BeOfType<Left<Exception, int>>(),
                o => o.IsSuccess.Should().BeFalse(),
                o => o.IsFailure.Should().BeTrue(),
                o => (o as Left<Exception, int>)._failureValue.Message.Should().Be("parsing failed"));
        }
    }
}
