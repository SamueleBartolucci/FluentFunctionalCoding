namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for handling <see cref="When{T}"/> with <see cref="Optional{T}"/> subjects.
    /// </summary>
    public static partial class WhenExtension
    {
        /// <summary>
        /// Executes the specified action if the <see cref="When{T}"/> is true and the subject is present.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">The <see cref="When{Optional{T}}"/> instance.</param>
        /// <param name="actionToCallOnSomeSubject">The action to execute on the subject if present.</param>
        /// <returns>The original <see cref="When{Optional{T}}"/> instance.</returns>
        public static When<Optional<T>> OnTrue<T>(this When<Optional<T>> when, Action<T> actionToCallOnSomeSubject)
        {  
            if (when.IsTrue)
                when._subject.OnSome(actionToCallOnSomeSubject);

            return when;
        }

        /// <summary>
        /// Executes the specified action if the <see cref="When{T}"/> is false and the subject is present.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">The <see cref="When{Optional{T}}"/> instance.</param>
        /// <param name="actionToCallOnSomeSubject">The action to execute on the subject if present.</param>
        /// <returns>The original <see cref="When{Optional{T}}"/> instance.</returns>
        public static When<Optional<T>> OnFalse<T>(this When<Optional<T>> when, Action<T> actionToCallOnSomeSubject)
        {
            if (!when.IsTrue)
                when._subject.OnSome(actionToCallOnSomeSubject);

            return when;
        }

        /// <summary>
        /// Executes the specified function if the <see cref="When{T}"/> is true and the subject is present.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="X">The return type of the function.</typeparam>
        /// <param name="when">The <see cref="When{Optional{T}}"/> instance.</param>
        /// <param name="funcAsActionToCallOnSomeSubject">The function to execute on the subject if present.</param>
        /// <returns>The original <see cref="When{Optional{T}}"/> instance.</returns>
        public static When<Optional<T>> OnTrue<T, X>(this When<Optional<T>> when, Func<T, X> funcAsActionToCallOnSomeSubject)
        {
            if (when.IsTrue)
                when._subject.OnSome(funcAsActionToCallOnSomeSubject);

            return when;
        }

        /// <summary>
        /// Executes the specified function if the <see cref="When{T}"/> is false and the subject is present.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="X">The return type of the function.</typeparam>
        /// <param name="when">The <see cref="When{Optional{T}}"/> instance.</param>
        /// <param name="funcAsActionToCallOnSomeSubject">The function to execute on the subject if present.</param>
        /// <returns>The original <see cref="When{Optional{T}}"/> instance.</returns>
        public static When<Optional<T>> OnFalse<T, X>(this When<Optional<T>> when, Func<T, X> funcAsActionToCallOnSomeSubject)
        {
            if (!when.IsTrue)
                when._subject.OnSome(funcAsActionToCallOnSomeSubject);

            return when;
        }
    }
}
