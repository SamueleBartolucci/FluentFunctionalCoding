namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Chooses between the left string and the right string.
        /// Returns the left string if it is not null or empty and <paramref name="chooseRight"/> is false; otherwise, returns the right string.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <param name="leftString">The primary string value to use if not null or empty.</param>
        /// <param name="orRightString">The fallback string value to use if the left string is null, empty, or <paramref name="chooseRight"/> is true.</param>
        /// <param name="chooseRight">If true, always chooses the right string regardless of the left string's value.</param>
        /// <returns>The chosen string value.</returns>
        public static string OrWhenEmpty(this string leftString, string orRightString, bool chooseRight = false)
            => (string.IsNullOrEmpty(leftString) || chooseRight) ? orRightString : leftString;


        /// <summary>
        /// Chooses between the left string and the right string.
        /// Returns the left string if it is not null or empty and <paramref name="chooseRightWhen"/> returns false; otherwise, returns the right string.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <param name="leftString">The primary string value to use if not null or empty.</param>
        /// <param name="orRightString">The fallback string value to use if the left string is null, empty, or <paramref name="chooseRightWhen"/> returns true.</param>
        /// <param name="chooseRightWhen">A function that determines whether to choose the right string.</param>
        /// <returns>The chosen string value.</returns>
        public static string OrWhenEmpty(this string leftString, string orRightString, Func<bool> chooseRightWhen)
            => (string.IsNullOrEmpty(leftString) || chooseRightWhen()) ? orRightString : leftString;

        /// <summary>
        /// Chooses between the left string and the right string.
        /// Returns the left string if it is not null or empty and <paramref name="chooseRightWhen"/> returns false for the left string; otherwise, returns the right string.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <param name="leftString">The primary string value to use if not null or empty.</param>
        /// <param name="orRightString">The fallback string value to use if the left string is null, empty, or <paramref name="chooseRightWhen"/> returns true for the left string.</param>
        /// <param name="chooseRightWhen">A function that takes the left string and determines whether to choose the right string.</param>
        /// <returns>The chosen string value.</returns>
        public static string OrWhenEmpty(this string leftString, string orRightString, Func<string, bool> chooseRightWhen)
           => (string.IsNullOrEmpty(leftString) || chooseRightWhen(leftString)) ? orRightString : leftString;


        /// <summary>
        /// Chooses between the left string and the value produced by <paramref name="orRightString"/>.
        /// Returns the left string if it is not null or empty and <paramref name="chooseRight"/> is false; otherwise, returns the right string.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <param name="leftString">The primary string value to use if not null or empty.</param>
        /// <param name="orRightString">A function producing the fallback string value if needed.</param>
        /// <param name="chooseRight">If true, always chooses the right string regardless of the left string's value.</param>
        /// <returns>The chosen string value.</returns>
        public static string OrWhenEmpty(this string leftString, Func<string> orRightString, bool chooseRight = false)
            => (string.IsNullOrEmpty(leftString) || chooseRight) ? orRightString() : leftString;


        /// <summary>
        /// Chooses between the left string and the value produced by <paramref name="orRightString"/>.
        /// Returns the left string if it is not null or empty and <paramref name="chooseRightWhen"/> returns false; otherwise, returns the right string.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <param name="leftString">The primary string value to use if not null or empty.</param>
        /// <param name="orRightString">A function producing the fallback string value if needed.</param>
        /// <param name="chooseRightWhen">A function that determines whether to choose the right string.</param>
        /// <returns>The chosen string value.</returns>
        public static string OrWhenEmpty(this string leftString, Func<string> orRightString, Func<bool> chooseRightWhen)
            => (string.IsNullOrEmpty(leftString) || chooseRightWhen()) ? orRightString() : leftString;

        /// <summary>
        /// Chooses between the left string and the value produced by <paramref name="orRightString"/>.
        /// Returns the left string if it is not null or empty and <paramref name="chooseRightWhen"/> returns false for the left string; otherwise, returns the right string.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <param name="leftString">The primary string value to use if not null or empty.</param>
        /// <param name="orRightString">A function producing the fallback string value if needed.</param>
        /// <param name="chooseRightWhen">A function that takes the left string and determines whether to choose the right string.</param>
        /// <returns>The chosen string value.</returns>
        public static string OrWhenEmpty(this string leftString, Func<string> orRightString, Func<string, bool> chooseRightWhen)
           => (string.IsNullOrEmpty(leftString) || chooseRightWhen(leftString)) ? orRightString() : leftString;

    }
}
