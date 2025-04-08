using FluentAssertions;
using FluentCoding;

namespace FluentCodingTest.Optional.To
{
    internal class Optional
    {
        static string _testString = "test";
        static int FuncOnNone() => -1;

        [Test]
        public void Some_ToOutcome_Value()
        {
            var outcome = _testString.ToOptional().ToOutcome(-1);
            outcome.Should().BeOfType<Right<int, string>>();
            (outcome as Right<int, string>)._successValue.Should().Be(_testString);
        }


        [Test]
        public void Some_ToOutcome_Func()
        {
            var outcome = _testString.ToOptional().ToOutcome(FuncOnNone);
            outcome.Should().BeOfType<Right<int, string>>();
            (outcome as Right<int, string>)._successValue.Should().Be(_testString);
        }

        [Test]
        public void None_ToOutcome_Value()
        {
            var outcome = Optional<string>.None().ToOutcome(-1);
            outcome.Should().BeOfType<Left<int, string>>();
            (outcome as Left<int, string>)._failureValue.Should().Be(-1);
        }


        [Test]
        public void None_ToOutcome_Func()
        {
            var outcome = Optional<string>.None().ToOutcome(FuncOnNone);
            outcome.Should().BeOfType<Left<int, string>>();
            (outcome as Left<int, string>)._failureValue.Should().Be(-1);
        }
    }
}
