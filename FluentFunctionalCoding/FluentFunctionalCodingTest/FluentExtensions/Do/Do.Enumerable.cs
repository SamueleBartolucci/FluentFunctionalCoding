using FluentAssertions;
using FluentFunctionalCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCodingTest.Do.Enumerable
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
        public void Do_Action_use_subject()
        {
            string logBuffer = "";
            void LogSomething(string message) { logBuffer += $"Message: {message}. "; }
            void AddToList(string value, List<string> storage) { storage.Add(value); }

            List<string> dummyList = new List<string>();

            new[] { "test1", "test2", "test3" }
            .DoForEach(LogSomething, v => AddToList(v, dummyList))
                .Should().BeEquivalentTo(new[] { "test1", "test2", "test3" });

            dummyList.Should().HaveCount(3);
            dummyList.Should().Contain("test1");
            dummyList.Should().Contain("test2");
            dummyList.Should().Contain("test3");
            logBuffer.Should().BeEquivalentTo("Message: test1. Message: test2. Message: test3. ");
        }


        [Test]
        public void Do_Func_use_subject()
        {
            Dictionary<string, string> dummyDict = new Dictionary<string, string>();

            bool IsAValidString(string s) => s.Length > 0;
            bool TryAddToDict(string v) 
            {
                if (!dummyDict.ContainsKey(v)) 
                {
                    dummyDict.Add(v, v); 
                    return true; 
                } 
                return false; 
            };


            new[] { "test1", "test2", "test3" }.DoForEach(IsAValidString, TryAddToDict)
                .Should().BeEquivalentTo(new[] { "test1", "test2", "test3" });

            dummyDict.Should().HaveCount(3);
            dummyDict.Should().ContainKey("test1");
            dummyDict.Should().ContainKey("test2");
            dummyDict.Should().ContainKey("test3");
        }


        [Test]
        public void Do_Action_update_subject()
        {

            var container = new [] { new ContainerTest("1", "2"), new ContainerTest("a", "b") };
            container.DoForEach(c => c.ThirdValue = "X");
            container.Should().AllSatisfy(c => c.ThirdValue.Should().Be("X"));

            new[] { new ContainerTest("1", "2"), new ContainerTest("a", "b") }
                .DoForEach(c => c.ThirdValue = "X")
                .Should().AllSatisfy(c => c.ThirdValue.Should().Be("X"));
        }


        [Test]
        public void Do_Func_update_subject()
        {
            ContainerTest AddFirst(ContainerTest c) { c.FirstValue = "first"; return c; }
            ContainerTest AddSecond(ContainerTest c) { c.SecondValue = "second"; return c; }
            ContainerTest AddThird(ContainerTest c) { c.ThirdValue = "third"; return c; }

            var container = new[] { new ContainerTest("1", "2"), new ContainerTest("a", "b") };
            container.DoForEach(AddFirst, AddSecond, AddThird);
            container.Should().AllSatisfy(c => c.FirstValue.Should().Be("first"));
            container.Should().AllSatisfy(c => c.SecondValue.Should().Be("second"));
            container.Should().AllSatisfy(c => c.ThirdValue.Should().Be("third"));

            new[] { new ContainerTest("1", "2"), new ContainerTest("a", "b") }
                .DoForEach(AddFirst, AddSecond, AddThird)
                .Should().AllSatisfy(c =>
                {
                    c.FirstValue.Should().Be("first");
                    c.SecondValue.Should().Be("second");
                    c.ThirdValue.Should().Be("third");
                });
        }
    }
}

