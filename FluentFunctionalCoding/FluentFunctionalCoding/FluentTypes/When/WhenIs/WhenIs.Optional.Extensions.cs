using System;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {       

        public static When<Optional<T>> Is<T>(this WhenIs<Optional<T>> whenIs, params Func<T, bool>[] predicates)
            => whenIs switch
            {
                WhenIs<None<T>> => whenIs._ToWhen(_ => false),
                WhenIs<Some<T>>(Some<T> (T value)) => whenIs._ToWhen(_ => predicates.All(p => p(value))),
                _ => throw new ArgumentException("Invalid type")
            };
    }
}
