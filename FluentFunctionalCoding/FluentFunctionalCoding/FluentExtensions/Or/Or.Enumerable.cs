namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Returns <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null, empty, or <paramref name="chooseRight"/> is true; otherwise returns <paramref name="leftValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="leftValue">The primary sequence to check.</param>
        /// <param name="orRightValue">The fallback sequence to return if the primary is null or empty.</param>
        /// <param name="chooseRight">If true, always returns <paramref name="orRightValue"/>.</param>
        /// <returns>The chosen sequence based on the conditions.</returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, IEnumerable<T> orRightValue, bool chooseRight = false)
            => (leftValue == null || !leftValue.Any() || chooseRight) ? orRightValue : leftValue;

        /// <summary>
        /// Returns <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null, empty, or <paramref name="chooseRightWhen"/> returns true; otherwise returns <paramref name="leftValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="leftValue">The primary sequence to check.</param>
        /// <param name="orRightValue">The fallback sequence to return if the primary is null or empty.</param>
        /// <param name="chooseRightWhen">A function that determines if the right value should be chosen.</param>
        /// <returns>The chosen sequence based on the conditions.</returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, IEnumerable<T> orRightValue, Func<bool> chooseRightWhen)
            => (leftValue == null || !leftValue.Any() || chooseRightWhen()) ? orRightValue : leftValue;

        /// <summary>
        /// Returns <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null, empty, or <paramref name="chooseRightWhen"/> returns true for <paramref name="leftValue"/>; otherwise returns <paramref name="leftValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="leftValue">The primary sequence to check.</param>
        /// <param name="orRightValue">The fallback sequence to return if the primary is null or empty.</param>
        /// <param name="chooseRightWhen">A function that takes the primary sequence and determines if the right value should be chosen.</param>
        /// <returns>The chosen sequence based on the conditions.</returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, IEnumerable<T> orRightValue, Func<IEnumerable<T>, bool> chooseRightWhen)
           => (leftValue == null || !leftValue.Any() || chooseRightWhen(leftValue)) ? orRightValue : leftValue;

        /// <summary>
        /// Returns the result of <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null, empty, or <paramref name="chooseRight"/> is true; otherwise returns <paramref name="leftValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="leftValue">The primary sequence to check.</param>
        /// <param name="orRightValue">A function that provides the fallback sequence.</param>
        /// <param name="chooseRight">If true, always returns the result of <paramref name="orRightValue"/>.</param>
        /// <returns>The chosen sequence based on the conditions.</returns>
        /// <remarks>The <paramref name="orRightValue"/> function is only evaluated if needed.</remarks>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, Func<IEnumerable<T>> orRightValue, bool chooseRight = false)
            => (leftValue == null || !leftValue.Any() || chooseRight) ? orRightValue() : leftValue;

        /// <summary>
        /// Returns the result of <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null, empty, or <paramref name="chooseRightWhen"/> returns true; otherwise returns <paramref name="leftValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="leftValue">The primary sequence to check.</param>
        /// <param name="orRightValue">A function that provides the fallback sequence.</param>
        /// <param name="chooseRightWhen">A function that determines if the right value should be chosen.</param>
        /// <returns>The chosen sequence based on the conditions.</returns>
        /// <remarks>The <paramref name="orRightValue"/> function is only evaluated if needed.</remarks>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, Func<IEnumerable<T>> orRightValue, Func<bool> chooseRightWhen)
            => (leftValue == null || !leftValue.Any() || chooseRightWhen()) ? orRightValue() : leftValue;

        /// <summary>
        /// Returns the result of <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null, empty, or <paramref name="chooseRightWhen"/> returns true for <paramref name="leftValue"/>; otherwise returns <paramref name="leftValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="leftValue">The primary sequence to check.</param>
        /// <param name="orRightValue">A function that provides the fallback sequence.</param>
        /// <param name="chooseRightWhen">A function that takes the primary sequence and determines if the right value should be chosen.</param>
        /// <returns>The chosen sequence based on the conditions.</returns>
        /// <remarks>The <paramref name="orRightValue"/> function is only evaluated if needed.</remarks>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, Func<IEnumerable<T>> orRightValue, Func<IEnumerable<T>, bool> chooseRightWhen)
           => (leftValue == null || !leftValue.Any() || chooseRightWhen(leftValue)) ? orRightValue() : leftValue;

    }
}
