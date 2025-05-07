using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides methods for executing actions on Some/None cases for Optional values.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Apply an action on the Subject when IsSome. Then return the Optional.
        /// </summary>
        /// <param name="action">Action to execute if value is present.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        public Optional<O> OnSome(Action<O> action)
        {
            if (this is Some<O>(var v))
                action(v);
            return this;
        }

        /// <summary>
        /// Apply an action on the Subject when IsSome. Then return the Optional and discard the func output.
        /// </summary>
        /// <typeparam name="T">The return type of the function (ignored).</typeparam>
        /// <param name="funcAsAction">Function to execute if value is present.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        public Optional<O> OnSome<T>(Func<O, T> funcAsAction)
        {
            if (this is Some<O>(var v))
                funcAsAction(v);
            return this;
        }

        /// <summary>
        /// Apply a generic action when the subject IsNone. Then return the Optional.
        /// </summary>
        /// <param name="action">Action to execute if value is absent.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        public Optional<O> OnNone(Action action)
        {
            if (this is None<O>)
                action();
            return this;
        }

        /// <summary>
        /// Apply a generic action when the subject IsNone. Then return the Optional and discard the func output.
        /// </summary>
        /// <typeparam name="T">The return type of the function (ignored).</typeparam>
        /// <param name="funcAsAction">Function to execute if value is absent.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        public Optional<O> OnNone<T>(Func<T> funcAsAction)
        {
            if (this is None<O>)
                funcAsAction();
            return this;
        }
    }
}
