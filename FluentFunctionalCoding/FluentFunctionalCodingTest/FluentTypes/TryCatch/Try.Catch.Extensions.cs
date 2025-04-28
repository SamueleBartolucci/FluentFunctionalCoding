using FluentAssertions;
using FluentFunctionalCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentTypes.Try.Catch.Extensions
{
    internal class Try
    {
        Try<string, int, Exception> GetSuccess(string intValueAsString) => new Success<string, int, Exception>(intValueAsString, int.Parse(intValueAsString)).As<Try<string, int, Exception>>();
        Try<string, int, Exception> GetFailure(string intValueAsString) => new Failure<string, int, Exception>(intValueAsString, new Exception("generic error"), new Exception("generic exception")).As<Try<string, int, Exception>>();


        [Test]
        public void Catch_OnSuccess_ShouldBeUnchanged()
        {
            GetSuccess("42").Catch((s, e) => e.Message).Do(
                tryTest => tryTest.Should().BeOfType<Success<string, int, string>>(),
                tryTest => tryTest.IsSuccess.Should().BeTrue(),
                tryTest => tryTest.IsFail.Should().BeFalse(),
                tryTest => (tryTest as Success<string, int, string>)._subject.Should().Be("42"),
                tryTest => (tryTest as Success<string, int, string>)._result.Should().Be(42));
        }
        [Test]
        public void Catch_OnFail_ShouldChangeResult()
        {
            GetFailure("XX").Catch((s, e) => e.Message).Do(
                tryTest => tryTest.Should().BeOfType<Failure<string, int, string>>(),
                tryTest => tryTest.IsSuccess.Should().BeFalse(),
                tryTest => tryTest.IsFail.Should().BeTrue(),
                tryTest => (tryTest as Failure<string, int, string>)._subject.Should().Be("XX"),
                tryTest => (tryTest as Failure<string, int, string>)._errorResult.Should().Be("generic exception"));
        }


    }
}
