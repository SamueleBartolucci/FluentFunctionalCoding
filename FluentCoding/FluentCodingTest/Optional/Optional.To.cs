using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest.Optional.To
{
    internal class Optional
    {
        static string _testString = "test";
        static int FuncOnNone() => -1;

        [Test]
        public void Some_ToOutcome_Value()
        {
            var outcome = _testString.Some().ToOutcome(-1);
            outcome.Should().BeOfType<OutcomeSuccess<int, string>>();
            (outcome as OutcomeSuccess<int, string>)._successValue.Should().Be(_testString);
        }


        [Test]
        public void Some_ToOutcome_Func()
        {
            var outcome = _testString.Some().ToOutcome(FuncOnNone);
            outcome.Should().BeOfType<OutcomeSuccess<int, string>>();
            (outcome as OutcomeSuccess<int, string>)._successValue.Should().Be(_testString);
        }

        [Test]
        public void None_ToOutcome_Value()
        {
            var outcome = Optional<string>.None().ToOutcome(-1);
            outcome.Should().BeOfType<OutcomeFailure<int, string>>();
            (outcome as OutcomeFailure<int, string>)._failureValue.Should().Be(-1);
        }


        [Test]
        public void None_ToOutcome_Func()
        {
            var outcome = Optional<string>.None().ToOutcome(FuncOnNone);
            outcome.Should().BeOfType<OutcomeFailure<int, string>>();
            (outcome as OutcomeFailure<int, string>)._failureValue.Should().Be(-1);
        }
    }
}
