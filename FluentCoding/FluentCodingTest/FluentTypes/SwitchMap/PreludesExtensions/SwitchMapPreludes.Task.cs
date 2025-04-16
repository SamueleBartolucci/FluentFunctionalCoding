using FluentAssertions;
using FluentFunctionalCoding;

namespace FluentCodingTest.SwitchMap.Preludes.Task
{
    internal class SwitchMap
    {
        [Test]
        public void SwitchMap_Func()
        {
            var subject = "test".ToTask();
            var switchFunc = subject.SwitchAsync(sbj => sbj.Length);

            switchFunc.Should().BeOfType<Task<SwitchMap<string, int>>>();
            switchFunc.Result.AsValues()._subject.Should().Be(subject.Result);
            switchFunc.Result.AsValues()._defaultOrSelectedMapFunction(switchFunc.Result.AsValues()._subject).Should().Be(4);
        }

        [Test]
        public void SwitchMap_Value()
        {
            var subject = "test".ToTask();
            var switchFunc = subject.SwitchAsync(0);

            switchFunc.Should().BeOfType<Task<SwitchMap<string, int>>>();
            switchFunc.Result.AsValues()._subject.Should().Be(subject.Result);
            switchFunc.Result.AsValues()._defaultOrSelectedMapFunction(switchFunc.Result.AsValues()._subject).Should().Be(0);
        }
    }
}
