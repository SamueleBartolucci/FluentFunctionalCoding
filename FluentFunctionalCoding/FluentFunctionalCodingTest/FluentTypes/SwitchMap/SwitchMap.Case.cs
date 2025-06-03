using FluentAssertions;
using FluentCodingTest.SwitchMap;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.SwitchMap.Case
{
    internal class SwitchMap
    {
        public SwitchMap<string, string> GetSwitch(string subject = "test") => subject.Switch("default").As<SwitchMap<string, string>>();

        [Test]
        public void Case_with_null_subject_Should_still_match()
        {
            new List<string>() { null }
            .FirstOrDefault()
            .Switch(_ => "")
            .Case(s => s.IsNull(), _ => "subject is null")
            .Case(ae => ae.Length == 10, _ => "this throw exception if reached")
            .Match()
            .Should().Be("subject is null");

            ((DateTime?)null)            
            .Switch(_ => "")
            .Case(s => s.IsNull(), _ => "subject is null")
            .Case(date => date.Value < DateTime.Now, _ => "this throw exception if reached")
            .Match()
            .Should().Be("subject is null");


            ((Stream)null)
            .Switch(_ => "")
            .Case(s => s.IsNull(), _ => "subject is null")
            .Case(strm => strm.CanRead, _ => "this throw exception if reached")
            .Match()
            .Should().Be("subject is null");

        }



        [Test]
        public void Case_bool_predicate_true()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<string, string>>();

            switchCase = switchCase.Case(false, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("default");

            switchCase = switchCase.Case(true, _ => "TRUE");
            switchCase.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("TRUE");
        }


        [Test]
        public void Case_bool_predicate_false()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  

            switchCase = switchCase.Case(false, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("default");
        }



        [Test]
        public void Case_funcnoparam_predicate_true()
        {
            var switchCase = GetSwitch();

            switchCase = switchCase.Case(() => false, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("default");

            switchCase = switchCase.Case(() => true, _ => "TRUE");
            switchCase.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("TRUE");
        }

        [Test]
        public void Case_funcnoparam_predicate_false()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  

            switchCase = switchCase.Case(() => false, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("default");
        }


        [Test]
        public void Case_func_predicate_true()
        {
            var switchCase = GetSwitch();

            switchCase = switchCase.Case(sbj => sbj == "not-equal", _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("default");

            switchCase = switchCase.Case(sbj => sbj == "test", _ => "TRUE");
            switchCase.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("TRUE");
        }

        [Test]
        public void Case_func_predicate_false()
        {
            var switchCase = GetSwitch();
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  

            switchCase = switchCase.Case(sbj => sbj == "not-equal", _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("default");
        }


        [Test]
        public void Case_multiple_predicate_true()
        {
            var switchCase = GetSwitch();

            switchCase = switchCase.Case(() => false, _ => "FALSE");
            switchCase.Should().BeOfType<DefaultCase<string, string>>();  
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("default");

            switchCase = switchCase.Case(true, _ => "TRUE");
            switchCase.Should().BeOfType<MatchedCase<string, string>>();

            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("TRUE");
            switchCase = switchCase.Case(() => true, _ => "TRUE2");
            switchCase.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("TRUE");

            switchCase = switchCase.Case(sbj => sbj == "test", _ => "TRUE3");
            switchCase.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("TRUE");

            switchCase = switchCase.Case(true, _ => "TRUE");
            switchCase.Should().BeOfType<MatchedCase<string, string>>();
            switchCase.AsValues()._defaultOrSelectedMapFunction(switchCase.AsValues()._subject).Should().Be("TRUE");
        }

    }
}
