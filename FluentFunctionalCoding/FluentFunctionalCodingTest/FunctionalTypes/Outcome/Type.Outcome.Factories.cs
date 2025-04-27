using FluentAssertions;
using FluentFunctionalCoding;


namespace FluentCodingTest.Outcome
{
    internal class Outcome
    {

        [Test]
        public void Success()
        {
            var date = DateTime.Now;
            var outcome = Outcome<Exception, DateTime>.Right(date);
            outcome.Should().BeOfType<Right<Exception, DateTime>>();
            (outcome as Right<Exception, DateTime>)._successValue.Should().Be(date);
            outcome.IsFailure.Should().BeFalse();
            outcome.IsSuccess.Should().BeTrue();
        }

        [Test]
        public void Failure()
        {

            var outcome = Outcome<Exception, DateTime>.Left(new Exception("fail"));
            outcome.Should().BeOfType<Left<Exception, DateTime>>();
            (outcome as Left<Exception, DateTime>)._failureValue.Message.Should().Be("fail");
            outcome.IsSuccess.Should().BeFalse();
            outcome.IsFailure.Should().BeTrue();
        }

    }
}
