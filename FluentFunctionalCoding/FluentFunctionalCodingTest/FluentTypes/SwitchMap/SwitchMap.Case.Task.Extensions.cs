using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.SwitchMap.Case.Task.Extensions
{
    internal class SwitchMap
    {
        [OneTimeTearDown]
        public void dispose()
        {
            //_default?.Dispose();
            //_FALSE?.Dispose();
            //_TRUE?.Dispose();
        }

        //public static string _false = "false";
        //public static string _true = "true";
        public static string _default = "default";//.ToTask();
        public static string _FALSE = "FALSE";//.ToTask();
        public static string _TRUE = "TRUE";//.ToTask();

        public static Task<SwitchMap<string, string>> GetSwitch(string subject = "test") => subject.Switch(_default).ToTask();

        public static string ToFALSE(string any, string append = "") => $"FALSE{append}";
        public static string ToTRUE(string any, string append = "") => $"TRUE{append}";
        

        [Test]
        public void CaseAsync_BoolPredicate_ReturnsDefault_WhenFalse_AndReturnsValue_WhenTrue()
        {
            var switchCase = GetSwitch();
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();

            switchCase = switchCase.CaseAsync(false, s => ToFALSE(s));
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseAsync(true, s => ToTRUE(s));
            switchCase.Result.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_TRUE);
        }


        [Test]
        public void CaseAsync_BoolPredicate_ReturnsDefault_WhenFalse()
        {
            var switchCase = GetSwitch();
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();

            switchCase = switchCase.CaseAsync(false, s => ToFALSE(s));
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_default);
        }



        [Test]
        public void CaseAsync_FuncNoParamPredicate_ReturnsDefault_WhenFalse_AndReturnsValue_WhenTrue()
        {
            var switchCase = GetSwitch();

            switchCase = switchCase.CaseAsync(() => false, s => ToFALSE(s));
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseAsync(() => true, s => ToTRUE(s));
            switchCase.Result.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_TRUE);
        }

        [Test]
        public void CaseAsync_FuncNoParamPredicate_ReturnsDefault_WhenFalse()
        {
            var switchCase = GetSwitch();
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();

            switchCase = switchCase.CaseAsync(() => false, s => ToFALSE(s));
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_default);
        }


        [Test]
        public void CaseAsync_FuncPredicate_ReturnsDefault_WhenNoMatch_AndReturnsValue_WhenMatch()
        {
            var switchCase = GetSwitch();

            switchCase = switchCase.CaseAsync(sbj => sbj == "not-equal", s => ToFALSE(s));
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseAsync(sbj => sbj == "test", s => ToTRUE(s));
            switchCase.Result.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_TRUE);
        }

        [Test]
        public void CaseAsync_FuncPredicate_ReturnsDefault_WhenNoMatch()
        {
            var switchCase = GetSwitch();
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();

            switchCase = switchCase.CaseAsync(sbj => sbj == "not-equal", s => ToFALSE(s));
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_default);
        }


        [Test]
        public void CaseAsync_MultiplePredicates_StopsAtFirstMatch()
        {
            var switchCase = GetSwitch();

            switchCase = switchCase.CaseAsync(() => false, s => ToFALSE(s));
            switchCase.Result.Should().BeOfType<DefaultCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseAsync(true, s => ToTRUE(s));
            switchCase.Result.Should().BeOfType<MatchedCase<string, string>>();

            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_TRUE);
            switchCase = switchCase.CaseAsync(() => true, _ => "TRUE2");
            switchCase.Result.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_TRUE);

            switchCase = switchCase.CaseAsync(sbj => sbj == "test", _ => "TRUE3");
            switchCase.Result.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_TRUE);

            switchCase = switchCase.CaseAsync(true, s => ToTRUE(s));
            switchCase.Result.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.Result.AsValues()._defaultOrSelectedMapFunction(switchCase.Result.AsValues()._subject).Should().Be(_TRUE);
        }

    }
}
