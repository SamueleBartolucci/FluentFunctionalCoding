namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not empty and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, IEnumerable<T> orRightValue, bool chooseRight = false)
            => (leftValue == null || !leftValue.Any() || chooseRight) ? orRightValue : leftValue;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not empty and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, IEnumerable<T> orRightValue, Func<bool> chooseRightWhen)
            => (leftValue == null || !leftValue.Any() || chooseRightWhen()) ? orRightValue : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not empty and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, IEnumerable<T> orRightValue, Func<IEnumerable<T>, bool> chooseRightWhen)
           => (leftValue == null || !leftValue.Any() || chooseRightWhen(leftValue)) ? orRightValue : leftValue;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not empty  and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, Func<IEnumerable<T>> orRightValue, bool chooseRight = false)
            => (leftValue == null || !leftValue.Any() || chooseRight) ? orRightValue() : leftValue;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not empty  and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, Func<IEnumerable<T>> orRightValue, Func<bool> chooseRightWhen)
            => (leftValue == null || !leftValue.Any() || chooseRightWhen()) ? orRightValue() : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not empty and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrWhenEmpty<T>(this IEnumerable<T> leftValue, Func<IEnumerable<T>> orRightValue, Func<IEnumerable<T>, bool> chooseRightWhen)
           => (leftValue == null || !leftValue.Any() || chooseRightWhen(leftValue)) ? orRightValue() : leftValue;

    }
}
