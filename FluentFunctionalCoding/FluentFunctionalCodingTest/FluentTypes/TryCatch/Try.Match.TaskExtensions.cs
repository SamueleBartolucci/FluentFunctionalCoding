using FluentAssertions;
using FluentFunctionalCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentTypes.Try.Match.TaskExtensions
{
    internal class Try
    {
        Task<Try<string, int, string>> GetSuccess(string intValueAsString) 
            => new Success<string, int, string>(intValueAsString, int.Parse(intValueAsString))
            .As<Try<string, int, string>>()
            .ToTask();

        Task<Try<string, int, string>> GetFailure(string intValueAsString) 
            => new Failure<string, int, string>(intValueAsString, "parsing failed", new FormatException("parsing failed"))
            .As<Try<string, int, string>>()
            .ToTask();


        [Test]
        public void MatchFail_OnSuccess_WithErrorFunc_ShouldReturnSuccessValue()
        {
            GetSuccess("42").MatchFailAsync(error => -1).Result.Should().Be(42);            
        }

        [Test]
        public void MatchFail_OnSuccess_WithErrorValue_ShouldReturnSuccessValue()
        {            
            GetSuccess("42").MatchFailAsync(-2).Result.Should().Be(42);
        }

        [Test]
        public void MatchFail_OnFail_WithErrorFunc_ShouldReturnErrorFuncValue()
        {
            GetFailure("xx").MatchFailAsync(error => -1).Result.Should().Be(-1);
        }

        [Test]
        public void MatchFail_OnFail_WithErrorValue_ShouldReturnErrorFuncValue()
        {
            GetFailure("xx").MatchFailAsync(-2).Result.Should().Be(-2);
        }



        [Test]
        public void Match_OnSuccess_ShouldReturnSuccessValue()
        {
            GetSuccess("33").MatchAsync(s => s, error => -1).Result.Should().Be(33);
        }
        [Test]
        public void Match_OnFail_ShouldReturnErrorFuncValue()
        {
            GetFailure("xx").MatchAsync(s => s, error => -2).Result.Should().Be(-2);
        }


    }
}
