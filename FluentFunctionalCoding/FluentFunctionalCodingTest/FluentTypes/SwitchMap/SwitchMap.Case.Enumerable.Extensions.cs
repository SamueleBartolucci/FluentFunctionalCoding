using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.SwitchMap.Case.Enumerable.Extensions
{
    internal class SwitchMap
    {
        IEnumerable<int> defaultSubject = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        public SwitchMap<IEnumerable<int>, string> GetSwitch() => defaultSubject.Switch("default");



        [Test]
        public void CaseAny_ReturnsDefault_WhenNoMatch_AndReturnsValue_WhenMatchFound()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseAny(value => value == 5, _ => "Found-5");
            switchCase.Should().BeOfType<MatchedCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("Found-5");
        }


        [Test]
        public void CaseAny_ReturnsDefault_WhenNoMatch()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseAny(value => value == 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }


        [Test]
        public void CaseAll_ReturnsDefault_WhenNoMatch_AndReturnsValue_WhenAllMatch()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseAll(value => value > 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");

            switchCase = switchCase.CaseAll(value => value < 10, _ => "All-less-10");
            switchCase.Should().BeOfType<MatchedCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("All-less-10");

            switchCase = switchCase.CaseAll(value => value < 99, _ => "All-less-99");
            switchCase.Should().BeOfType<MatchedCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("All-less-10");
        }


        [Test]
        public void CaseAll_ReturnsDefault_WhenNoMatch()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseAny(value => value > 100, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }


        [Test]
        public void CaseIsEmpty_ReturnsDefault_WhenNotEmpty()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseIsEmpty(_ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }

        [Test]
        public void CaseIsEmpty_ReturnsValue_WhenEmpty()
        {
            var switchCase = defaultSubject.Where(_ => false).Switch("default");
            switchCase = switchCase.CaseIsEmpty(_ => "EMPTY");
            switchCase.Should().BeOfType<MatchedCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("EMPTY");
        }

        [Test]
        public void CaseIsNotEmpty_ReturnsValue_WhenNotEmpty()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseIsNotEmpty(_ => "NOT-EMPTY");
            switchCase.Should().BeOfType<MatchedCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("NOT-EMPTY");
        }

        [Test]
        public void CaseIsNotEmpty_ReturnsDefault_WhenEmpty()
        {
            var switchCase = defaultSubject.Where(_ => false).Switch("default");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseIsNotEmpty(_ => "EMPTY");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }

        [Test]
        public void CaseCount_ReturnsValue_WhenCountMatches()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseCount(7, _ => "COUNT");
            switchCase.Should().BeOfType<MatchedCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("COUNT");
        }

        [Test]
        public void CaseCount_ReturnsDefault_WhenCountDoesNotMatch()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();

            switchCase = switchCase.CaseCount(99, _ => "NO-COUNT");
            switchCase.Should().BeOfType<DefaultCase<IEnumerable<int>, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().BeEquivalentTo("default");
        }




    }
}
