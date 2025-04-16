using FluentAssertions;
using FluentFunctionalCoding;

namespace FluentCodingTest.SwitchMap.Match
{
    internal class SwitchMap
    {
        [OneTimeTearDown]
        public void dispose()
        {
            //_default?.Dispose();
            //_FALSE?.Dispose();
            //_TRUE?.Dispose();
        }

        public static string _default = "default";
        public static string _FALSE = "FALSE";
        public static string _TRUE = "TRUE";

        public static SwitchMap<string, string> GetSwitch(string subject = "test") => subject.Switch(_default);

        public static string ToFALSE(string any, string append = "") => $"FALSE{append}";
        public static string ToTRUE(string any, string append = "") => $"TRUE{append}";
        

        [Test]
        public void Case_Match_default()
        {
            "test".Switch(_ => $"{_}-default")
                .Match()
                .Should().Be($"test-default");
        }

        [Test]
        public void Case_Match_default_with_false_case()
        {
            "test".Switch(_ => $"{_}-default")
                  .Case(false, _ => "NO-MATCH")
                  .Match()
                  .Should().Be($"test-default");
        }

        [Test]
        public void Case_Match_Case()
        {

            "test".Switch(_ => $"{_}-default")
                  .Case(false, _ => "NO-MATCH")
                  .Case(true, _ => "MATCH")
                  .Match()
                  .Should().Be($"MATCH");
        }


        [Test]
        public void Case_Match_Case_multiple_true_predicates()
        {

            "test".Switch(_ => $"{_}-default")
                  .Case(false, _ => "NO-MATCH")
                  .Case(true, _ => "MATCH")
                  .Case(true, _ => "ALREADY-MATCHED")
                  .Case(false, _ => "NO-MATCH")
                  .Case(true, _ => "ALREADY-MATCHED")
                  .Case(false, _ => "NO-MATCH")
                  .Case(true, _ => "ALREADY-MATCHED")
                  .Match()
                  .Should().Be($"MATCH");
        }

    }
}
