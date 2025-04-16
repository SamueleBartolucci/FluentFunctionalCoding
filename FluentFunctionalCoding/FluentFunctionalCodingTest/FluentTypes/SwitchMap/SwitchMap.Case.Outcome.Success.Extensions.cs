using FluentAssertions;
using FluentFunctionalCoding;

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
        public void Case_bool_predicate_true()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseOutcome(true, s => ToTRUE(s));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_TRUE);
        }


        [Test]
        public void Case_bool_predicate_false()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(false, s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);
        }



        [Test]
        public void Case_funcnoparam_predicate_true()
        {
            var switchCase = GetOutcomeSwitch();

            switchCase = switchCase.CaseOutcome(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseOutcome(() => true, s => ToTRUE(s));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_TRUE);
        }

        [Test]
        public void Case_funcnoparam_predicate_false()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);
        }


        [Test]
        public void Case_func_predicate_true()
        {
            var switchCase = GetOutcomeSwitch();

            switchCase = switchCase.CaseOutcome(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);

            switchCase = switchCase.CaseOutcome(sbj => sbj == "test", s=> ToTRUE(s));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_TRUE);
        }

        [Test]
        public void Case_func_predicate_false()
        {
            var switchCase = GetOutcomeSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be(_default);
        }


        [Test]
        public void Case_multiple_predicate_true()
        {
            var switchCase = GetOutcomeSwitch();

            switchCase = switchCase.CaseOutcome(() => false, _ => ToFALSE(_));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject)
                .Should().Be(_default);

            switchCase = switchCase.CaseOutcome(true, sbj => ToTRUE(sbj));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_TRUE);

            switchCase = switchCase.CaseOutcome(() => true, sbj => ToTRUE(sbj, "2"));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_TRUE);

            switchCase = switchCase.CaseOutcome(sbj => sbj == "test", s => ToTRUE(s, "3"));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_TRUE);
        }
    }
}
