using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;


namespace FluentCodingTest.Outcome.Do
{
    internal class Outcome
    {

        public Dictionary<int, string> collectorDictionary = new();
        public List<string> collectorList = new();

        public void AddToList(string s) => collectorList.Add($"Add: {s}");
        public void AddToDict(string s) => collectorDictionary.Add(int.Parse(s), s);

        public int AddToListAndReturnParse(string s) => s.Do(_ => collectorList.Add($"Add: {_}")).Map(int.Parse);
        public int AddToDictAndReturnParse(string s) => s.Do(_ => collectorDictionary.Add(int.Parse(_), s)).Map(int.Parse);


        public Outcome<string, string> FuncWithOutcomeResultFAilure(Exception e) => e.Message.ToOutcomeFailure<string, string>();

        [SetUp]
        public void Setup()
        {
            collectorDictionary.Clear();
            collectorList.Clear();
        }

        [Test]
        public void Success_Do_Action()
        {
            var result = "1".ToOutcome<Exception, string>().Do(AddToDict, AddToList);
            result.Should().BeOfType<Right<Exception, string>>();
            (result as Right<Exception, string>)!._successValue.Should().Be("1");
            collectorList.Should().Contain($"Add: 1");
            collectorDictionary.Should().ContainKey(1);
            collectorDictionary[1].Should().Be("1");
        }

        [Test]
        public void Success_Do_Function()
        {

            var result = "2".ToOutcome<Exception, string>().Do(AddToListAndReturnParse, AddToDictAndReturnParse);
            result.Should().BeOfType<Right<Exception, string>>();
            (result as Right<Exception, string>)!._successValue.Should().Be("2");
            collectorList.Should().Contain($"Add: 2");
            collectorDictionary.Should().ContainKey(2);
            collectorDictionary[2].Should().Be("2");
        }


        [Test]
        public void Failure_Do_Action()
        {
            var result = Nothing.SoftNull.ToOutcomeFailure<Nothing, string>().Do(AddToDict, AddToList);
            result.Should().BeOfType<Left<Nothing, string>>();
            collectorList.Should().BeEmpty();
            collectorDictionary.Should().BeEmpty();
        }

        [Test]
        public void Failure_Do_Function()
        {

            var result = Nothing.SoftNull.ToOutcomeFailure<Nothing, string>().Do(AddToListAndReturnParse, AddToDictAndReturnParse);
            result.Should().BeOfType<Left<Nothing, string>>();
            collectorList.Should().BeEmpty();
            collectorDictionary.Should().BeEmpty();
        }
    }
}
