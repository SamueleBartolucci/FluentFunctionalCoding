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
            DateTime time = DateTime.Now;

            var timestrring = DateTime.Now.Map(x => x.ToString());

            var today = "monday";

            var imHappy = today.Switch(_ => true)
                               .Case(IsHAppyDaySubj, ImHappy)
                               .Case(IsHAppyDay, ImHappy)
                               //.Case(day => day == "monday", ImHappy)
                               .Match();




        }
    }
}
