using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;
using System;
using NUnit.Framework;

namespace FluentFunctionalCodingTest.FluentTypes.TryCatch.PreludesExtensions
{
    internal class TryCatch_Object_Preludes_Extensions_Tests
    {
        [Test]
        public void Try_ShouldSucceed_OnRetry_Action_Implicit()
        {
            var subject = "Subject";
            int attempts = 0;
            void FlakyAction(string s)
            {
                attempts++;
                if (attempts < 2) throw new Exception("fail");
            }
            var result = subject.Try(FlakyAction, numRetry: 2);
            result.Should().BeOfType<Success<string, Nothing, Exception>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Try_ShouldFail_AfterAllRetries_Action_Implicit()
        {
            var subject = "Subject";
            int attempts = 0;
            void AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            var result = subject.Try(AlwaysFail, numRetry: 2);
            result.Should().BeOfType<Failure<string, Nothing, Exception>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Try_ShouldSucceed_OnRetry_Func_Implicit()
        {
            var subject = "Subject";
            int attempts = 0;
            int FlakyFunc(string s)
            {
                attempts++;
                if (attempts < 3) throw new Exception("fail");
                return 123;
            }
            var result = subject.Try(FlakyFunc, numRetry: 3);
            result.Should().BeOfType<Success<string, int, Exception>>();
            (result as Success<string, int, Exception>)!._result.Should().Be(123);
            attempts.Should().Be(3);
        }

        [Test]
        public void Try_ShouldFail_AfterAllRetries_Func_Implicit()
        {
            var subject = "Subject";
            int attempts = 0;
            int AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            var result = subject.Try(AlwaysFail, numRetry: 2);
            result.Should().BeOfType<Failure<string, int, Exception>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Try_ShouldReturnSuccess_AfterRetries_WhenActionThrowsThenSucceeds_Implicit()
        {
            var subject = "Subject";
            int callCount = 0;
            void SometimesFails(string s)
            {
                callCount++;
                if (callCount < 2) throw new Exception("fail");
            }
            var result = subject.Try(SometimesFails, numRetry: 2);
            result.Should().BeOfType<Success<string, Nothing, Exception>>();
            callCount.Should().Be(2);
        }

        [Test]
        public void Try_ShouldReturnFailure_AfterAllRetries_WhenActionAlwaysFails_Implicit()
        {
            var subject = "Subject";
            int callCount = 0;
            void AlwaysFails(string s)
            {
                callCount++;
                throw new Exception("fail");
            }
            var result = subject.Try(AlwaysFails, numRetry: 2);
            result.Should().BeOfType<Failure<string, Nothing, Exception>>();
            callCount.Should().Be(2);
        }

        [Test]
        public void Try_ShouldReturnSuccess_AfterRetries_WhenFuncThrowsThenSucceeds_Implicit()
        {
            var subject = "Subject";
            int callCount = 0;
            int SometimesFails(string s)
            {
                callCount++;
                if (callCount < 3) throw new Exception("fail");
                return 99;
            }
            var result = subject.Try(SometimesFails, numRetry: 3);
            result.Should().BeOfType<Success<string, int, Exception>>();
            (result as Success<string, int, Exception>)!._result.Should().Be(99);
            callCount.Should().Be(3);
        }

        [Test]
        public void Try_ShouldReturnFailure_AfterAllRetries_WhenFuncAlwaysFails_Implicit()
        {
            var subject = "Subject";
            int callCount = 0;
            int AlwaysFails(string s)
            {
                callCount++;
                throw new Exception("fail");
            }
            var result = subject.Try(AlwaysFails, numRetry: 2);
            result.Should().BeOfType<Failure<string, int, Exception>>();
            callCount.Should().Be(2);
        }
    }
}
