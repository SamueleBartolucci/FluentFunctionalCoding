using FluentAssertions;
using FluentCoding;

namespace FluentCodingTest.SwitchMap.Preludes
{
    internal class SwitchMap
    {
        [Test]
        public void SwitchMap_Base()
        {
            string subject = "test";
            var switchBase = subject.Switch<string, int>();
            
            switchBase.Should().BeOfType<SwitchMapBase<string, int>>();
            switchBase._subject.Should().Be(subject);
        }

        [Test]
        public void SwitchMap_Func()
        {
            string subject = "test";
            var switchFunc = subject.Switch(sbj => sbj.Length);

            switchFunc.Should().BeOfType<SwitchMap<string, int>>();
            switchFunc._subject.Should().Be(subject);
            switchFunc._defaultOrSelectedMapFunction(switchFunc._subject).Should().Be(4);
        }


        [Test]
        public void SwitchMap_Value()
        {
            string subject = "test";
            var switchFunc = subject.Switch(0);

            switchFunc.Should().BeOfType<SwitchMap<string, int>>();
            switchFunc._subject.Should().Be(subject);
            switchFunc._defaultOrSelectedMapFunction(switchFunc._subject).Should().Be(0);
        }
    }
}
