using FluentAssertions;
using FluentCoding;


namespace FluentCodingTest.Outcome.Map
{
    internal class Outcome
    {
        public int FuncMapSuccess(string s) => int.Parse(s);

        public string FuncMapFailure(Exception e) => e.Message;

        public Outcome<string, string> FuncWithOutcomeResultFAilure(Exception e) => e.Message.ToOutcomeFailure<string, string>();

        [Test]
        public void Success_MapSuccess()
        {

            var result = "1".ToOutcome<Exception, string>().MapSuccess(FuncMapSuccess);
            result.Should().BeOfType<Right<Exception, int>>();
            (result as Right<Exception, int>)._successValue.Should().Be(1);
        }

        [Test]
        public void Success_MapFailure()
        {

            var result = "1".ToOutcome<Exception, string>().MapFailure(FuncMapFailure);
            result.Should().BeOfType<Right<string, string>>();
            (result as Right<string, string>)._successValue.Should().Be("1");
        }

        [Test]
        public void Success_Map()
        {

            var result = "1".ToOutcome<Exception, string>().Map(FuncMapSuccess, FuncMapFailure);
            result.Should().BeOfType<Right<string, int>>();
            (result as Right<string, int>)._successValue.Should().Be(1);
        }

        [Test]
        public void Failure_MapSuccess()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().MapSuccess(FuncMapSuccess);
            result.Should().BeOfType<Left<Exception, int>>();
            (result as Left<Exception, int>)._failureValue.Message.Should().Be("parse failure");
        }

        [Test]
        public void Failure_BindFailure()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().MapFailure(FuncMapFailure);
            result.Should().BeOfType<Left<string, string>>();
            (result as Left<string, string>)._failureValue.Should().Be("parse failure");
        }

        [Test]
        public void Failure_BindFull()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().Map(FuncMapSuccess, FuncMapFailure);
            result.Should().BeOfType<Left<string, int>>();
            (result as Left<string, int>)._failureValue.Should().Be("parse failure");
        }

    }
}
