using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.Outcome.Match
{
    internal class Outcome
    {
        public int FuncMatchSuccess(string s) => int.Parse(s);

        public int FuncMatchFailure(Exception e) => -99;

        public Outcome<string, string> FuncWithOutcomeResultFAilure(Exception e) => e.Message.ToOutcomeFailure<string, string>();

        [Test]
        public void Match_ShouldReturnSuccessValue_WhenOutcomeIsSuccess_UsingFunc()
        {
            var result = "1".ToOutcome<Exception, string>().Match(FuncMatchSuccess, FuncMatchFailure);
            result.Should().Be(1);
        }

        [Test]
        public void Match_ShouldReturnSuccessValue_WhenOutcomeIsSuccess_UsingValue()
        {
            var result = "1".ToOutcome<Exception, string>().Match(FuncMatchSuccess, 3);
            result.Should().Be(1);
        }

        [Test]
        public void Match_ShouldReturnFailureValue_WhenOutcomeIsFailure_UsingFunc()
        {
            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().Match(FuncMatchSuccess, FuncMatchFailure);
            result.Should().Be(-99);
        }

        [Test]
        public void Match_ShouldReturnFailureValue_WhenOutcomeIsFailure_UsingValue()
        {
            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().Match(FuncMatchSuccess, -199);
            result.Should().Be(-199);
        }
    }
}
