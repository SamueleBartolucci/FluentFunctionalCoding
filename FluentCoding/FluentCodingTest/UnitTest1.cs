using FluentCoding;


namespace FluentCodingTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DateTime time = DateTime.Now;

            var timestrring = DateTime.Now.Map(x => x.ToString());

            var today = "monday";

            var imHappy = today.Switch(_ => true)
                               .Case(false, _ => false)
                               .Case(day => false, _ => true)
                               .Case(day => day == "monday", _ => false)
                               .Match();

            var asy = Task.FromResult(today)
                            .SwitchAsync(_ => true)                            
                            .Case(false, _ => false)
                            .Case(day => false, _ => true)
                            .Case(day => day == "monday", _ => false)
                            .Match();



        }
    }
}