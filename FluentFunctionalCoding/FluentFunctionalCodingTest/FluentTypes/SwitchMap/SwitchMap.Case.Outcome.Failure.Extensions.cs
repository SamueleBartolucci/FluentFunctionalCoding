using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.SwitchMap.Case.Outcome.Failure.Extensions
{

    internal class SwitchMap
    {
        public static Outcome<bool, string> _default = "default".ToOutcome<bool, string>();
        public static Outcome<bool, string> _FALSE = "FALSE".ToOutcome<bool, string>();
        public static Outcome<bool, string> _TRUE = "TRUE".ToOutcome<bool, string>();

        public static Outcome<bool, string> _Fail= true.ToOutcomeFailure<bool, string>();

        public static SwitchMap<Outcome<bool, string>, Outcome<bool, string>> GetOutcomeFailSwitch(string subject = "test") => true.ToOutcomeFailure<bool, string>().Switch(_default);

        public static string ToFALSE(string any, string append = "") => $"FALSE{append}";
        public static string ToTRUE(string any, string append = "") => $"TRUE{append}";

        [Test]
        public void Case_bool_predicate_true()
        {
            var switchCase = GetOutcomeFailSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);

            switchCase = switchCase.CaseOutcome(true, s => ToTRUE(s));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_Fail);
        }


        [Test]
        public void Case_bool_predicate_false()
        {
            var switchCase = GetOutcomeFailSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);
        }



        [Test]
        public void Case_funcnoparam_predicate_true()
        {
            var switchCase = GetOutcomeFailSwitch();

            switchCase = switchCase.CaseOutcome(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);

            switchCase = switchCase.CaseOutcome(() => true, s => ToTRUE(s));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_Fail);
        }

        [Test]
        public void Case_funcnoparam_predicate_false()
        {
            var switchCase = GetOutcomeFailSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);
        }



        [Test]
        public void Case_func_predicate_true_but_false()
        {
            var switchCase = GetOutcomeFailSwitch();

            switchCase = switchCase.CaseOutcome(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);

            switchCase = switchCase.CaseOutcome(sbj => true, s=> ToTRUE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);
        }

        [Test]
        public void Case_func_predicate_false()
        {
            var switchCase = GetOutcomeFailSwitch();
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();

            switchCase = switchCase.CaseOutcome(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);
        }


        [Test]
        public void Case_multiple_predicate_true()
        {
            var switchCase = GetOutcomeFailSwitch();

            switchCase = switchCase.CaseOutcome(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default);

            switchCase = switchCase.CaseOutcome(true, sbj => sbj.Map(s => ToTRUE(s)));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_Fail);

            switchCase = switchCase.CaseOutcome(() => true, sbj => sbj.Map(s => ToTRUE(s, "2")));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_Fail);

            switchCase = switchCase.CaseOutcome(sbj => sbj == "test", s => ToTRUE(s, "3"));
            switchCase.Should().BeOfType<PredicateMatchCase<Outcome<bool, string>, Outcome<bool, string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_Fail);
        }




    }
}
