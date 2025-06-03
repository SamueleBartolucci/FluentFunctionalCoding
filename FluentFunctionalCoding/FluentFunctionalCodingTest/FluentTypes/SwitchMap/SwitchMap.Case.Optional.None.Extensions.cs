using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

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
        public void CaseOptional_BoolPredicate_ReturnsDefault_WhenFalse_AndReturnsNone_WhenTrue()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());

            switchCase = switchCase.CaseOptional(true, s => ToTRUE(s));
            switchCase.Should().BeOfType<MatchedCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());
        }


        [Test]
        public void CaseOptional_BoolPredicate_ReturnsDefault_WhenFalse()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());
        }



        [Test]
        public void CaseOptional_FuncNoParamPredicate_ReturnsDefault_WhenFalse_AndReturnsNone_WhenTrue()
        {
            var switchCase = GetNoneSwitch();

            switchCase = switchCase.CaseOptional(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());

            switchCase = switchCase.CaseOptional(() => true, s => ToTRUE(s));
            switchCase.Should().BeOfType<MatchedCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());
        }

        [Test]
        public void CaseOptional_FuncNoParamPredicate_ReturnsDefault_WhenFalse()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(() => false, s => ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());
        }



        [Test]
        public void CaseOptional_FuncPredicate_AlwaysReturnsDefault()
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
        public void CaseOptional_FuncPredicate_ReturnsDefault_WhenNoMatch()
        {
            var switchCase = GetNoneSwitch();
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();

            switchCase = switchCase.CaseOptional(sbj => sbj == "not-equal", s=> ToFALSE(s));
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());
        }


        [Test]
        public void CaseOptional_MultiplePredicates_StopsAtFirstMatchOrNone()
        {
            var switchCase = GetNoneSwitch();

            switchCase = switchCase.Case(() => false, _ => _false.ToOptional());
            switchCase.Should().BeOfType<DefaultCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(_default.ToOptional());

            switchCase = switchCase.Case(true, sbj => sbj.Map(s => ToTRUE(s)));
            switchCase.Should().BeOfType<MatchedCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());

            switchCase = switchCase.Case(() => true, sbj => sbj.Map(s => ToTRUE(s, "2")));
            switchCase.Should().BeOfType<MatchedCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());

            switchCase = switchCase.CaseOptional(sbj => sbj == "test", s => ToTRUE(s, "3"));
            switchCase.Should().BeOfType<MatchedCase<Optional<string>, Optional<string>>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo(Optional<string>.None());
        }




    }
}
