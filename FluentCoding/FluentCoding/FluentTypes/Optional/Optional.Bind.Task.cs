using System;
using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        
        [Pure]
        public async Task<Optional<T>> BindAsync<T>(Func<O, Task<Optional<T>>> bindAsyncOnSome)
             => this switch
             {
                 OptionalNone<O> => Optional<T>.None(),
                 OptionalJust<O>(var v) => await bindAsyncOnSome(v),
                 _ => throw UnknowImplementation()
             };

        [Pure]
        public async Task<Optional<O>> BindNoneAsync(Func<Task<Optional<O>>> bindAsyncOnNone)
            => this switch
            {
                OptionalNone<O> => await bindAsyncOnNone(),
                OptionalJust<O>(var v) => Some(v),
                _ => throw UnknowImplementation()
            };
    }
}
