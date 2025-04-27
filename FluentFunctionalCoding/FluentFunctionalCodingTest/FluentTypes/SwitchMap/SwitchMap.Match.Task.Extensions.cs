using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;

namespace FluentCodingTest.SwitchMap.Match.Task.Extensions
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

        public static Task<SwitchMap<string, string>> GetSwitch(string subject = "test") => subject.Switch(_default).ToTask();

        public static string ToFALSE(string any, string append = "") => $"FALSE{append}";
        public static string ToTRUE(string any, string append = "") => $"TRUE{append}";


        [Test]
        public void Case_Match_default()
        {
            "test".Switch(_ => $"{_}-default")
                .ToTask()
                .MatchAsync()
                .Result
                .Should().Be($"test-default");
        }

        [Test]
        public void Case_Match_default_with_false_case()
        {
            "test".Switch(_ => $"{_}-default")
                  .Case(false, _ => "NO-MATCH")
                  .ToTask()
                  .MatchAsync()
                  .Result
                  .Should().Be($"test-default");
        }

        [Test]
        public void Case_Match_Case()
        {

            "test".Switch(_ => $"{_}-default")
                  .Case(false, _ => "NO-MATCH")
                  .Case(true, _ => "MATCH")
                  .ToTask()
                  .MatchAsync()
                  .Result
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
                  .ToTask()
                  .MatchAsync()
                  .Result
                  .Should().Be($"MATCH");
        }

    }
}
