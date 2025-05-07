using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.Outcome.Preludes
{
    internal class Outcome
    {
        [Test]
        public void ToOutcome_ShouldReturnRight_WhenGivenString()
        {
            var outcome = "test".ToOutcome<Exception, string>();
            outcome.Should().BeOfType<Right<Exception, string>>();
            (outcome as Right<Exception, string>)?. _successValue.Should().Be("test");
        }

        [Test]
        public void ToOutcomeFailure_ShouldReturnLeft_WhenGivenString()
        {
            var outcome = "test".ToOutcomeFailure<string, DateTime>();
            outcome.Should().BeOfType<Left<string, DateTime>>();
            (outcome as Left<string, DateTime>)?. _failureValue.Should().Be("test");
        }

        [Test]
        public void ToOutcome_WithFuncBool_ShouldReturnRight_WhenFuncReturnsFalse()
        {
            var outcome = "test".ToOutcome(() => false, new Exception("failure"));
            outcome.Should().BeOfType<Right<Exception, string>>();
            (outcome as Right<Exception, string>)?. _successValue.Should().Be("test");
        }

        [Test]
        public void ToOutcome_WithFuncBool_ShouldReturnLeft_WhenFuncReturnsTrue()
        {
            var outcome = "test".ToOutcome(() => true, new Exception("failure"));
            outcome.Should().BeOfType<Left<Exception, string>>();
            (outcome as Left<Exception, string>)?. _failureValue.Message.Should().Be("failure");
        }

        [Test]
        public void ToOutcome_WithFuncSubjectBool_ShouldReturnRight_WhenFuncReturnsFalse()
        {
            var outcome = "test".ToOutcome(sbj => sbj == "fail", new Exception("failure"));
            outcome.Should().BeOfType<Right<Exception, string>>();
            (outcome as Right<Exception, string>)?. _successValue.Should().Be("test");
        }

        [Test]
        public void ToOutcome_WithFuncSubjectBool_ShouldReturnLeft_WhenFuncReturnsTrue()
        {
            var outcome = "test".ToOutcome(sbj => sbj == "test", new Exception("failure"));
            outcome.Should().BeOfType<Left<Exception, string>>();
            (outcome as Left<Exception, string>)?. _failureValue.Message.Should().Be("failure");
        }
    }
}
