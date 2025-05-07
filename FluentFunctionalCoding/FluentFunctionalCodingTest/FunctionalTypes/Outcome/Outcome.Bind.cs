using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.Outcome.Bind
{
    internal class Outcome
    {
        public Outcome<Exception, int> FuncWithOutcomeResult(string s) => int.TryParse(s, out var result)
                                                                             .Map(parsed => result.ToOutcome(_ => !parsed, new Exception("parse failure")));

        public Outcome<Exception, int> FuncWithOutcomeResultFailure(string s) => new Exception(s).ToOutcomeFailure<Exception, int>();

        public Outcome<string, string> FuncWithOutcomeResultFAilure(Exception e) => e.Message.ToOutcomeFailure<string, string>();

        [Test]
        public void Bind_ShouldReturnSuccess_WhenInputIsValid()
        {

            var result = "1".ToOutcome<Exception, string>().Bind(FuncWithOutcomeResult);
            result.Should().BeOfType<Right<Exception, int>>();
            (result as Right<Exception, int>)._successValue.Should().Be(1);
        }

        [Test]
        public void BindFailure_ShouldReturnSuccess_WhenNoFailure()
        {

            var result = "1".ToOutcome<Exception, string>().BindFailure(FuncWithOutcomeResultFAilure);
            result.Should().BeOfType<Right<string, string>>();
            (result as Right<string, string>)._successValue.Should().Be("1");
        }

        [Test]
        public void BindFull_ShouldReturnSuccess_WhenInputIsValid()
        {

            var result = "1".ToOutcome<string, string>().BindFull(FuncWithOutcomeResult, FuncWithOutcomeResultFailure);
            result.Should().BeOfType<Right<Exception, int>>();
            (result as Right<Exception, int>)._successValue.Should().Be(1);
        }

        [Test]
        public void Bind_ShouldReturnFailure_WhenInputIsInvalid()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().Bind(FuncWithOutcomeResult);
            result.Should().BeOfType<Left<Exception, int>>();
            (result as Left<Exception, int>)._failureValue.Message.Should().Be("parse failure");
        }

        [Test]
        public void BindFailure_ShouldReturnFailure_WhenInputIsInvalid()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().BindFailure(FuncWithOutcomeResultFAilure);
            result.Should().BeOfType<Left<string, string>>();
            (result as Left<string, string>)._failureValue.Should().Be("parse failure");
        }

        [Test]
        public void BindFull_ShouldReturnFailure_WhenInputIsInvalid()
        {

            var result = "parse failure".ToOutcomeFailure<string, string>().BindFull(FuncWithOutcomeResult, FuncWithOutcomeResultFailure);
            result.Should().BeOfType<Left<Exception, int>>();
            (result as Left<Exception, int>)._failureValue.Message.Should().Be("parse failure");
        }

    }
}
