using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            result.Should().BeOfType<OutcomeSuccess<Exception, int>>();
            (result as OutcomeSuccess<Exception, int>)._successValue.Should().Be(1);
        }

        [Test]
        public void Success_MapFailure()
        {

            var result = "1".ToOutcome<Exception, string>().MapFailure(FuncMapFailure);
            result.Should().BeOfType<OutcomeSuccess<string, string>>();
            (result as OutcomeSuccess<string, string>)._successValue.Should().Be("1");
        }

        [Test]
        public void Success_Map()
        {

            var result = "1".ToOutcome<Exception, string>().Map(FuncMapSuccess, FuncMapFailure);
            result.Should().BeOfType<OutcomeSuccess<string, int>>();
            (result as OutcomeSuccess<string, int>)._successValue.Should().Be(1);
        }

        [Test]
        public void Failure_MapSuccess()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().MapSuccess(FuncMapSuccess);
            result.Should().BeOfType<OutcomeFailure<Exception, int>>();
            (result as OutcomeFailure<Exception, int>)._failureValue.Message.Should().Be("parse failure");
        }

        [Test]
        public void Failure_BindFailure()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().MapFailure(FuncMapFailure);
            result.Should().BeOfType<OutcomeFailure<string, string>>();
            (result as OutcomeFailure<string, string>)._failureValue.Should().Be("parse failure");
        }

        [Test]
        public void Failure_BindFull()
        {

            var result = new Exception("parse failure").ToOutcomeFailure<Exception, string>().Map(FuncMapSuccess, FuncMapFailure);
            result.Should().BeOfType<OutcomeFailure<string, int>>();
            (result as OutcomeFailure<string, int>)._failureValue.Should().Be("parse failure");
        }

    }
}
