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
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(false, s => ToFALSE(s));
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());

            switchCase.Case(true, s => ToTRUE(s));
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(Optional<string>.None());
        }


        [Test]
        public void Case_bool_predicate_false()
        {
            var switchCase = GetNoneSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(false, s => ToFALSE(s));
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());
        }



        [Test]
        public void Case_funcnoparam_predicate_true()
        {
            var switchCase = GetNoneSwitch();

            switchCase.Case(() => false, s => ToFALSE(s));
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());

            switchCase.Case(() => true, s => ToTRUE(s));
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(Optional<string>.None());
        }

        [Test]
        public void Case_funcnoparam_predicate_false()
        {
            var switchCase = GetNoneSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(() => false, s => ToFALSE(s));
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());
        }



        [Test]
        public void Case_func_predicate_true_but_false()
        {
            var switchCase = GetNoneSwitch();

            switchCase.Case(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());

            switchCase.Case(sbj => true, s=> ToTRUE(s));
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());
        }

        [Test]
        public void Case_func_predicate_false()
        {
            var switchCase = GetNoneSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());
        }


        [Test]
        public void Case_multiple_predicate_true()
        {
            var switchCase = GetNoneSwitch();

            switchCase.Case(() => false, _ => _false.ToOptional());
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(_default.ToOptional());

            switchCase.Case(true, sbj => sbj.Map(s => ToTRUE(s)));
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(Optional<string>.None());

            switchCase.Case(() => true, sbj => sbj.Map(s => ToTRUE(s, "2")));
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(Optional<string>.None());

            switchCase.Case(sbj => sbj == "test", s => ToTRUE(s, "3"));
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be(Optional<string>.None());
        }




    }
}
