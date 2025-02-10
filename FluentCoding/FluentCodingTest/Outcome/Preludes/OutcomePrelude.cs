using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest.Outcome.Preludes
{
    internal class Outcome
    {
        [Test]
        public void ToOutcome_Success()
        { 
            var outcome = "test".ToOutcome<Exception, string>();            
            outcome.Should().BeOfType<OutcomeSuccess<Exception, string>>();                
            (outcome as OutcomeSuccess<Exception, string>)._successValue.Should().Be("test");
        }

        [Test]
        public void ToOutcome_Failure()
        {
            var outcome = "test".ToOutcome<string, DateTime>();
            outcome.Should().BeOfType<OutcomeFailure<string, DateTime>>();
            (outcome as OutcomeFailure<string, DateTime>)._failureValue.Should().Be("test");
        }


        [Test]
        public void ToOutcome_FuncBool_Success()
        {
            var outcome = "test".ToOutcome(()=> false, new Exception("failure"));
            outcome.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (outcome as OutcomeSuccess<Exception, string>)._successValue.Should().Be("test");
        }

        [Test]
        public void ToOutcome_FuncBool_Failure()
        {
            var outcome = "test".ToOutcome(() => true, new Exception("failure"));
            outcome.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (outcome as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("failure");
        }

        [Test]
        public void ToOutcome_FuncSubjectBool_Success()
        {
            var outcome = "test".ToOutcome(sbj =>  sbj == "fail", new Exception("failure"));
            outcome.Should().BeOfType<OutcomeSuccess<Exception, string>>();
            (outcome as OutcomeSuccess<Exception, string>)._successValue.Should().Be("test");
        }

        [Test]
        public void ToOutcome_FuncSubjectBool_Failure()
        {
            var outcome = "test".ToOutcome(sbj => sbj == "test", new Exception("failure"));
            outcome.Should().BeOfType<OutcomeFailure<Exception, string>>();
            (outcome as OutcomeFailure<Exception, string>)._failureValue.Message.Should().Be("failure");
        }
    }
}
