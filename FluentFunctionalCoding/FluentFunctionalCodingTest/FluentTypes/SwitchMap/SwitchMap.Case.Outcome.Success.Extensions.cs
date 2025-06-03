using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.SwitchMap.Case.Outcome.Success.Extensions
{

    internal class SwitchMap
    {
        //public static string _false = "false";
        //public static string _true = "true";
        public static Outcome<bool, string> _default = "default".ToOutcome<bool, string>();
        public static Outcome<bool, string> _FALSE = "FALSE".ToOutcome<bool, string>();
        public static Outcome<bool, string> _TRUE = "TRUE".ToOutcome<bool, string>();

        public static SwitchMap<Outcome<bool, string>, Outcome<bool, string>> GetOutcomeSwitch(string subject = "test") => subject.ToOutcome<bool, string>().Switch(_default);        

        public static string ToFALSE(string any, string append = "") => $"FALSE{append}";
        public static string ToTRUE(string any, string append = "") => $"TRUE{append}";


        [Test]
        public void CaseOutcome_BoolPredicate_ReturnsDefault_WhenFalse_AndReturnsValue_WhenTrue()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseOutcome(true, s => ToTRUE(s));
            switchCase.Should().BeOfType<MatchedCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_TRUE);
        }


        [Test]
        public void CaseOutcome_BoolPredicate_ReturnsDefault_WhenFalse()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(false, s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);
        }



        [Test]
        public void CaseOutcome_FuncNoParamPredicate_ReturnsDefault_WhenFalse_AndReturnsValue_WhenTrue()
        {
            var switchCase = GetOutcomeSwitch();

            switchCase = switchCase.CaseOutcome(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseOutcome(() => true, s => ToTRUE(s));
            switchCase.Should().BeOfType<MatchedCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_TRUE);
        }

        [Test]
        public void CaseOutcome_FuncNoParamPredicate_ReturnsDefault_WhenFalse()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);
        }


        [Test]
        public void CaseOutcome_FuncPredicate_ReturnsDefault_WhenNoMatch_AndReturnsValue_WhenMatch()
        {
            var switchCase = GetOutcomeSwitch();

            switchCase = switchCase.CaseOutcome(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseOutcome(sbj => sbj == "test", s=> ToTRUE(s));
            switchCase.Should().BeOfType<MatchedCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_TRUE);
        }

        [Test]
        public void CaseOutcome_FuncPredicate_ReturnsDefault_WhenNoMatch()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);
        }


        [Test]
        public void CaseOutcome_MultiplePredicates_StopsAtFirstMatch()
        {
            var switchCase = GetOutcomeSwitch();

            switchCase = switchCase.CaseOutcome(() => false, _ => ToFALSE(_));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject)
                .Should().Be(_default);

            switchCase = switchCase.CaseOutcome(true, sbj => ToTRUE(sbj));
            switchCase.Should().BeOfType<MatchedCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_TRUE);

            switchCase = switchCase.CaseOutcome(() => true, sbj => ToTRUE(sbj, "2"));
            switchCase.Should().BeOfType<MatchedCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_TRUE);

            switchCase = switchCase.CaseOutcome(sbj => sbj == "test", s => ToTRUE(s, "3"));
            switchCase.Should().BeOfType<MatchedCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_TRUE);
        }
    }
}
