using System.Diagnostics.Contracts;
using static FluentFunctionalCoding.FluentExtension;


namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides methods for mapping (transforming) Optional values.
    /// </summary>
    public static partial class WhenForTasks
    {
        /// <summary>
        /// Transforms the contained value if present (Some) using the provided function, disposing the value after mapping. Only available for IDisposable types.
        /// </summary>
        /// <typeparam name="O">The inner value when Some</typeparam>
        /// <typeparam name="B">The result type of the map function</typeparam>
        /// <param name="optional"></param>
        /// <param name="mapOnSome">>Function to apply if value is present.</param>
        /// <returns>An Optional of type B.</returns>
        [Pure]
        public static Optional<B> MapUsing<O, B>(this Optional<O> optional, Func<O, B> mapOnSome) where O :IDisposable =>
            optional switch
            {
                None<O> => Optional<B>.None(),
                Some<O>(var v) => Optional<B>.Some(v.MapUsing(mapOnSome)),
                _ => throw Optional<O>.UnknowOptionalType()
            };
    }
}
