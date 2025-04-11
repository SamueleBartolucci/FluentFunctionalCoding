using System;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {       

        public static IWhen<IOptional<T>> Is<T>(this IWhenIs<IOptional<T>> whenIs, params Func<T, bool>[] predicates)
            => whenIs switch
            {
                WhenIs<None<T>> => whenIs.ToWhen(_ => false),
                WhenIs<Some<T>>(Some<T> (T value)) => whenIs.ToWhen(_ => predicates.All(p => p(value))),
                _ => throw new ArgumentException("Invalid type")
            };
    }
}
