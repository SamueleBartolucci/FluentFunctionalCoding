using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.Outcome.To
{
    internal class Outcome
    {

        [Test]
        public void Should_ConvertSuccessOutcome_ToOptionalSome()
        {
            var result = "succ".ToOutcome<Exception, string>().ToOptional();
            result.Should().BeOfType<Some<string>>();
            (result as Some<string>)._value.Should().Be("succ");
        }

        [Test]
        public void Should_ConvertSuccessOutcome_ToOptionalFailureNone()
        {
            var result = "succ".ToOutcome<Exception, string>().ToOptionalFailure();
            result.Should().BeOfType<None<Exception>>();
        }

        [Test]
        public void Should_ConvertFailureOutcome_ToOptionalNone()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().ToOptional();
            result.Should().BeOfType<None<string>>();
        }

        [Test]
        public void Should_ConvertFailureOutcome_ToOptionalFailureSome()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().ToOptionalFailure();
            result.Should().BeOfType<Some<Exception>>();
            (result as Some<Exception>)._value.Message.Should().Be("fail");
        }


    }
}
