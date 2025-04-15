using FluentAssertions;
using FluentFunctionalCoding;

namespace FluentCodingTest.SwitchMap.Case.Extensions.IList
{

    internal class SwitchMap
    {
        IList<int> defaultSubject = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        public SwitchMap<IList<int>, string> GetSwitch() => defaultSubject.Switch("default");



        [Test]
        public void Case_CaseAny_true()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");

            switchCase.CaseAny(value => value == 5, _ => "Found-5");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("Found-5");
        }


        [Test]
        public void Case_CaseAny_false()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }


        [Test]
        public void Case_CaseAll_true()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseAll(value => value > 100, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");

            switchCase.CaseAll(value => value < 10, _ => "All-less-10");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("All-less-10");

            switchCase.CaseAll(value => value < 99, _ => "All-less-99");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("All-less-10");
        }


        [Test]
        public void Case_CaseAll_false()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseAny(value => value > 100, _ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }


        [Test]
        public void Case_IsEmpty_false()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseIsEmpty(_ => "FALSE");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }

        [Test]
        public void Case_IsEmpty_true()
        {
            var switchCase = new List<int>(defaultSubject).Do(l => l.Clear()).Switch("default");
            switchCase.CaseIsEmpty(_ => "EMPTY");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("EMPTY");
        }

        [Test]
        public void Case_IsNotEmpty_true()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseIsNotEmpty(_ => "NOT-EMPTY");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("NOT-EMPTY");
        }

        [Test]
        public void Case_IsNotEmpty_false()
        {
            var switchCase = new List<int>(defaultSubject).Do(l => l.Clear()).Switch("default");
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseIsNotEmpty(_ => "EMPTY");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }

        [Test]
        public void Case_Count_true()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseCount(7, _ => "COUNT");
            switchCase._validPredicatFound.Should().BeTrue();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("COUNT");
        }

        [Test]
        public void Case_Count_false()
        {
            var switchCase = GetSwitch();
            switchCase._validPredicatFound.Should().BeFalse();

            switchCase.CaseCount(99, _ => "NO-COUNT");
            switchCase._validPredicatFound.Should().BeFalse();
            switchCase._defaultOrSelectedMapFunction(switchCase._subject).Should().Be("default");
        }




    }
}
