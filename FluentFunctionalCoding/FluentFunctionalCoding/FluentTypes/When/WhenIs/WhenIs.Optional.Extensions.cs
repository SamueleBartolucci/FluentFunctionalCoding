using System;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <see cref="WhenIs{Optional{T}}"/> to perform conditional checks on <see cref="Optional{T}"/> values.
    /// </summary>
    public static partial class WhenIsExtension
    {       
        /// <summary>
        /// Determines whether the subject <see cref="Optional{T}"/> value satisfies all provided predicates.
        /// </summary>
        /// <typeparam name="T">The type of the value contained in the <see cref="Optional{T}"/>.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{Optional{T}}"/> instance.</param>
        /// <param name="predicates">An array of predicates to test the value.</param>
        /// <returns>A <see cref="When{Optional{T}}"/> indicating if the value satisfies all predicates, or false if the value is <see cref="None{T}"/>.</returns>
        public static When<Optional<T>> Is<T>(this WhenIs<Optional<T>> whenIs, params Func<T, bool>[] predicates)
            => whenIs switch
            {
                WhenIs<None<T>> => whenIs._ToWhen(_ => false),
                WhenIs<Some<T>>(Some<T> (T value)) => whenIs._ToWhen(_ => predicates.All(p => p(value))),
                _ => throw new ArgumentException("Invalid type")
            };
    }
}
