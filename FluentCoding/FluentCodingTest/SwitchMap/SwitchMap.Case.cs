using FluentAssertions;
using FluentFunctionalCoding;

namespace FluentCodingTest.SwitchMap.Case
{
    internal class SwitchMap
    {
        public SwitchMap<string, string> GetSwitch(string subject = "test") => subject.Switch("default").As<SwitchMap<string, string>>();

        [Test]
        public void Case_bool_predicate_true()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(false, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");

            switchCase.Case(true, _ => "TRUE");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("TRUE");
        }


        [Test]
        public void Case_bool_predicate_false()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(false, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }



        [Test]
        public void Case_funcnoparam_predicate_true()
        {
            var switchCase = GetSwitch();

            switchCase.Case(() => false, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");

            switchCase.Case(() => true, _ => "TRUE");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("TRUE");
        }

        [Test]
        public void Case_funcnoparam_predicate_false()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(() => false, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }


        [Test]
        public void Case_func_predicate_true()
        {
            var switchCase = GetSwitch();

            switchCase.Case(sbj => sbj == "not-equal", _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");

            switchCase.Case(sbj => sbj == "test", _ => "TRUE");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("TRUE");
        }

        [Test]
        public void Case_func_predicate_false()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.Case(sbj => sbj == "not-equal", _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }


        [Test]
        public void Case_multiple_predicate_true()
        {
            var switchCase = GetSwitch();

            switchCase.Case(() => false, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");

            switchCase.Case(true, _ => "TRUE");
            switchCase._validPredicatFound.Should().BeTrue();

            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("TRUE");
            switchCase.Case(() => true, _ => "TRUE2");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("TRUE");

            switchCase.Case(sbj => sbj == "test", _ => "TRUE3");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("TRUE");

            switchCase.Case(true, _ => "TRUE");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("TRUE");
        }

    }
}
