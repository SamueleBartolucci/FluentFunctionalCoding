namespace FluentCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <param name="leftString"></param>
        /// <param name="orRightString"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static string OrWhenEmpty(this string leftString, string orRightString, bool chooseRight = false)
            => (string.IsNullOrEmpty(leftString) || chooseRight) ? orRightString : leftString;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <param name="leftString"></param>
        /// <param name="orRightString"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrWhenEmpty(this string leftString, string orRightString, Func<bool> chooseRightWhen)
            => (string.IsNullOrEmpty(leftString) || chooseRightWhen()) ? orRightString : leftString;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftString) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <param name="leftString"></param>
        /// <param name="orRightString"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrWhenEmpty(this string leftString, string orRightString, Func<string, bool> chooseRightWhen)
           => (string.IsNullOrEmpty(leftString) || chooseRightWhen(leftString)) ? orRightString : leftString;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <param name="leftString"></param>
        /// <param name="orRightString"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static string OrWhenEmpty(this string leftString, Func<string> orRightString, bool chooseRight = false)
            => (string.IsNullOrEmpty(leftString) || chooseRight) ? orRightString() : leftString;


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <param name="leftString"></param>
        /// <param name="orRightString"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrWhenEmpty(this string leftString, Func<string> orRightString, Func<bool> chooseRightWhen)
            => (string.IsNullOrEmpty(leftString) || chooseRightWhen()) ? orRightString() : leftString;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftString) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <param name="leftString"></param>
        /// <param name="orRightString"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrWhenEmpty(this string leftString, Func<string> orRightString, Func<string, bool> chooseRightWhen)
           => (string.IsNullOrEmpty(leftString) || chooseRightWhen(leftString)) ? orRightString() : leftString;

    }
}
