using System;
using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        [Pure]
        public Optional<T> Bind<T>(Func<O, Optional<T>> bindOnSome)
            => this switch
            {
                OptionalNone<O> => Optional<T>.None(),
                OptionalJust<O> (var v) => bindOnSome(v),
                _ => throw UnknowImplementation()
            };

        [Pure]
        public Optional<O> BindNone(Func<Optional<O>> bindOnNone)
             => this switch
             {
                 OptionalNone<O> => bindOnNone(),
                 OptionalJust<O>(var v) => Some(v),
                 _ => throw UnknowImplementation()
             };       
    }
}
