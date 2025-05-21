using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;
using NUnit.Framework;

namespace FluentCodingTest.Optional.Map
{
    internal class OptionalIDisposableMap
    {
        private class DisposableTest : System.IDisposable
        {
            public bool Disposed { get; private set; }
            public int Value { get; }
            public DisposableTest(int value) { Value = value; }
            public void Dispose() { Disposed = true; }
        }
        
        [Test]
        public void Some_MapUsing_DisposesAndMaps()
        {
            var disposable = new DisposableTest(42);
            var opt = disposable.ToOptional();
            var mapped = opt.MapUsing(d => d.Value + 1);
            mapped.Should().BeOfType<Some<int>>();
            ((Some<int>?)mapped)?._value.Should().Be(43);
            disposable.Disposed.Should().BeTrue();
        }

        [Test]
        public void None_MapUsing_DoesNotCallMapOrDispose()
        {
            var opt = Optional<DisposableTest>.None();
            var mapped = opt.MapUsing(d => d.Value + 1);
            mapped.Should().BeOfType<None<int>>();
        }
    }
}
