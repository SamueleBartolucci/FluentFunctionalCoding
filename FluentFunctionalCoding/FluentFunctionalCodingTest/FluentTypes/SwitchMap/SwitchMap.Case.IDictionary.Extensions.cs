using FluentAssertions;
using FluentFunctionalCoding;

namespace FluentCodingTest.SwitchMap.Case.IDictionary.Extensions
{
    internal class SwitchMap
    {
        IDictionary<int, string> defaultSubject = new Dictionary<int, string>() 
        {
            { 0, "0" },
            { 1, "1" },
            { 2, "2" },
            { 3, "3" }, 
        };

        public SwitchMap<IDictionary<int, string>, string> GetSwitch() => defaultSubject.Switch("default");



        [Test]
        public void Case_CaseContainsKey_true()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 

            switchCase = switchCase.CaseContainsKey(9, sbj => sbj[9]);
            switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

             switchCase = switchCase.CaseContainsKey(3, sbj => sbj[3]);
            switchCase.Should().BeOfType<PredicateMatchCase<IDictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("3");
        }


        [Test]
        public void Case_CaseContainsKey_false()
        {
            var switchCase = GetSwitch();
             switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 

            switchCase = switchCase.CaseContainsKey(9, sbj => sbj[9]);
            switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseContainsKey(5, sbj => sbj[5]);
            switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }


        [Test]
        public void CaseContains_true()
        {
            var switchCase = GetSwitch();
             switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(10, "10"), sbj => sbj[10]);
            switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(1, "1"), sbj => sbj[1]);
            switchCase.Should().BeOfType<PredicateMatchCase<IDictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("1");

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(2, "2"), sbj => sbj[2]);
            switchCase.Should().BeOfType<PredicateMatchCase<IDictionary<int, string>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("1");
        }


        [Test]
        public void CaseContains_false()
        {
            var switchCase = GetSwitch();
             switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(10, "10"), sbj => sbj[10]);
             switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseContains(new KeyValuePair<int, string>(11, "11"), sbj => sbj[11]);
             switchCase.Should().BeOfType<DefaultCase<IDictionary<int, string>, string>>(); 
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

        }




    }
}
