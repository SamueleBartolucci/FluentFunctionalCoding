using FluentAssertions;
using FluentFunctionalCoding;

namespace FluentCodingTest.SwitchMap.Case.Optional.None.Extensions
{

    internal class SwitchMap
    {
        public static string _false = "false";
        public static string _true = "true";
        public static string _default = "default";

        public static string _FALSE = "FALSE";
        public static string _TRUE = "TRUE";

        public static SwitchMap<Optional<string>, Optional<string>> GetNoneSwitch(string subject = "test") => subject.ToOptionalNone().Switch(_default.ToOptional());
        //public static SwitchMap<Optional<string>, Optional<string>> GetNoneSwitch() => "".ToOptionalNone().Switch(_default.ToOptional());


        public static string ToFALSE(string any, string append = "") => $"FALSE{append}";
        public static string ToTRUE(string any, string append = "") => $"TRUE{append}";

        [Test]
        public void Case_bool_predicate_true()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());

            switchCase = switchCase.CaseOptional(true, s => ToTRUE(s));
            switchCase.Should().BeOfType<PredicateMatchCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());
        }


        [Test]
        public void Case_bool_predicate_false()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());
        }



        [Test]
        public void Case_funcnoparam_predicate_true()
        {
            var switchCase = GetNoneSwitch();

            switchCase = switchCase.CaseOptional(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());

            switchCase = switchCase.CaseOptional(() => true, s => ToTRUE(s));
            switchCase.Should().BeOfType<PredicateMatchCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());
        }

        [Test]
        public void Case_funcnoparam_predicate_false()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());
        }



        [Test]
        public void Case_func_predicate_true_but_false()
        {
            var switchCase = GetNoneSwitch();

            switchCase = switchCase.CaseOptional(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());

            switchCase = switchCase.CaseOptional(sbj => true, s=> ToTRUE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());
        }

        [Test]
        public void Case_func_predicate_false()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());
        }


        [Test]
        public void Case_multiple_predicate_true()
        {
            var switchCase = GetNoneSwitch();

            switchCase = switchCase.Case(() => false, _ => _false.ToOptional());
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());

            switchCase = switchCase.Case(true, sbj => sbj.Map(s => ToTRUE(s)));
            switchCase.Should().BeOfType<PredicateMatchCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());

            switchCase = switchCase.Case(() => true, sbj => sbj.Map(s => ToTRUE(s, "2")));
            switchCase.Should().BeOfType<PredicateMatchCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());

            switchCase = switchCase.CaseOptional(sbj => sbj == "test", s => ToTRUE(s, "3"));
            switchCase.Should().BeOfType<PredicateMatchCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());
        }




    }
}
