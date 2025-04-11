using FluentAssertions;
using FluentCoding;


namespace FluentCodingTest
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        public bool IsHAppyDaySubj(string day) => false;
        public bool IsHAppyDay() => false;


        public bool ImHappy(string day) => true;
        public bool ImSad(string day) => true;

        [Test]
        public void Test1()
        {
            List<string> emptyList = new List<string>();

            emptyList.IsNullOrEmpty();

            DateTime time = DateTime.Now;

            var timestrring = DateTime.Now.Map(x => x.ToString());

            var today = "monday";

            var imHappy = today.Switch(_ => true)
                               .Case(IsHAppyDaySubj, ImHappy)
                               .Case(IsHAppyDay, ImHappy)
                               //.Case(day => day == "monday", ImHappy)
                               .Match();

            Action ciccio = () => today = "s";

            var xxx = ciccio.Try();

            var tr = "test".Try(sb => $"{sb}_done");
            var tr2 = tr.Catch((sb, ex) => $"{sb}_error_{ex.ToString()}");

            var mf1 = tr2.MatchFail("brutto");
            var mf2 = tr2.MatchFail(_ => "meno brutto");

            tr2.OnSuccess(_ => today = _);
            tr2.OnFail(_ => today = _);

            time.When();

            Dictionary<string, string> test = new();

            test.When().ContainsKey("test");

        }
    }
}
