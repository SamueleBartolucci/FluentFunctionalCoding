using FluentAssertions;
using FluentFunctionalCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.Do
{



    internal class Do
    {


        internal record ContainerTest
        {
            public string FirstValue { get; set; }
            public string SecondValue { get; set; }
            public string ThirdValue { get; set;}

            public ContainerTest(string first, string second) => (FirstValue, SecondValue) = (first, second);            
        }


        [Test]
        public void Do_Action_null_subject()
        {
            string test = null;
            bool statusChanged = false;

            test.Do(t => statusChanged = true)
                .Should().BeNull();

            statusChanged.Should().BeFalse();
        }


        [Test]
        public void Do_Func_null_subject()
        {
            string test = null;
            bool statusChanged = false;

            test.Do(t => { statusChanged = true; return statusChanged; })
                .Should().BeNull();

            statusChanged.Should().BeFalse();
        }

        [Test]
        public void Do_Action_use_subject()
        {
            string logBuffer = "";
            void LogSomething(string message) { logBuffer += $"Message: {message}"; }
            void AddToList(string value, List<string> storage) { storage.Add(value); }

            List<string> dummyList = new List<string>() { "base" };

            "test".Do(LogSomething, v => AddToList(v, dummyList))
                .Should().BeEquivalentTo("test");

            dummyList.Should().HaveCount(2);
            dummyList.Should().Contain("test");
            logBuffer.Should().BeEquivalentTo("Message: test");
        }


        [Test]
        public void Do_Func_use_subject()
        {
            Dictionary<string, string> dummyDict = new Dictionary<string, string>();

            bool IsAValidString(string s) => s.Length > 0;
            bool TryAddToDict(string v) { dummyDict.Add(v, v); return dummyDict.ContainsKey(v); };

            "test".Do(IsAValidString, TryAddToDict)
                .Should().BeEquivalentTo("test");

            dummyDict.Should().HaveCount(1);
            dummyDict.Should().ContainKey("test");
        }


        [Test]
        public void Do_Action_update_subject()
        {

            var container = new ContainerTest("1", "2");
            container.Do(c => c.ThirdValue = "3");
            container.ThirdValue.Should().Be("3");

            new ContainerTest("1", "2")
                .Do(c => c.ThirdValue = "4")
                .ThirdValue.Should().Be("4");
        }


        [Test]
        public void Do_Func_update_subject()
        {
            ContainerTest AddFirst(ContainerTest c) { c.FirstValue = "first"; return c; }
            ContainerTest AddSecond(ContainerTest c) { c.SecondValue = "second"; return c; }
            ContainerTest AddThird(ContainerTest c) { c.ThirdValue = "third"; return c; }

            var container = new ContainerTest("1", "2");
            container.Do(AddFirst, AddSecond, AddThird);
            container.FirstValue.Should().Be("first");
            container.SecondValue.Should().Be("second");
            container.ThirdValue.Should().Be("third");

            new ContainerTest("1", "2")
                .Do(AddFirst, AddSecond, AddThird)
                .Do(c =>
                {
                    c.FirstValue.Should().Be("first");
                    c.SecondValue.Should().Be("second");
                    c.ThirdValue.Should().Be("third");
                });

            new ContainerTest("1", "2")
                .Do(AddFirst, AddSecond, AddThird)
                .Do(c => c.FirstValue.Should().Be("first"),
                    c => c.SecondValue.Should().Be("second"),
                    c => c.ThirdValue.Should().Be("third"));
        }
    }
}
