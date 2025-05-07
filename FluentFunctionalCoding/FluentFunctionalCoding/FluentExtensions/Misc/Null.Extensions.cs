namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="valueToNullCheck">The value to check for null.</param>
        /// <returns>True if the value is null; otherwise, false.</returns>
        public static bool IsNull<T>(this T valueToNullCheck) => valueToNullCheck == null;

        /// <summary>
        /// Determines whether the specified string is null or an empty string.
        /// </summary>
        /// <param name="valueToNullCheck">The string to check.</param>
        /// <returns>True if the string is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string valueToNullCheck) => string.IsNullOrEmpty(valueToNullCheck);

        /// <summary>
        /// Determines whether the specified enumerable is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the enumerable.</typeparam>
        /// <param name="valueToNullCheck">The enumerable to check.</param>
        /// <returns>True if the enumerable is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> valueToNullCheck) => valueToNullCheck == null || !valueToNullCheck.Any();
    }
}
