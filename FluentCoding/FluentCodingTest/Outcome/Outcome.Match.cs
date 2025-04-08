using FluentAssertions;
using FluentCoding;


namespace FluentCodingTest.Outcome.Match
{
    internal class Outcome
    {
        public int FuncMatchSuccess(string s) => int.Parse(s);

        public int FuncMatchFailure(Exception e) => -99;

        public Outcome<string, string> FuncWithOutcomeResultFAilure(Exception e) => e.Message.ToOutcomeFailure<string, string>();

        [Test]
        public void Success_Match_Func()
        {
            var result = "1".ToOutcome<Exception, string>().Match(FuncMatchSuccess, FuncMatchFailure);
            result.Should().Be(1);
        }

        [Test]
        public void Success_Match_Value()
        {
            var result = "1".ToOutcome<Exception, string>().Match(FuncMatchSuccess, 3);
            result.Should().Be(1);
        }


        [Test]
        public void Failure_Match_Func()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().Match(FuncMatchSuccess, FuncMatchFailure);
            result.Should().Be(-99);
        }

        [Test]
        public void Failure_Match_ValueFunc()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().Match(FuncMatchSuccess, -199);
            result.Should().Be(-199);
        }

    }
}
