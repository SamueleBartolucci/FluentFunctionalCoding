namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Asynchronously chooses between the awaited left value and the provided right value.
        /// Returns the left value if it is not null and <paramref name="chooseRight"/> is false; otherwise, returns the right value.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="leftValue">A Task producing the left value.</param>
        /// <param name="orRightValue">The right value to use if the left value is null or <paramref name="chooseRight"/> is true.</param>
        /// <param name="chooseRight">If true, the right value is chosen regardless of the left value.</param>
        /// <returns>A Task producing the chosen value.</returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, T orRightValue, bool chooseRight = false)
            => (await leftValue).Or(orRightValue, chooseRight);


        /// <summary>
        /// Asynchronously chooses between the awaited left value and the provided right value.
        /// Returns the left value if it is not null and <paramref name="chooseRightWhen"/> returns false; otherwise, returns the right value.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="leftValue">A Task producing the left value.</param>
        /// <param name="orRightValue">The right value to use if the left value is null or <paramref name="chooseRightWhen"/> returns true.</param>
        /// <param name="chooseRightWhen">A function that determines whether to choose the right value.</param>
        /// <returns>A Task producing the chosen value.</returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, T orRightValue, Func<bool> chooseRightWhen)
            => (await leftValue).Or(orRightValue, chooseRightWhen);

        /// <summary>
        /// Asynchronously chooses between the awaited left value and the provided right value.
        /// Returns the left value if it is not null and <paramref name="chooseRightWhen"/> returns false for the left value; otherwise, returns the right value.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="leftValue">A Task producing the left value.</param>
        /// <param name="orRightValue">The right value to use if the left value is null or <paramref name="chooseRightWhen"/> returns true for the left value.</param>
        /// <param name="chooseRightWhen">A function that takes the left value and determines whether to choose the right value.</param>
        /// <returns>A Task producing the chosen value.</returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, T orRightValue, Func<T, bool> chooseRightWhen)
           => (await leftValue).Or(orRightValue, chooseRightWhen);


        /// <summary>
        /// Asynchronously chooses between the awaited left value and the value produced by <paramref name="orRightValue"/>.
        /// Returns the left value if it is not null and <paramref name="chooseRight"/> is false; otherwise, returns the right value.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="leftValue">A Task producing the left value.</param>
        /// <param name="orRightValue">A function producing the right value if needed.</param>
        /// <param name="chooseRight">If true, the right value is chosen regardless of the left value.</param>
        /// <returns>A Task producing the chosen value.</returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, Func<T> orRightValue, bool chooseRight = false)
            => (await leftValue).Or(orRightValue, chooseRight);


        /// <summary>
        /// Asynchronously chooses between the awaited left value and the value produced by <paramref name="orRightValue"/>.
        /// Returns the left value if it is not null and <paramref name="chooseRightWhen"/> returns false; otherwise, returns the right value.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="leftValue">A Task producing the left value.</param>
        /// <param name="orRightValue">A function producing the right value if needed.</param>
        /// <param name="chooseRightWhen">A function that determines whether to choose the right value.</param>
        /// <returns>A Task producing the chosen value.</returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, Func<T> orRightValue, Func<bool> chooseRightWhen)
            => (await leftValue).Or(orRightValue, chooseRightWhen);

        /// <summary>
        /// Asynchronously chooses between the awaited left value and the value produced by <paramref name="orRightValue"/>.
        /// Returns the left value if it is not null and <paramref name="chooseRightWhen"/> returns false for the left value; otherwise, returns the right value.
        /// An empty string is considered NOT null.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="leftValue">A Task producing the left value.</param>
        /// <param name="orRightValue">A function producing the right value if needed.</param>
        /// <param name="chooseRightWhen">A function that takes the left value and determines whether to choose the right value.</param>
        /// <returns>A Task producing the chosen value.</returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, Func<T> orRightValue, Func<T, bool> chooseRightWhen)
           => (await leftValue).Or(orRightValue, chooseRightWhen);

    }
}
