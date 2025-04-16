namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and 'chooseRight' bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, T orRightValue, bool chooseRight = false)
            => (leftValue == null || chooseRight) ? orRightValue : leftValue;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, T orRightValue, Func<bool> chooseRightWhen)
            => (leftValue == null || chooseRightWhen()) ? orRightValue : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null        
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, T orRightValue, Func<T, bool> chooseRightWhen)
           => (leftValue == null || chooseRightWhen(leftValue)) ? orRightValue : leftValue;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRight bool is false
        /// Empty string is considered NOT null.
        /// The orRightValueFunc is evaluated only when right value must be returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValueFunc"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFunc, bool chooseRight = false)
            => (leftValue == null || chooseRight) ? orRightValueFunc() : leftValue;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// The orRightValueFunc is evaluated only when right value must be returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValueFunc"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFunc, Func<bool> chooseRightWhen)
            => (leftValue == null || chooseRightWhen()) ? orRightValueFunc() : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// The orRightValueFunc is evaluated only when right value must be returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValueFunc"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFunc, Func<T, bool> chooseRightWhen)
           => (leftValue == null || chooseRightWhen(leftValue)) ? orRightValueFunc() : leftValue;

    }
}
