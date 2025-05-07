namespace FluentFunctionalCoding
{
    public partial record When<T>
    {
        /// <summary>
        /// Executes the specified action if the condition is true.
        /// </summary>
        /// <param name="funcAsActionToCallOnSubject">The action to execute on the subject if the condition is true.</param>
        /// <returns>The current <see cref="When{T}"/> instance.</returns>
        public When<T> OnTrue(Action<T> funcAsActionToCallOnSubject)
        {
            if (IsTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        /// <summary>
        /// Executes the specified action if the condition is false.
        /// </summary>
        /// <param name="funcAsActionToCallOnSubject">The action to execute on the subject if the condition is false.</param>
        /// <returns>The current <see cref="When{T}"/> instance.</returns>
        public When<T> OnFalse(Action<T> funcAsActionToCallOnSubject)
        {
            if (IsFalse)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        /// <summary>
        /// Executes the specified function if the condition is true.
        /// </summary>
        /// <typeparam name="X">The return type of the function.</typeparam>
        /// <param name="funcAsActionToCallOnSubject">The function to execute on the subject if the condition is true.</param>
        /// <returns>The current <see cref="When{T}"/> instance.</returns>
        public When<T> OnTrue<X>(Func<T, X> funcAsActionToCallOnSubject)
        {
            if (IsTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        /// <summary>
        /// Executes the specified function if the condition is false.
        /// </summary>
        /// <typeparam name="X">The return type of the function.</typeparam>
        /// <param name="funcAsActionToCallOnSubject">The function to execute on the subject if the condition is false.</param>
        /// <returns>The current <see cref="When{T}"/> instance.</returns>
        public When<T> OnFalse<X>(Func<T, X> funcAsActionToCallOnSubject)
        {
            if (IsFalse)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }
    }
}
