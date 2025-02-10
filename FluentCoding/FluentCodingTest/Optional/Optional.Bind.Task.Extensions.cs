using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FluentCodingTest.Optional.BindTaskExtensions
{
    internal class Optional
    {
        public Optional<int> FuncWithOptionalResult(string s) => int.TryParse(s, out var result)
                                                                    .When()
                                                                    .IsTrue()
                                                                    .Match(@true => result.ToOptional(), @false => Optional<int>.None());

        public Task<Optional<int>> FuncWithTaskOptionalResult(string s) => int.TryParse(s, out var result)
                                                                    .When()
                                                                    .IsTrue()
                                                                    .Match(@true => result.ToOptional(), @false => Optional<int>.None())
                                                                    .ToTask();

        public Optional<string> FuncOptionalOnNone() => "none".ToOptional();        
        public Task<Optional<string>> FuncTaskOptionalOnNone() => "none".ToOptional().ToTask();

        [Test]
        public void TaskSome_Bind_Optional()
        {

            var result = "1".ToOptional().ToTask().BindAsync(FuncWithOptionalResult);            
            result.Should().BeOfType<Task<Optional<int>>>();
            result.Result.Should().BeOfType<OptionalJust<int>>();
            (result.Result as OptionalJust<int>)._value.Should().Be(1);
        }

        [Test]
        public void TaskSome_BindNone_Optional()
        {

            var result = "1".ToOptional().ToTask().BindNoneAsync(FuncTaskOptionalOnNone);
            result.Should().BeOfType<Task<Optional<string>>>();
            result.Result.Should().BeOfType<OptionalJust<string>>();
        }


        [Test]
        public void TaskNone_Bind_Optional()
        {
            var result = Optional<string>.None().ToTask().BindAsync(FuncWithOptionalResult);
            result.Should().BeOfType<Task<Optional<int>>>();
            result.Result.Should().BeOfType<OptionalNone<int>>();
        }


        [Test]
        public void TaskNone_BindNone_Optional()
        {
            var result = Optional<string>.None().ToTask().BindNoneAsync(FuncTaskOptionalOnNone);
            result.Should().BeOfType<Task<Optional<string>>>();
            result.Result.Should().BeOfType<OptionalJust<string>>();
            (result.Result as OptionalJust<string>)._value.Should().Be("none");
        }
    }
}
