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
        public void Bind_WhenSomeValuePresent_MapsToNewOptionalWithMappedValue()
        {
            var opt = Optional<string>.Some("abc");
            var result = opt.Bind(s => Optional<int>.Some(s.Length));
            result.IsSome.Should().BeTrue();
            result.Match(i => i, -1).Should().Be(3);
        }

        [Test]
        public void Bind_WhenNoneValuePresent_ReturnsNoneOptional()
        {
            var opt = Optional<string>.None();
            var result = opt.Bind(s => Optional<int>.Some(s.Length));
            result.IsNone.Should().BeTrue();
        }

        [Test]
        public void BindNone_WhenNoneValuePresent_InvokesFallbackAndReturnsOptional()
        {
            var opt = Optional<string>.None();
            var result = opt.BindNone(() => Optional<string>.Some("fallback"));
            result.IsSome.Should().BeTrue();
            result.Match(s => s, "not this").Should().Be("fallback");
        }

        [Test]
        public void BindNone_WhenSomeValuePresent_DoesNotInvokeFallbackAndReturnsOriginal()
        {
            var opt = Optional<string>.Some("abc");
            var result = opt.BindNone(() => Optional<string>.Some("fallback"));
            result.Match(s => s, "not this").Should().Be("abc");
        }

        [Test]
        public async Task BindAsync_WhenSomeValuePresent_MapsToNewOptionalAsync()
        {
            var opt = Optional<string>.Some("abc");
            var result = await opt.BindAsync(s => Task.FromResult(Optional<int>.Some(s.Length)));
            result.IsSome.Should().BeTrue();
            result.Match(i => i, -1).Should().Be(3);
        }

        [Test]
        public async Task BindAsync_WhenNoneValuePresent_ReturnsNoneOptionalAsync()
        {
            var opt = Optional<string>.None();
            var result = await opt.BindAsync(s => Task.FromResult(Optional<int>.Some(s.Length)));
            result.IsNone.Should().BeTrue();
        }

        [Test]
        public async Task BindNoneAsync_WhenNoneValuePresent_InvokesFallbackAndReturnsOptionalAsync()
        {
            var opt = Optional<string>.None();
            var result = await opt.BindNoneAsync(() => Task.FromResult(Optional<string>.Some("fallback")));
            result.IsSome.Should().BeTrue();
            result.Match(s => s, "not this").Should().Be("fallback");
        }

        [Test]
        public async Task BindNoneAsync_WhenSomeValuePresent_DoesNotInvokeFallbackAndReturnsOriginalAsync()
        {
            var opt = Optional<string>.Some("abc");
            var result = await opt.BindNoneAsync(() => Task.FromResult(Optional<string>.Some("fallback")));
            result.Match(s => s, "not this").Should().Be("abc");
        }

        [Test]
        public void OnSome_WithAction_WhenSomeValuePresent_InvokesAction()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.OnSome(s => captured = s);
            captured.Should().Be("abc");
        }

        [Test]
        public void OnSome_WithAction_WhenNoneValuePresent_DoesNotInvokeAction()
        {
            var opt = Optional<string>.None();
            string captured = null;
            opt.OnSome(s => captured = s);
            captured.Should().BeNull();
        }

        [Test]
        public void OnSome_WithFunc_WhenSomeValuePresent_InvokesFunc()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.OnSome(s => { captured = s; return 1; });
            captured.Should().Be("abc");
        }

        [Test]
        public void OnNone_WithAction_WhenNoneValuePresent_InvokesAction()
        {
            var opt = Optional<string>.None();
            bool called = false;
            opt.OnNone(() => called = true);
            called.Should().BeTrue();
        }

        [Test]
        public void OnNone_WithAction_WhenSomeValuePresent_DoesNotInvokeAction()
        {
            var opt = Optional<string>.Some("abc");
            bool called = false;
            opt.OnNone(() => called = true);
            called.Should().BeFalse();
        }

        [Test]
        public void OnNone_WithFunc_WhenNoneValuePresent_InvokesFunc()
        {
            var opt = Optional<string>.None();
            bool called = false;
            opt.OnNone(() => { called = true; return 1; });
            called.Should().BeTrue();
        }

        [Test]
        public void Do_WithAction_WhenSomeValuePresent_InvokesAction()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.Do(s => captured = s);
            captured.Should().Be("abc");
        }

        [Test]
        public void Do_WithFunc_WhenSomeValuePresent_InvokesFunc()
        {
            var opt = Optional<string>.Some("abc");
            string captured = null;
            opt.Do<string>(s => { captured = s; return "x"; });
            captured.Should().Be("abc");
        }

        [Test]
        public void Or_WithOverloads_ReturnsExpectedOptionalBasedOnPresence()
        {
            var some = Optional<string>.Some("abc");
            var none = Optional<string>.None();
            some.Or(Optional<string>.Some("x")).Match(s => s, "not this").Should().Be("abc");
            none.Or(Optional<string>.Some("x")).Match(s => s, "not this").Should().Be("x");
            some.Or(() => "y").Match(s => s, "not this").Should().Be("abc");
            none.Or(() => "y").Match(s => s, "not this").Should().Be("y");
        }

        [Test]
        public void Map_WithOverloads_MapsValuesOrReturnsFallback()
        {
            var some = Optional<string>.Some("abc");
            var none = Optional<string>.None();
            some.Map(s => s.Length).Match(i => i, -1).Should().Be(3);
            none.Map(s => s.Length).IsNone.Should().BeTrue();
            none.MapNone(() => "fallback").Match(s => s, "not this").Should().Be("fallback");
        }

        [Test]
        public void Match_WithOverloads_ReturnsExpectedResultsForSomeAndNone()
        {
            var some = Optional<string>.Some("abc");
            var none = Optional<string>.None();
            some.Match(s => s.Length, () => -1).Should().Be(3);
            none.Match(s => s.Length, () => -1).Should().Be(-1);
            some.Match(s => s.Length, -1).Should().Be(3);
            none.Match(s => s.Length, -1).Should().Be(-1);
        }

        [Test]
        public void ToOutcome_WithOverloads_ConvertsOptionalToOutcomeCorrectly()
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
