﻿using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.SwitchMap.Case.Dictionary.Extensions
{
    internal class SwitchMap
    {
        Dictionary<int, string> defaultSubject = new Dictionary<int, string>() 
        {
            { 0, "0" },
            { 1, "1" },
            { 2, "2" },
            { 3, "3" }, 
        };

        public SwitchMap<Dictionary<int, string>, string> GetSwitch() => defaultSubject.Switch("default");



        [Test]
        public void CaseContainsKey_ReturnsDefault_WhenKeyMissing_AndReturnsValue_WhenKeyPresent()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();

            switchCase = switchCase.CaseContainsKey(9, sbj => sbj[9]);
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseContainsKey(3, sbj => sbj[3]);
            switchCase.Should().BeOfType<MatchedCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("3");
        }


        [Test]
        public void CaseContainsKey_ReturnsDefault_WhenKeyMissing()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();

            switchCase = switchCase.CaseContainsKey(9, sbj => sbj[9]);
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseContainsKey(5, sbj => sbj[5]);
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }


        [Test]
        public void CaseContains_ReturnsDefault_WhenPairMissing_AndReturnsValue_WhenPairPresent()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(10, "10"), sbj => sbj[10]);
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(1, "1"), sbj => sbj[1]);
            switchCase.Should().BeOfType<MatchedCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("1");

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(2, "2"), sbj => sbj[2]);
            switchCase.Should().BeOfType<MatchedCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("1");
        }


        [Test]
        public void CaseContains_ReturnsDefault_WhenPairMissing()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(10, "10"), sbj => sbj[10]);
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(11, "11"), sbj => sbj[11]);
            switchCase.Should().BeOfType<DefaultCase<Dictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

        }




    }
}
