using FluentAssertions;
using FluentCoding;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest.Optional.On
{
    internal class Optional
    {
        List<string> doCollector = new List<string>();
        public void OnNoneAction() => doCollector.Add($"NONE-ACT");
        public int OnNoneFunc()
        {
            doCollector.Add($"NONE-FUNC");
            return doCollector.Count;
        }
        public void OnAction(string s) => doCollector.Add($"{s}_{doCollector.Count}");
        public int OnFunc(string s)
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
        public void Some_OnSome_Func()
        {            
            var optionalString = "1433".ToOptional();
            var afterOnSome = optionalString.OnSome(OnFunc);
            afterOnSome.Should().BeOfType<OptionalJust<string>>();
            (afterOnSome as OptionalJust<string>)._value.Should().Be("1433");
            doCollector.Should().HaveCount(1);
            doCollector.Contains($"0_1433").Should().BeTrue();
        }

        [Test]
        public void Some_OnSome_Action()
        {
            var optionalString = "1433".ToOptional();
            var afterOnSome = optionalString.OnSome(OnAction);
            afterOnSome.Should().BeOfType<OptionalJust<string>>();
            (afterOnSome as OptionalJust<string>)._value.Should().Be("1433");
            doCollector.Should().HaveCount(1);
            doCollector.Contains($"1433_0").Should().BeTrue();
        }

        [Test]
        public void None_OnSome_Func()
        {
            var optionalString = Optional<string>.None();
            var afterOnSome = optionalString.OnSome(OnFunc);
            afterOnSome.Should().BeOfType<OptionalNone<string>>();            
            doCollector.Should().HaveCount(0);            
        }

        [Test]
        public void None_OnSome_Action()
        {
            var optionalString = Optional<string>.None();
            var afterOnSome = optionalString.OnSome(OnAction);
            afterOnSome.Should().BeOfType<OptionalNone<string>>();
            doCollector.Should().HaveCount(0);            
        }





        [Test]
        public void Some_OnNone_Func()
        {
            var optionalString = "1433".ToOptional();
            var afterOnNone = optionalString.OnNone(OnNoneFunc);
            afterOnNone.Should().BeOfType<OptionalJust<string>>();
            (afterOnNone as OptionalJust<string>)._value.Should().Be("1433");
            doCollector.Should().HaveCount(0);            
        }

        [Test]
        public void Some_OnNone_Action()
        {
            var optionalString = "1433".ToOptional();
            var afterOnNone = optionalString.OnNone(OnNoneAction);
            afterOnNone.Should().BeOfType<OptionalJust<string>>();
            (afterOnNone as OptionalJust<string>)._value.Should().Be("1433");
            doCollector.Should().HaveCount(0);
        }

        [Test]
        public void None_OnNone_Func()
        {
            var optionalString = Optional<string>.None();
            var afterOnSome = optionalString.OnNone(OnNoneFunc);
            afterOnSome.Should().BeOfType<OptionalNone<string>>();
            doCollector.Should().HaveCount(1);
            doCollector.Contains("NONE-FUNC").Should().BeTrue();    
        }

        [Test]
        public void None_OnNone_Action()
        {
            var optionalString = Optional<string>.None();
            var afterOnSome = optionalString.OnNone(OnNoneAction);
            afterOnSome.Should().BeOfType<OptionalNone<string>>();
            doCollector.Should().HaveCount(1);
            doCollector.Contains("NONE-ACT").Should().BeTrue();
        }

    }
}
