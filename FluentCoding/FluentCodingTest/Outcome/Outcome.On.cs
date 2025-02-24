using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace FluentCodingTest.Outcome.On
{
    internal class Outcome
    {
        List<string> onCollector = new List<string>();

        public void OoSuccessAction(string s) => onCollector.Add($"{s}_{onCollector.Count}");
        public DateTime OoSuccessFunc(string s) { onCollector.Add($"{s}_{onCollector.Count}"); return DateTime.Now; }

        public void OoFailureAction(Exception e) => onCollector.Add($"{e.Message}_{onCollector.Count}");
        public DateTime OoFailureFunc(Exception e) { onCollector.Add($"{e.Message}_{onCollector.Count}"); return DateTime.Now; }
                

        [SetUp]
        public void CleanStatus()
        {
            onCollector = new List<string>();
        }


        [Test]
        public void Success_OnSuccess_Action()
        {
            var result = "succ".ToOutcome<Exception, string>().OnSuccess(OoSuccessAction);
            result.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (result as OutcomeSuccess<Exception, string>)._successValue.Should().Be("succ");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("succ_0").Should().BeTrue();
        }

        [Test]
        public void Success_OnFailure_Action()
        {
            var result = "succ".ToOutcome<Exception, string>().OnFailure(OoFailureAction);
            result.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (result as OutcomeSuccess<Exception, string>)._successValue.Should().Be("succ");
            onCollector.Should().HaveCount(0);
        }

        [Test]
        public void Success_On_Action()
        {
            var result = "succ".ToOutcome<Exception, string>().On(OoSuccessAction, OoFailureAction);
            result.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (result as OutcomeSuccess<Exception, string>)._successValue.Should().Be("succ");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("succ_0").Should().BeTrue();
        }



        [Test]
        public void Success_OnSuccess_Func()
        {
            var result = "succ".ToOutcome<Exception, string>().OnSuccess(OoSuccessFunc);
            result.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (result as OutcomeSuccess<Exception, string>)._successValue.Should().Be("succ");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("succ_0").Should().BeTrue();
        }

        [Test]
        public void Success_OnFailure_Func()
        {
            var result = "succ".ToOutcome<Exception, string>().OnFailure(OoFailureFunc);
            result.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (result as OutcomeSuccess<Exception, string>)._successValue.Should().Be("succ");
            onCollector.Should().HaveCount(0);        
        }


        [Test]
        public void Success_On_Func()
        {
            var result = "succ".ToOutcome<Exception, string>().On(OoSuccessFunc, OoFailureFunc);
            result.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (result as OutcomeSuccess<Exception, string>)._successValue.Should().Be("succ");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("succ_0").Should().BeTrue();
        }

        
        [Test]
        public void Failure_OnSuccess_Action()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().OnSuccess(OoSuccessAction);
            result.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (result as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("fail");
            onCollector.Should().HaveCount(0);            
        }

        [Test]
        public void Failure_OnFailure_Action()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().OnFailure(OoFailureAction);
            result.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (result as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("fail");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("fail_0").Should().BeTrue();
        }

        [Test]
        public void Failure_On_Action()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().On(OoSuccessAction, OoFailureAction);
            result.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (result as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("fail");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("fail_0").Should().BeTrue();
        }

        [Test]
        public void Failure_OnSuccess_Func()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().OnSuccess(OoSuccessFunc);
            result.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (result as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("fail");
            onCollector.Should().HaveCount(0);            
        }

        [Test]
        public void Failure_OnFailure_Func()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().OnFailure(OoFailureFunc);
            result.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (result as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("fail");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("fail_0").Should().BeTrue();
        }


        [Test]
        public void Failure_On_Func()
        {
            var result = (new Exception("fail")).ToOutcomeFailure<Exception, string>().On(OoSuccessFunc, OoFailureFunc);
            result.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (result as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("fail");
            onCollector.Should().HaveCount(1);
            onCollector.Contains("fail_0").Should().BeTrue();
        }

    }
}
