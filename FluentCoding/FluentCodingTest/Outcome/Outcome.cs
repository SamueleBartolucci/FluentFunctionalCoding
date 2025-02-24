using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FluentCodingTest.Outcome
{
    internal class Outcome
    {       

        [Test]
        public void Success()
        {
            var date = DateTime.Now;
            var outcome = Outcome<Exception, DateTime>.Success(date);
            outcome.Should().BeOfType<OutcomeSuccess<Exception, DateTime>>();
            (outcome as OutcomeSuccess<Exception, DateTime>)._successValue.Should().Be(date);
            outcome.IsFailure.Should().BeFalse();
            outcome.IsSuccess.Should().BeTrue();
        }

        [Test]
        public void Failure()
        {
            
            var outcome = Outcome<Exception, DateTime>.Failure(new Exception("fail"));
            outcome.Should().BeOfType<OutcomeFailure<Exception, DateTime>>();
            (outcome as OutcomeFailure<Exception, DateTime>)._failureValue.Message.Should().Be("fail");
            outcome.IsSuccess.Should().BeFalse();
            outcome.IsFailure.Should().BeTrue();
        }

    }
}
