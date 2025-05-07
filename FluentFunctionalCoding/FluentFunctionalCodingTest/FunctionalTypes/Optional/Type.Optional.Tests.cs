using FluentAssertions;
using FluentFunctionalCoding;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FunctionalTypes.Optional
{
    public class Type_Optional_Tests
    {
        [Test]
        public void Bind_OnSome_ReturnsExpected()
        {
            var opt = Optional<string>.Some("abc");
            var result = opt.Bind(s => Optional<int>.Some(s.Length));
            result.IsSome.Should().BeTrue();
            result.Match(i => i, -1).Should().Be(3);
        }

        [Test]
        public void Bind_OnNone_ReturnsNone()
        {
            var opt = Optional<string>.None();
            var result = opt.Bind(s => Optional<int>.Some(s.Length));
            result.IsNone.Should().BeTrue();
        }

        [Test]
        public void BindNone_OnNone_InvokesFunc()
        {
            var opt = Optional<string>.None();
            var result = opt.BindNone(() => Optional<string>.Some("fallback"));
            result.IsSome.Should().BeTrue();
            result.Match(s => s, "not this").Should().Be("fallback");
        }

        [Test]
        public void BindNone_OnSome_DoesNotInvokeFunc()
        {
            var opt = Optional<string>.Some("abc");
            var result = opt.BindNone(() => Optional<string>.Some("fallback"));
            result.Match(s => s, "not this").Should().Be("abc");
        }

        [Test]
        public async Task BindAsync_OnSome_ReturnsExpected()
        {
            var opt = Optional<string>.Some("abc");
            var result = await opt.BindAsync(s => Task.FromResult(Optional<int>.Some(s.Length)));
            result.IsSome.Should().BeTrue();
            result.Match(i => i, -1).Should().Be(3);
        }

        [Test]
        public async Task BindAsync_OnNone_ReturnsNone()
        {
            var opt = Optional<string>.None();
            var result = await opt.BindAsync(s => Task.FromResult(Optional<int>.Some(s.Length)));
            result.IsNone.Should().BeTrue();
        }

        [Test]
        public async Task BindNoneAsync_OnNone_InvokesFunc()
        {
            var opt = Optional<string>.None();
            var result = await opt.BindNoneAsync(() => Task.FromResult(Optional<string>.Some("fallback")));
            result.IsSome.Should().BeTrue();
            result.Match(s => s, "not this").Should().Be("fallback");
        }

        [Test]
        public async Task BindNoneAsync_OnSome_DoesNotInvokeFunc()
        {
            var opt = Optional<string>.Some("abc");
            var result = await opt.BindNoneAsync(() => Task.FromResult(Optional<string>.Some("fallback")));
            result.Match(s => s, "not this").Should().Be("abc");
        }

        [Test]
        public void OnSome_Action_InvokedIfSome()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.OnSome(s => captured = s);
            captured.Should().Be("abc");
        }

        [Test]
        public void OnSome_Action_NotInvokedIfNone()
        {
            var opt = Optional<string>.None();
            string captured = null;
            opt.OnSome(s => captured = s);
            captured.Should().BeNull();
        }

        [Test]
        public void OnSome_Func_InvokedIfSome()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.OnSome(s => { captured = s; return 1; });
            captured.Should().Be("abc");
        }

        [Test]
        public void OnNone_Action_InvokedIfNone()
        {
            var opt = Optional<string>.None();
            bool called = false;
            opt.OnNone(() => called = true);
            called.Should().BeTrue();
        }

        [Test]
        public void OnNone_Action_NotInvokedIfSome()
        {
            var opt = Optional<string>.Some("abc");
            bool called = false;
            opt.OnNone(() => called = true);
            called.Should().BeFalse();
        }

        [Test]
        public void OnNone_Func_InvokedIfNone()
        {
            var opt = Optional<string>.None();
            bool called = false;
            opt.OnNone(() => { called = true; return 1; });
            called.Should().BeTrue();
        }

        [Test]
        public void Do_Action_InvokedIfSome()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.Do(s => captured = s);
            captured.Should().Be("abc");
        }

        [Test]
        public void Do_Func_InvokedIfSome()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.Do<string>(s => { captured = s; return "x"; });
            captured.Should().Be("abc");
        }

        [Test]
        public void Or_Overloads_WorkAsExpected()
        {
            var some = Optional<string>.Some("abc");
            var none = Optional<string>.None();
            some.Or(Optional<string>.Some("x")).Match(s => s, "not this").Should().Be("abc");
            none.Or(Optional<string>.Some("x")).Match(s => s, "not this").Should().Be("x");
            some.Or(() => "y").Match(s => s, "not this").Should().Be("abc");
            none.Or(() => "y").Match(s => s, "not this").Should().Be("y");
        }

        [Test]
        public void Map_Overloads_WorkAsExpected()
        {
            var some = Optional<string>.Some("abc");
            var none = Optional<string>.None();
            some.Map(s => s.Length).Match(i => i, -1).Should().Be(3);
            none.Map(s => s.Length).IsNone.Should().BeTrue();
            none.MapNone(() => "fallback").Match(s => s, "not this").Should().Be("fallback");
        }

        [Test]
        public void Match_Overloads_WorkAsExpected()
        {
            var some = Optional<string>.Some("abc");
            var none = Optional<string>.None();
            some.Match(s => s.Length, () => -1).Should().Be(3);
            none.Match(s => s.Length, () => -1).Should().Be(-1);
            some.Match(s => s.Length, -1).Should().Be(3);
            none.Match(s => s.Length, -1).Should().Be(-1);
        }

        [Test]
        public void ToOutcome_Overloads_WorkAsExpected()
        {
            var some = Optional<string>.Some("abc");
            var none = Optional<string>.None();
            some.ToOutcome(() => "fail").IsSuccess.Should().BeTrue();
            none.ToOutcome(() => "fail").IsFailure.Should().BeTrue();
            some.ToOutcome("fail").IsSuccess.Should().BeTrue();
            none.ToOutcome("fail").IsFailure.Should().BeTrue();
        }
    }
}
