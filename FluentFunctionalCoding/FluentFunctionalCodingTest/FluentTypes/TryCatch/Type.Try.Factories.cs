using FluentAssertions;
using FluentFunctionalCoding;
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
        public void Wrap_ShouldReturnSuccess_WhenActionSucceeds()
        {            
            var subject = "Subject";
            var result = Try<string, Nothing, Exception>.Wrap(subject, DoNothingAction);
            result.Should().BeOfType<Success<string, Nothing, Exception>>();            
            (result as Success<string, Nothing, Exception>)!.Do(
                outcome => outcome._result.Should().BeOfType<Nothing>(),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnFailure_WhenActionThrowsException()
        {
            
            var subject = "Subject";
            var result = Try<string, Nothing, Exception>.Wrap(subject, DoThrowAction);
            result.Should().BeOfType<Failure<string, Nothing, Exception>>();
            (result as Failure<string, Nothing, Exception>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestActionException"),
                outcome => outcome._errorResult.Should().BeOfType<Exception>(),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnSuccess_WhenFuncSucceeds()
        {
            var subject = "Subject";
            var result = Try<string, int, Exception>.Wrap(subject, DoNothingFunc);
            result.Should().BeOfType<Success<string, int, Exception>>();
            (result as Success<string, int, Exception>)!.Do(
                outcome => outcome._result.Should().Be(-99),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnFailure_WhenFuncThrowsException()
        {

            var subject = "Subject";
            var result = Try<string, int, Exception>.Wrap(subject, DoThrowFunc);
            result.Should().BeOfType<Failure<string, int, Exception>>();
            (result as Failure<string, int, Exception>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestFuncException"),
                outcome => outcome._errorResult.Should().BeOfType<Exception>(),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }


        [Test]
        public void Wrap_ShouldReturnSuccess_WhenActionSucceeds_WithManagedExceptionAsAction()
        {
            var subject = "Subject";
            var result = Try<string, Nothing, Nothing>.Wrap(subject, DoNothingAction, MangeExceptionAction);
            result.Should().BeOfType<Success<string, Nothing, Nothing>>();
            (result as Success<string, Nothing, Nothing>)!.Do(
                outcome => outcome._result.Should().BeOfType<Nothing>(),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnCustomFailure_WhenActionThrowsException_WithManagedExceptionAsAction()
        {

            var subject = "Subject";
            var result = Try<string, Nothing, Nothing>.Wrap(subject, DoThrowAction, MangeExceptionAction);
            result.Should().BeOfType<Failure<string, Nothing, Nothing>>();
            (result as Failure<string, Nothing, Nothing>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestActionException"),
                 outcome => outcome._errorResult.Should().Be(Nothing.SoftNull),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnSuccess_WhenFuncSucceeds_WithManagedExceptionAsFunction()
        {
            var subject = "Subject";
            var result = Try<string, int, string>.Wrap(subject, DoNothingFunc, MangeExceptionFunc);
            result.Should().BeOfType<Success<string, int, string>>();
            (result as Success<string, int, string>)!.Do(
                outcome => outcome._result.Should().Be(-99),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnCustomFailure_WhenFuncThrowsException_WithManagedExceptionAsFunction()
        {

            var subject = "Subject";
            var result = Try<string, int, string>.Wrap(subject, DoThrowFunc, MangeExceptionFunc);
            result.Should().BeOfType<Failure<string, int, string>>();
            (result as Failure<string, int, string>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestFuncException"),
                outcome => outcome._errorResult.Should().Be("Managed Exception"),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }


        [Test]
        public void Wrap_ShouldReturnSuccess_WhenFuncSucceeds_WithManagedExceptionAsAction()
        {
            var subject = "Subject";
            var result = Try<string, int, Nothing>.Wrap(subject, DoNothingFunc, MangeExceptionAction);
            result.Should().BeOfType<Success<string, int, Nothing>>();
            (result as Success<string, int, Nothing>)!.Do(
                outcome => outcome._result.Should().Be(-99),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnCustomFailure_WhenFuncThrowsException_WithManagedExceptionAsAction()
        {

            var subject = "Subject";
            var result = Try<string, int, Nothing>.Wrap(subject, DoThrowFunc, MangeExceptionAction);
            result.Should().BeOfType<Failure<string, int, Nothing>>();
            (result as Failure<string, int, Nothing>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestFuncException"),
                outcome => outcome._errorResult.Should().Be(Nothing.SoftNull),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }


        [Test]
        public void Wrap_ShouldReturnSuccess_WhenActionSucceeds_WithManagedExceptionAsFunction()
        {
            var subject = "Subject";
            var result = Try<string, Nothing, string>.Wrap(subject, DoNothingAction, MangeExceptionFunc);
            result.Should().BeOfType<Success<string, Nothing, string>>();
            (result as Success<string, Nothing, string>)!.Do(
                outcome => outcome._result.Should().BeOfType<Nothing>(),
                outcome => outcome.IsSuccess.Should().BeTrue(),
                outcome => outcome._subject.Should().Be(subject));
        }

        [Test]
        public void Wrap_ShouldReturnCustomFailure_WhenActionThrowsException_WithManagedExceptionAsFunction()
        {

            var subject = "Subject";
            var result = Try<string, Nothing, string>.Wrap(subject, DoThrowAction, MangeExceptionFunc);
            result.Should().BeOfType<Failure<string, Nothing, string>>();
            (result as Failure<string, Nothing, string>)!.Do(
                outcome => outcome._Error.Message.Should().Be("TestActionException"),
                 outcome => outcome._errorResult.Should().Be("Managed Exception"),
                outcome => outcome.IsSuccess.Should().BeFalse(),
                outcome => outcome._subject.Should().Be(subject));
        }
    }
}
