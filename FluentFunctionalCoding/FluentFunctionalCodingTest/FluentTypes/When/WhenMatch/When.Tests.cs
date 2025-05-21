using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentTypes.When.WhenMatch
{
    public class WhenTests
    {
        [Test]
        public void IsTrueAndIsFalse_ShouldReflectConditionCorrectly()
        {
            var when = new When<int>(42, true);
            when.IsTrue.Should().BeTrue();
            when.IsFalse.Should().BeFalse();
            var whenFalse = new When<int>(42, false);
            whenFalse.IsTrue.Should().BeFalse();
            whenFalse.IsFalse.Should().BeTrue();
        }

        [Test]
        public void Match_ShouldReturnUpperOrLowerBasedOnCondition()
        {
            var when = new When<string>("foo", true);
            var result = when.Match(s => s.ToUpper(), s => s.ToLower());
            result.Should().Be("FOO");
            var whenFalse = new When<string>("foo", false);
            var result2 = whenFalse.Match(s => s.ToUpper(), s => s.ToLower());
            result2.Should().Be("foo");
        }

        [Test]
        public void MatchTrue_ShouldMapOnlyWhenTrue()
        {
            var when = new When<int>(10, true);
            var result = when.MatchTrue(x => x + 1);
            result.Should().Be(11);
            var whenFalse = new When<int>(10, false);
            var result2 = whenFalse.MatchTrue(x => x + 1);
            result2.Should().Be(10);
        }

        [Test]
        public void MatchFalse_ShouldMapOnlyWhenFalse()
        {
            var when = new When<int>(10, false);
            var result = when.MatchFalse(x => x + 2);
            result.Should().Be(12);
            var whenTrue = new When<int>(10, true);
            var result2 = whenTrue.MatchFalse(x => x + 2);
            result2.Should().Be(10);
        }

        [Test]
        public void MatchToOutcome_ShouldReturnRightOrLeft_BasedOnCondition()
        {
            var whenTrue = new When<int>(5, true);
            var outcomeTrue = whenTrue.MatchToOutcome(
                mapOnTrue: v => v * 2,
                mapOnFalse: v => $"fail-{v}"
            );
            if (outcomeTrue is Right<string, int> right)
                right._successValue.Should().Be(10);
            else
                Assert.Fail("Expected Right outcome");

            var whenFalse = new When<int>(7, false);
            var outcomeFalse = whenFalse.MatchToOutcome(
                mapOnTrue: v => v * 2,
                mapOnFalse: v => $"fail-{v}"
            );
            if (outcomeFalse is Left<string, int> left)
                left._failureValue.Should().Be("fail-7");
            else
                Assert.Fail("Expected Left outcome");
        }

    }
}
