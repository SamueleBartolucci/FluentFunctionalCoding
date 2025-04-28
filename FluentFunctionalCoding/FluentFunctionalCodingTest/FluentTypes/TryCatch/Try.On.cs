using FluentAssertions;
using FluentFunctionalCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.FluentTypes.Try.On
{
    internal class Try
    {
        Try<string, int, string> GetSuccess(string intValueAsString) => new Success<string, int, string>(intValueAsString, int.Parse(intValueAsString)).As<Try<string, int, string>>();
        Try<string, int, string> GetFailure(string intValueAsString) => new Failure<string, int, string>(intValueAsString, "parsing failed", new FormatException("parsing failed")).As<Try<string, int, string>>();

        List<int> actionCollector = new List<int>();        

        [SetUp]
        public void CleanStatus()
        {
            actionCollector = new List<int>();
        }

        [Test]
        public void Success_OnSuccess_TInAndTOut_ShouldBeApplied()
        {
            GetSuccess("42").OnSuccess((sbj, res) => actionCollector.Add(int.Parse(sbj) + res));
            actionCollector.Should().HaveCount(1);
            actionCollector.Should().Contain(42 + 42);
        }

        [Test]
        public void Fail_OnSuccess_TInAndTOut_ShouldNotBeApplied()
        {
            GetFailure("xx").OnSuccess((sbj, res) => actionCollector.Add(int.Parse(sbj) + res));
            actionCollector.Should().HaveCount(0);
        }

        [Test]
        public void Success_OnSuccess_TOut_ShouldBeApplied()
        {
            GetSuccess("42").OnSuccess(actionCollector.Add);
            actionCollector.Should().HaveCount(1);
            actionCollector.Should().Contain(42);
        }

        [Test]
        public void Fail_OnSuccess_TOut_ShouldNotBeApplied()
        {
            GetFailure("xx").OnSuccess(actionCollector.Add);
            actionCollector.Should().HaveCount(0);
        }


        [Test]
        public void Fail_OnFail_TInAndTErr_ShouldBeApplied()
        {
            GetFailure("1").OnFail((sbj, errString) => actionCollector.Do(c => c.Add(int.Parse(sbj)), c => c.Add(errString.Length)));
            actionCollector.Should().HaveCount(2);
            actionCollector.Should().Contain(1);
            actionCollector.Should().Contain(14);
        }

        [Test]
        public void Success_OnFail_TInAndTErr_ShouldNotBeApplied()
        {
            GetSuccess("1").OnFail((sbj, errString) => actionCollector.Do(c => c.Add(int.Parse(sbj)), c => c.Add(errString.Length)));
            actionCollector.Should().HaveCount(0);
        }

        [Test]
        public void Fail_OnFail_TIn_ShouldBeApplied()
        {
            GetFailure("1").OnFail(sbj => actionCollector.Add(int.Parse(sbj)));
            actionCollector.Should().HaveCount(1);
            actionCollector.Should().Contain(1);;
        }

        [Test]
        public void Success_OnFail_TIn_ShouldNotBeApplied()
        {
            GetSuccess("1").OnFail(sbj => actionCollector.Add(int.Parse(sbj)));
            actionCollector.Should().HaveCount(0);
        }
    }
}
