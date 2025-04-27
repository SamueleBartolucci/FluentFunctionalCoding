using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.Optional.Do
{
    internal class Optional
    {
        List<string> doCollector = new List<string>();
        public void DoAction(string s) => doCollector.Add($"{s}_{doCollector.Count}");
        public int DoFunc(string s)
        {
            doCollector.Add($"{doCollector.Count}_{s}");
            return doCollector.Count;
        }


        [SetUp]
        public void CleanStatus()
        {
            doCollector = new List<string>();
        }

        [Test]
        public void Do_Actions()
        {
            var testString = "test";
            var optionalString = testString.ToOptional();
            optionalString.Do(DoAction, DoAction);
            doCollector.Should().HaveCount(2);
            doCollector.Contains($"{testString}_0").Should().BeTrue();
            doCollector.Contains($"{testString}_1").Should().BeTrue();
            doCollector.Contains($"{testString}_3").Should().BeFalse();
        }


        [Test]
        public void Do_Funcs()
        {
            var testString = "test";
            var optionalString = testString.ToOptional();
            optionalString.Do(DoFunc, DoFunc);
            doCollector.Should().HaveCount(2);
            doCollector.Contains($"0_{testString}").Should().BeTrue();
            doCollector.Contains($"1_{testString}").Should().BeTrue();
            doCollector.Contains($"3_{testString}").Should().BeFalse();
        }
    }
}
