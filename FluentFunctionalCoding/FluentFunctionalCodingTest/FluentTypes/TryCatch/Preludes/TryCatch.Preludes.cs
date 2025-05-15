using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentTypes.TryCatch.Factories
{
    internal class Try
    {
        public void DoNothingAction<T>(T subject) { Task.Delay(10).Wait(); }
        public void DoThrowAction<T>(T subject) { throw new Exception("TestActionException"); }
        public void MangeExceptionAction<T>(T subject, Exception e) { DoNothingAction(subject); }


        public int DoNothingFunc<T>(T subject) { return -99; }
        public int DoThrowFunc<T>(T subject) { throw new Exception("TestFuncException"); }
        public string MangeExceptionFunc<T>(T subject, Exception e) { return "Managed Exception"; }


        [Test]
        public void Try_ShouldReturnSuccess_WhenActionSucceeds()
        {            
            var subject = "Subject";
            var result = Prelude.Try(subject, DoNothingAction);
            result.Should().BeOfType<Success<string, Nothing, Exception>>();            
            (result as Success<string, Nothing, Exception>)!.Do(
                outcome => outcome._result.Should().BeOfType<Nothing>(),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnFailure_WhenActionThrowsException()
        {
            
            var subject = "Subject";
            var result = Prelude.Try(subject, DoThrowAction);
            result.Should().BeOfType<Failure<string, Nothing, Exception>>();
            (result as Failure<string, Nothing, Exception>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestActionException"),
                outcome => outcome._errorResult.Should().BeOfType<Exception>(),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnSuccess_WhenFuncSucceeds()
        {
            var subject = "Subject";
            var result = Prelude.Try(subject, DoNothingFunc);
            result.Should().BeOfType<Success<string, int, Exception>>();
            (result as Success<string, int, Exception>)!.Do(
                outcome => outcome._result.Should().Be(-99),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnFailure_WhenFuncThrowsException()
        {

            var subject = "Subject";
            var result = Prelude.Try(subject, DoThrowFunc);
            result.Should().BeOfType<Failure<string, int, Exception>>();
            (result as Failure<string, int, Exception>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestFuncException"),
                outcome => outcome._errorResult.Should().BeOfType<Exception>(),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }


        [Test]
        public void Try_ShouldReturnSuccess_WhenActionSucceeds_WithManagedExceptionAsAction()
        {
            var subject = "Subject";
            var result = Prelude.Try(subject, DoNothingAction, MangeExceptionAction);
            result.Should().BeOfType<Success<string, Nothing, Nothing>>();
            (result as Success<string, Nothing, Nothing>)!.Do(
                outcome => outcome._result.Should().BeOfType<Nothing>(),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnCustomFailure_WhenActionThrowsException_WithManagedExceptionAsAction()
        {

            var subject = "Subject";
            var result = Prelude.Try(subject, DoThrowAction, MangeExceptionAction);
            result.Should().BeOfType<Failure<string, Nothing, Nothing>>();
            (result as Failure<string, Nothing, Nothing>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestActionException"),
                 outcome => outcome._errorResult.Should().Be(Nothing.SoftNull),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnSuccess_WhenFuncSucceeds_WithManagedExceptionAsFunction()
        {
            var subject = "Subject";
            var result = Prelude.Try(subject, DoNothingFunc, MangeExceptionFunc);
            result.Should().BeOfType<Success<string, int, string>>();
            (result as Success<string, int, string>)!.Do(
                outcome => outcome._result.Should().Be(-99),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnCustomFailure_WhenFuncThrowsException_WithManagedExceptionAsFunction()
        {

            var subject = "Subject";
            var result = Prelude.Try(subject, DoThrowFunc, MangeExceptionFunc);
            result.Should().BeOfType<Failure<string, int, string>>();
            (result as Failure<string, int, string>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestFuncException"),
                outcome => outcome._errorResult.Should().Be("Managed Exception"),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }


        [Test]
        public void Try_ShouldReturnSuccess_WhenFuncSucceeds_WithManagedExceptionAsAction()
        {
            var subject = "Subject";
            var result = Prelude.Try(subject, DoNothingFunc, MangeExceptionAction);
            result.Should().BeOfType<Success<string, int, Nothing>>();
            (result as Success<string, int, Nothing>)!.Do(
                outcome => outcome._result.Should().Be(-99),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnCustomFailure_WhenFuncThrowsException_WithManagedExceptionAsAction()
        {

            var subject = "Subject";
            var result = Prelude.Try(subject, DoThrowFunc, MangeExceptionAction);
            result.Should().BeOfType<Failure<string, int, Nothing>>();
            (result as Failure<string, int, Nothing>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestFuncException"),
                outcome => outcome._errorResult.Should().Be(Nothing.SoftNull),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }


        [Test]
        public void Try_ShouldReturnSuccess_WhenActionSucceeds_WithManagedExceptionAsFunction()
        {
            var subject = "Subject";
            var result = Prelude.Try(subject, DoNothingAction, MangeExceptionFunc);
            result.Should().BeOfType<Success<string, Nothing, string>>();
            (result as Success<string, Nothing, string>)!.Do(
                outcome => outcome._result.Should().BeOfType<Nothing>(),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldReturnCustomFailure_WhenActionThrowsException_WithManagedExceptionAsFunction()
        {

            var subject = "Subject";
            var result = Prelude.Try(subject, DoThrowAction, MangeExceptionFunc);
            result.Should().BeOfType<Failure<string, Nothing, string>>();
            (result as Failure<string, Nothing, string>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestActionException"),
                 outcome => outcome._errorResult.Should().Be("Managed Exception"),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Try_ShouldSucceed_OnRetry_Action_Explicit()
        {
            var subject = "Subject";
            int attempts = 0;
            void FlakyAction(string s)
            {
                attempts++;
                if (attempts < 3) throw new Exception("fail");
            }
            var result = Prelude.Try(subject, FlakyAction, numRetries: 3);
            result.Should().BeOfType<Success<string, Nothing, Exception>>();
            attempts.Should().Be(3);
        }

        [Test]
        public void Try_ShouldFail_AfterAllRetries_Action_Explicit()
        {
            var subject = "Subject";
            int attempts = 0;
            void AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            var result = Prelude.Try(subject, AlwaysFail, numRetries: 2);
            result.Should().BeOfType<Failure<string, Nothing, Exception>>();
            attempts.Should().Be(2);
        }

        [Test]
        public void Try_ShouldSucceed_OnRetry_Func_Explicit()
        {
            var subject = "Subject";
            int attempts = 0;
            int FlakyFunc(string s)
            {
                attempts++;
                if (attempts < 2) throw new Exception("fail");
                return 42;
            }
            var result = Prelude.Try(subject, FlakyFunc, numRetries: 2);
            result.Should().BeOfType<Success<string, int, Exception>>();
            (result as Success<string, int, Exception>)!._result.Should().Be(42);
            attempts.Should().Be(2);
        }

        [Test]
        public void Try_ShouldFail_AfterAllRetries_Func_Explicit()
        {
            var subject = "Subject";
            int attempts = 0;
            int AlwaysFail(string s)
            {
                attempts++;
                throw new Exception("fail");
            }
            var result = Prelude.Try(subject, AlwaysFail, numRetries: 3);
            result.Should().BeOfType<Failure<string, int, Exception>>();
            attempts.Should().Be(3);
        }

        [Test]
        public void Try_ShouldReturnSuccess_AfterRetries_WhenActionThrowsThenSucceeds_Explicit()
        {
            var subject = "Subject";
            int callCount = 0;
            void SometimesFails(string s)
            {
                callCount++;
                if (callCount < 3) throw new Exception("fail");
            }
            var result = Prelude.Try(subject, SometimesFails, numRetries: 3);
            result.Should().BeOfType<Success<string, Nothing, Exception>>();
            callCount.Should().Be(3);
        }

        [Test]
        public void Try_ShouldReturnFailure_AfterAllRetries_WhenActionAlwaysFails_Explicit()
        {
            var subject = "Subject";
            int callCount = 0;
            void AlwaysFails(string s)
            {
                callCount++;
                throw new Exception("fail");
            }
            var result = Prelude.Try(subject, AlwaysFails, numRetries: 2);
            result.Should().BeOfType<Failure<string, Nothing, Exception>>();
            callCount.Should().Be(2);
        }

        [Test]
        public void Try_ShouldReturnSuccess_AfterRetries_WhenFuncThrowsThenSucceeds_Explicit()
        {
            var subject = "Subject";
            int callCount = 0;
            int SometimesFails(string s)
            {
                callCount++;
                if (callCount < 2) throw new Exception("fail");
                return 42;
            }
            var result = Prelude.Try(subject, SometimesFails, numRetries: 2);
            result.Should().BeOfType<Success<string, int, Exception>>();
            (result as Success<string, int, Exception>)!._result.Should().Be(42);
            callCount.Should().Be(2);
        }

        [Test]
        public void Try_ShouldReturnFailure_AfterAllRetries_WhenFuncAlwaysFails_Explicit()
        {
            var subject = "Subject";
            int callCount = 0;
            int AlwaysFails(string s)
            {
                callCount++;
                throw new Exception("fail");
            }
            var result = Prelude.Try(subject, AlwaysFails, numRetries: 3);
            result.Should().BeOfType<Failure<string, int, Exception>>();
            callCount.Should().Be(3);
        }
    }
}
