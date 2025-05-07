namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Returns <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null or <paramref name="chooseRight"/> is true; otherwise returns <paramref name="leftValue"/>.
        /// Empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">Type of the values to choose from.</typeparam>
        /// <param name="leftValue">Primary value to check.</param>
        /// <param name="orRightValue">Fallback value if primary is null or <paramref name="chooseRight"/> is true.</param>
        /// <param name="chooseRight">If true, always returns <paramref name="orRightValue"/>.</param>
        /// <returns>The chosen value based on the conditions.</returns>
        public static T Or<T>(this T leftValue, T orRightValue, bool chooseRight = false)
            => (leftValue == null || chooseRight) ? orRightValue : leftValue;

        /// <summary>
        /// Returns <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null or <paramref name="chooseRightWhen"/> returns true; otherwise returns <paramref name="leftValue"/>.
        /// Empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">Type of the values to choose from.</typeparam>
        /// <param name="leftValue">Primary value to check.</param>
        /// <param name="orRightValue">Fallback value if primary is null or <paramref name="chooseRightWhen"/> returns true.</param>
        /// <param name="chooseRightWhen">A function that determines if the right value should be chosen.</param>
        /// <returns>The chosen value based on the conditions.</returns>
        public static T Or<T>(this T leftValue, T orRightValue, Func<bool> chooseRightWhen)
            => (leftValue == null || chooseRightWhen()) ? orRightValue : leftValue;

        /// <summary>
        /// Returns <paramref name="orRightValue"/> if <paramref name="leftValue"/> is null or <paramref name="chooseRightWhen"/> returns true for <paramref name="leftValue"/>; otherwise returns <paramref name="leftValue"/>.
        /// Empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">Type of the values to choose from.</typeparam>
        /// <param name="leftValue">Primary value to check.</param>
        /// <param name="orRightValue">Fallback value if primary is null or <paramref name="chooseRightWhen"/> returns true.</param>
        /// <param name="chooseRightWhen">A function that takes the primary value and determines if the right value should be chosen.</param>
        /// <returns>The chosen value based on the conditions.</returns>
        public static T Or<T>(this T leftValue, T orRightValue, Func<T, bool> chooseRightWhen)
           => (leftValue == null || chooseRightWhen(leftValue)) ? orRightValue : leftValue;

        /// <summary>
        /// Returns the result of <paramref name="orRightValueFunc"/> if <paramref name="leftValue"/> is null or <paramref name="chooseRight"/> is true; otherwise returns <paramref name="leftValue"/>.
        /// Empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">Type of the values to choose from.</typeparam>
        /// <param name="leftValue">Primary value to check.</param>
        /// <param name="orRightValueFunc">A function that provides the fallback value.</param>
        /// <param name="chooseRight">If true, always returns the result of <paramref name="orRightValueFunc"/>.</param>
        /// <returns>The chosen value based on the conditions.</returns>
        /// <remarks>The <paramref name="orRightValueFunc"/> function is only evaluated if needed.</remarks>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFunc, bool chooseRight = false)
            => (leftValue == null || chooseRight) ? orRightValueFunc() : leftValue;

        /// <summary>
        /// Returns the result of <paramref name="orRightValueFunc"/> if <paramref name="leftValue"/> is null or <paramref name="chooseRightWhen"/> returns true; otherwise returns <paramref name="leftValue"/>.
        /// Empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">Type of the values to choose from.</typeparam>
        /// <param name="leftValue">Primary value to check.</param>
        /// <param name="orRightValueFunc">A function that provides the fallback value.</param>
        /// <param name="chooseRightWhen">A function that determines if the right value should be chosen.</param>
        /// <returns>The chosen value based on the conditions.</returns>
        /// <remarks>The <paramref name="orRightValueFunc"/> function is only evaluated if needed.</remarks>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFunc, Func<bool> chooseRightWhen)
            => (leftValue == null || chooseRightWhen()) ? orRightValueFunc() : leftValue;

        /// <summary>
        /// Returns the result of <paramref name="orRightValueFunc"/> if <paramref name="leftValue"/> is null or <paramref name="chooseRightWhen"/> returns true for <paramref name="leftValue"/>; otherwise returns <paramref name="leftValue"/>.
        /// Empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">Type of the values to choose from.</typeparam>
        /// <param name="leftValue">Primary value to check.</param>
        /// <param name="orRightValueFunc">A function that provides the fallback value.</param>
        /// <param name="chooseRightWhen">A function that takes the primary value and determines if the right value should be chosen.</param>
        /// <returns>The chosen value based on the conditions.</returns>
        /// <remarks>The <paramref name="orRightValueFunc"/> function is only evaluated if needed.</remarks>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFunc, Func<T, bool> chooseRightWhen)
           => (leftValue == null || chooseRightWhen(leftValue)) ? orRightValueFunc() : leftValue;

    }
}
