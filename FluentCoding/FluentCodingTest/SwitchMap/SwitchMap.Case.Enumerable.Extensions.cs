using FluentAssertions;
using FluentCoding;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace FluentCodingTest.SwitchMap.Case.Enumerable.Extensions
{
    internal static class UtilsSwitch
    {        public static SwitchMap<List<int>, string> AsBase(this ISwitchMap<IEnumerable<int>, string> super)
            => super.As<SwitchMap<List<int>, string>>();
    }

    internal class SwitchMap
    {
        List<int> defaultSubject = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        public ISwitchMap<IEnumerable<int>, string> GetSwitch() => defaultSubject.Switch("default").As<SwitchMap<List<int>, string>>();

        

        [Test]
        public void Case_CaseAny_true()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("default");

            switchCase.CaseAny(value => value == 5, _ => "Found-5");
            switchCase.AsBase()._validPredicatFound.Should().BeTrue();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("Found-5");
        }


        [Test]
        public void Case_CaseAny_false()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("default");
        }


        [Test]
        public void Case_CaseAll_true()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseAll(value => value > 100, _ => "FALSE");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("default");

            switchCase.CaseAll(value => value < 10, _ => "All-less-10");
            switchCase.AsBase()._validPredicatFound.Should().BeTrue();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("All-less-10");

            switchCase.CaseAll(value => value < 99, _ => "All-less-99");
            switchCase.AsBase()._validPredicatFound.Should().BeTrue();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("All-less-10");
        }


        [Test]
        public void Case_CaseAll_false()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseAny(value => value > 100, _ => "FALSE");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("default");
        }


        [Test]
        public void Case_IsEmpty_false()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseIsEmpty(_ => "FALSE");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("default");
        }

        [Test]
        public void Case_IsEmpty_true()
        {
            var switchCase = new List<int>(defaultSubject).Do(l => l.Clear()).Switch("default");
            switchCase.CaseIsEmpty(_ => "EMPTY");
            switchCase.AsBase()._validPredicatFound.Should().BeTrue();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("EMPTY");
        }

        [Test]
        public void Case_IsNotEmpty_true()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseIsNotEmpty(_ => "NOT-EMPTY");
            switchCase.AsBase()._validPredicatFound.Should().BeTrue();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("NOT-EMPTY");
        }

        [Test]
        public void Case_IsNotEmpty_false()
        {
            var switchCase = new List<int>(defaultSubject).Do(l => l.Clear()).Switch("default");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseIsNotEmpty(_ => "EMPTY");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("default");
        }

        [Test]
        public void Case_Count_true()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseCount(7, _ => "COUNT");
            switchCase.AsBase()._validPredicatFound.Should().BeTrue();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("COUNT");
        }

        [Test]
        public void Case_Count_false()
        {
            var switchCase = GetSwitch();
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();

            switchCase.CaseCount(99, _ => "NO-COUNT");
            switchCase.AsBase()._validPredicatFound.Should().BeFalse();
            switchCase.AsBase()._defaultOrSelectedMapFunction(switchCase.AsBase()._subject).Should().Be("default");
        }




    }
}
