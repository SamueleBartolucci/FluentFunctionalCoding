namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Applies one or more actions to the subject (if not null) and then returns the subject.
        /// Useful for performing side effects such as logging, debugging, or mutation in a fluent chain.
        /// </summary>
        /// <typeparam name="T">Type of the subject.</typeparam>
        /// <param name="subject">The object to apply actions to.</param>
        /// <param name="actionsToApplyOnSubject">Actions to apply to the subject.</param>
        /// <returns>The original subject after actions are applied, or default if subject is null.</returns>
        public static T Do<T>(this T subject, params Action<T>[] actionsToApplyOnSubject)
        {
            if (subject == null) return default!;

            foreach (var doOnSubject in actionsToApplyOnSubject)
                doOnSubject(subject);

            return subject;
        }



        /// <summary>
        /// Applies one or more functions to the subject (if not null) and then returns the subject.
        /// The function results are discarded. Useful for side effects in a fluent chain.
        /// </summary>
        /// <typeparam name="T">Type of the subject.</typeparam>
        /// <typeparam name="K">Return type of the functions (ignored).</typeparam>
        /// <param name="subject">The object to apply functions to.</param>
        /// <param name="functionsToApplyOnSubject">Functions to apply to the subject.</param>
        /// <returns>The original subject after functions are applied, or default if subject is null.</returns>
        public static T Do<T, K>(this T subject, params Func<T, K>[] functionsToApplyOnSubject)
        {
            if (subject == null) return default;

            foreach (var mapOnSubject in functionsToApplyOnSubject)
                mapOnSubject(subject);

            return subject;
        }
    }
}
