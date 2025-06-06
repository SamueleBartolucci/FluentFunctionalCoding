﻿using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

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
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseAny(value => value == 5, _ => "Found-5");
            switchCase.Should().BeOfType<MatchedCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("Found-5");
        }


        [Test]
        public void Case_CaseAny_false()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }


        [Test]
        public void Case_CaseAll_true()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseAll(value => value > 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseAll(value => value < 10, _ => "All-less-10");
            switchCase.Should().BeOfType<MatchedCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("All-less-10");

            switchCase = switchCase.CaseAll(value => value < 99, _ => "All-less-99");
            switchCase.Should().BeOfType<MatchedCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("All-less-10");
        }


        [Test]
        public void Case_CaseAll_false()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseAny(value => value > 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }


        [Test]
        public void Case_IsEmpty_false()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseIsEmpty(_ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }

        [Test]
        public void Case_IsEmpty_true()
        {
            IList<int> test = defaultSubject.Where(_ => false).ToArray();
            var switchCase = test.Switch("default");
            switchCase = switchCase.CaseIsEmpty(_ => "EMPTY");
            switchCase.Should().BeOfType<MatchedCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("EMPTY");
        }

        [Test]
        public void Case_IsNotEmpty_true()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseIsNotEmpty(_ => "NOT-EMPTY");
            switchCase.Should().BeOfType<MatchedCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("NOT-EMPTY");
        }

        [Test]
        public void Case_IsNotEmpty_false()
        {
            IList<int> test = defaultSubject.Where(_ => false).ToArray();
            var switchCase = test.Switch("default");

            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseIsNotEmpty(_ => "EMPTY");
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }

        [Test]
        public void Case_Count_true()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseCount(7, _ => "COUNT");
            switchCase.Should().BeOfType<MatchedCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("COUNT");
        }

        [Test]
        public void Case_Count_false()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();

            switchCase = switchCase.CaseCount(99, _ => "NO-COUNT");
            switchCase.Should().BeOfType<DefaultCase<IList<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }




    }
}
