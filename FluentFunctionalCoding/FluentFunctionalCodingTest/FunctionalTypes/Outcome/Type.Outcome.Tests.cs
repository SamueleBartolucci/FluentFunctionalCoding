using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;
using System;

namespace FluentFunctionalCodingTest.FunctionalTypes.Outcome
{
    public class Type_Outcome_Tests
    {
        [Test]
        public void On_Overloads_WorkAsExpected()
        {
            var right = Outcome<string, int>.Right(42);
            var left = Outcome<string, int>.Left("fail");
            right.On((s) => s + 1, (f) => f.Length).Should().BeOfType<Right<string, int>>();
            left.On((s) => s + 1, (f) => f.Length).Should().BeOfType<Left<string, int>>();
        }

        [Test]
        public void OnSuccess_Func_InvokedIfSuccess()
        {
            var right = Outcome<string, int>.Right(42);
            int captured = 0;
            right.OnSuccess(s => { captured = s; return s + 1; });
            captured.Should().Be(42);
        }

        [Test]
        public void OnFailure_Func_InvokedIfFailure()
        {
            var left = Outcome<string, int>.Left("fail");
            string captured = null;
            left.OnFailure(f => { captured = f; return f.Length; });
            captured.Should().Be("fail");
        }

        [Test]
        public void On_Action_InvokedIfSuccessOrFailure()
        {
            var right = Outcome<string, int>.Right(42);
            var left = Outcome<string, int>.Left("fail");
            int success = 0; string failure = null;
            right.On(s => success = s, f => failure = f);
            success.Should().Be(42);
            left.On(s => success = s, f => failure = f);
            failure.Should().Be("fail");
        }

        [Test]
        public void OnSuccess_Action_InvokedIfSuccess()
        {
            var right = Outcome<string, int>.Right(42);
            int captured = 0;
            right.OnSuccess(s => captured = s);
            captured.Should().Be(42);
        }

        [Test]
        public void OnFailure_Action_InvokedIfFailure()
        {
            var left = Outcome<string, int>.Left("fail");
            string captured = null;
            left.OnFailure(f => captured = f);
            captured.Should().Be("fail");
        }

        [Test]
        public void Match_Overloads_WorkAsExpected()
        {
            var right = Outcome<string, int>.Right(42);
            var left = Outcome<string, int>.Left("fail");
            right.Match(s => s + 1, f => f.Length).Should().Be(43);
            left.Match(s => s + 1, f => f.Length).Should().Be(4);
            right.Match(s => s + 1, -1).Should().Be(43);
            left.Match(s => s + 1, -1).Should().Be(-1);
        }

        [Test]
        public void Bind_Overloads_WorkAsExpected()
        {
            var right = Outcome<string, int>.Right(42);
            var left = Outcome<string, int>.Left("fail");
            right.Bind(s => Outcome<string, string>.Right(s.ToString())).Match(s => s, f => f).Should().Be("42");
            left.Bind(s => Outcome<string, string>.Right(s.ToString())).IsFailure.Should().BeTrue();
            left.BindFailure(f => Outcome<int, int>.Left(f.Length)).Match(s => s, f => f).Should().Be(4);
            right.BindFailure(f => Outcome<int, int>.Left(f.Length)).IsSuccess.Should().BeTrue();
            right.BindFull(f => Outcome<int, string>.Right(f.ToString()), s => Outcome<int, string>.Left(s.Length)).Match(s => s, f => f.ToString()).Should().Be("42");
            left.BindFull(f => Outcome<int, string>.Right(f.ToString()), s => Outcome<int, string>.Left(s.Length)).Match(s => s, f => f.ToString()).Should().Be("4");
        }

        [Test]
        public void Do_Overloads_WorkAsExpected()
        {
            var right = Outcome<string, int>.Right(42);
            int captured = 0;
            right.Do(s => captured = s);
            captured.Should().Be(42);
            right.Do<int>(s => { captured = s; return s + 1; });
            captured.Should().Be(42);
        }

        [Test]
        public void Map_Overloads_WorkAsExpected()
        {
            var right = Outcome<string, int>.Right(42);
            var left = Outcome<string, int>.Left("fail");
            right.Map<int, string>(s => s.ToString(), f => f.Length).Match(s => s, f => f.ToString()).Should().Be("42");
            left.Map<int, string>(s => s.ToString(), f => f.Length).Match(s => s, f => f.ToString()).Should().Be("4");
            right.MapSuccess(s => s.ToString()).Match(s => s, f => f.ToString()).Should().Be("42");
            left.MapFailure(f => f.Length).Match(s => s, f => f).Should().Be(4);
        }

        [Test]
        public void ToOptional_Overloads_WorkAsExpected()
        {
            var right = Outcome<string, int>.Right(42);
            var left = Outcome<string, int>.Left("fail");
            right.ToOptional().IsSome.Should().BeTrue();
            left.ToOptional().IsNone.Should().BeTrue();
            right.ToOptionalFailure().IsNone.Should().BeTrue();
            left.ToOptionalFailure().IsSome.Should().BeTrue();
        }
    }
}
