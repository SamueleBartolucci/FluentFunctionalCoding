using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest.Optional.Or
{
    internal class Optional
    {
        static string _testString = "test";
        static string _OrString = "or-value";

        public static string FuncOrString() => _OrString;        
        public static string FuncOrStringWithInput(string leftValue) => _OrString;


        [Test]
        public void Some_OrOptional_OptnValue_Bool()
        {
            var orFalse = _testString.ToOptional().Or(_OrString.ToOptional(), false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_testString);


            var orTrue = _testString.ToOptional().Or(_OrString.ToOptional(), true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void Some_OrOptional_OptnValue_FuncBool()
        {
            var orFalse = _testString.ToOptional().Or(_OrString.ToOptional(), () => false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_testString);


            var orTrue = _testString.ToOptional().Or(_OrString.ToOptional(), () => true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void Some_OrOptional_OptnValue_FuncVaueBool()
        {
            var orFalse = _testString.ToOptional().Or(_OrString.ToOptional(), optnValue => optnValue == "NO");
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_testString);


            var orTrue = _testString.ToOptional().Or(_OrString.ToOptional(), optnValue => optnValue == _testString);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void Some_OrOptional_FuncOptnValue_Bool()
        {
            var orFalse = _testString.ToOptional().Or(FuncOrString, false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_testString);


            var orTrue = _testString.ToOptional().Or(FuncOrString, true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void Some_OrOptional_FuncOptnValue_FuncBool()
        {
            var orFalse = _testString.ToOptional().Or(FuncOrString, () => false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_testString);


            var orTrue = _testString.ToOptional().Or(FuncOrString, () => true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void Some_OrOptional_FuncOptnValue_FuncVaueBool()
        {
            var orFalse = _testString.ToOptional().Or(FuncOrString, optnValue => optnValue == "NO");
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_testString);


            var orTrue = _testString.ToOptional().Or(FuncOrString, optnValue => optnValue == _testString);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        ///////////////////////
        
        [Test]
        public void None_OrOptional_OptnValue_Bool()
        {
            var orFalse = Optional<string>.None().Or(_OrString.ToOptional(), false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_OrString);


            var orTrue = Optional<string>.None().Or(_OrString.ToOptional(), true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void None_OrOptional_OptnValue_FuncBool()
        {
            var orFalse = Optional<string>.None().Or(_OrString.ToOptional(), () => false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_OrString);


            var orTrue = Optional<string>.None().Or(_OrString.ToOptional(), () => true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void None_OrOptional_OptnValue_FuncVaueBool()
        {
            var orFalse = Optional<string>.None().Or(_OrString.ToOptional(), optnValue => optnValue == "NO");
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_OrString);


            var orTrue = Optional<string>.None().Or(_OrString.ToOptional(), optnValue => optnValue == _testString);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void None_OrOptional_FuncOptnValue_Bool()
        {
            var orFalse = Optional<string>.None().Or(FuncOrString, false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_OrString);


            var orTrue = Optional<string>.None().Or(FuncOrString, true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void None_OrOptional_FuncOptnValue_FuncBool()
        {
            var orFalse = Optional<string>.None().Or(FuncOrString, () => false);
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_OrString);


            var orTrue = Optional<string>.None().Or(FuncOrString, () => true);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }

        [Test]
        public void None_OrOptional_FuncOptnValue_FuncVaueBool()
        {
            var orFalse = Optional<string>.None().Or(FuncOrString, optnValue => optnValue == "NO");
            orFalse.Should().BeOfType<OptionalJust<string>>();
            (orFalse as OptionalJust<string>)._value.Should().Be(_OrString);


            var orTrue = Optional<string>.None().Or(FuncOrString, optnValue => optnValue == _testString);
            orTrue.Should().BeOfType<OptionalJust<string>>();
            (orTrue as OptionalJust<string>)._value.Should().Be(_OrString);
        }
    }
}
