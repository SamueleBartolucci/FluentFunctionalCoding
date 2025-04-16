using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public abstract partial record Optional<O>// : Optional<O>
    {

        [Pure]
        public async Task<Optional<T>> BindAsync<T>(Func<O, Task<Optional<T>>> bindAsyncOnSome)
             => this switch
             {
                 None<O> => Optional<T>.None(),
                 Some<O>(var v) => await bindAsyncOnSome(v),
                 _ => throw UnknowOptionalType()
             };

        [Pure]
        public async Task<Optional<O>> BindNoneAsync(Func<Task<Optional<O>>> bindAsyncOnNone)
            => this switch
            {
                None<O> => await bindAsyncOnNone(),
                Some<O>(var v) => Some(v),
                _ => throw UnknowOptionalType()
            };
    }
}
