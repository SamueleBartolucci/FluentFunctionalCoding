using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;
using NUnit.Framework;
using System;

namespace FluentFunctionalCodingTest.FluentTypes.TryCatch.PreludesExtensions
{
    internal class TryCatch_Func_Action_Preludes_Extensions_Tests
    {
        [Test]
        public void Func_Try_WithCustomError_ShouldSucceed_OnRetry()
        {
            int attempts = 0;
            int FlakyFunc(string s)
            {
                attempts++;
                if (attempts < 2) throw new Exception("fail");
                return 42;
            }
            string OnCatch(string s, Exception e) => $"err-{attempts}";
            var result = new Func<string, int>(FlakyFunc).Try("subject", OnCatch, numRetry: 2);
            result.Should().BeOfType<Success<string, int, string>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Func_Try_WithCustomError_ShouldFail_AfterAllRetries()
        {
            int attempts = 0;
            int AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            string OnCatch(string s, Exception e) => $"err-{attempts}";
            var result = new Func<string, int>(AlwaysFail).Try("subject", OnCatch, numRetry: 2);
            result.Should().BeOfType<Failure<string, int, string>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Action_Try_WithCustomError_ShouldSucceed_OnRetry()
        {
            int attempts = 0;
            void FlakyAction(string s)
            {
                attempts++;
                if (attempts < 2) throw new Exception("fail");
            }
            string OnCatch(string s, Exception e) => $"err-{attempts}";
            var result = new Action<string>(FlakyAction).Try("subject", OnCatch, numRetries: 2);
            result.Should().BeOfType<Success<string, Nothing, string>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Action_Try_WithCustomError_ShouldFail_AfterAllRetries()
        {
            int attempts = 0;
            void AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            string OnCatch(string s, Exception e) => $"err-{attempts}";
            var result = new Action<string>(AlwaysFail).Try("subject", OnCatch, numRetries: 2);
            result.Should().BeOfType<Failure<string, Nothing, string>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Func_Try_WithCustomCatchAction_ShouldSucceed_OnRetry()
        {
            int attempts = 0;
            int FlakyFunc(string s)
            {
                attempts++;
                if (attempts < 2) throw new Exception("fail");
                return 42;
            }
            void OnCatch(string s, Exception e) { /* custom logic */ }
            var result = new Func<string, int>(FlakyFunc).Try("subject", OnCatch, numRetry: 2);
            result.Should().BeOfType<Success<string, int, Nothing>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Func_Try_WithCustomCatchAction_ShouldFail_AfterAllRetries()
        {
            int attempts = 0;
            int AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            void OnCatch(string s, Exception e) { /* custom logic */ }
            var result = new Func<string, int>(AlwaysFail).Try("subject", OnCatch, numRetry: 2);
            result.Should().BeOfType<Failure<string, int, Nothing>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Action_Try_WithCustomCatchAction_ShouldSucceed_OnRetry()
        {
            int attempts = 0;
            void FlakyAction(string s)
            {
                attempts++;
                if (attempts < 2) throw new Exception("fail");
            }
            void OnCatch(string s, Exception e) { /* custom logic */ }
            var result = new Action<string>(FlakyAction).Try("subject", OnCatch, numRetries: 2);
            result.Should().BeOfType<Success<string, Nothing, Nothing>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Action_Try_WithCustomCatchAction_ShouldFail_AfterAllRetries()
        {
            int attempts = 0;
            void AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            void OnCatch(string s, Exception e) { /* custom logic */ }
            var result = new Action<string>(AlwaysFail).Try("subject", OnCatch, numRetries: 2);
            result.Should().BeOfType<Failure<string, Nothing, Nothing>>();
            attempts.Should().Be(2);
        }
    }
}
