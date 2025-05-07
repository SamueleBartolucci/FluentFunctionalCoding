using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <see cref="WhenIs{IDictionary}"/> and <see cref="WhenIs{Dictionary}"/> to perform conditional checks on dictionaries.
    /// </summary>
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Determines whether the subject dictionary contains the specified key.
        /// </summary>
        /// <typeparam name="TK">The type of the dictionary key.</typeparam>
        /// <typeparam name="TV">The type of the dictionary value.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{IDictionary}"/> instance.</param>
        /// <param name="key">The key to locate in the dictionary.</param>
        /// <returns>A <see cref="When{IDictionary}"/> indicating if the dictionary contains the specified key.</returns>
        public static When<IDictionary<TK, TV>> ContainsKey<TK, TV>(this WhenIs<IDictionary<TK, TV>> whenIs, TK key) where TK : notnull
            => whenIs._ToWhen(sbj => sbj.ContainsKey(key));

        /// <summary>
        /// Determines whether the subject dictionary contains the specified key-value pair.
        /// </summary>
        /// <typeparam name="TK">The type of the dictionary key.</typeparam>
        /// <typeparam name="TV">The type of the dictionary value.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{IDictionary}"/> instance.</param>
        /// <param name="item">The key-value pair to locate in the dictionary.</param>
        /// <returns>A <see cref="When{IDictionary}"/> indicating if the dictionary contains the specified key-value pair.</returns>
        public static When<IDictionary<TK, TV>> ContainsValue<TK, TV>(this WhenIs<IDictionary<TK, TV>> whenIs, KeyValuePair<TK, TV> item) where TK : notnull
            => whenIs._ToWhen(sbj => sbj.Contains(item));

        /// <summary>
        /// Determines whether the subject dictionary contains the specified key.
        /// </summary>
        /// <typeparam name="TK">The type of the dictionary key.</typeparam>
        /// <typeparam name="TV">The type of the dictionary value.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{Dictionary}"/> instance.</param>
        /// <param name="key">The key to locate in the dictionary.</param>
        /// <returns>A <see cref="When{Dictionary}"/> indicating if the dictionary contains the specified key.</returns>
        public static When<Dictionary<TK, TV>> ContainsKey<TK, TV>(this WhenIs<Dictionary<TK, TV>> whenIs, TK key) where TK : notnull
               => whenIs._ToWhen(sbj => sbj.ContainsKey(key));

        /// <summary>
        /// Determines whether the subject dictionary contains the specified key-value pair.
        /// </summary>
        /// <typeparam name="TK">The type of the dictionary key.</typeparam>
        /// <typeparam name="TV">The type of the dictionary value.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{Dictionary}"/> instance.</param>
        /// <param name="item">The key-value pair to locate in the dictionary.</param>
        /// <returns>A <see cref="When{Dictionary}"/> indicating if the dictionary contains the specified key-value pair.</returns>
        public static When<Dictionary<TK, TV>> ContainsValue<TK, TV>(this WhenIs<Dictionary<TK, TV>> whenIs, KeyValuePair<TK, TV> item) where TK : notnull
            => whenIs._ToWhen(sbj => sbj.Contains(item));
    }

}
