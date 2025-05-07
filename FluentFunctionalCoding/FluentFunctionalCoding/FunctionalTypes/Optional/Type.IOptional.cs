using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Defines the contract for an optional value, providing methods for binding, mapping, matching, and handling Some/None cases.
    /// </summary>
    /// <typeparam name="O">The type of the value contained by the optional.</typeparam>
    public interface IOptional<O>
    {
        // Bind methods
        /// <summary>
        /// Applies a function to the contained value if present (Some), returning a new Optional.
        /// </summary>
        /// <typeparam name="T">The result type of the bind function.</typeparam>
        /// <param name="bindOnSome">Function to apply if value is present.</param>
        /// <returns>An Optional of type T.</returns>
        [Pure]
        Optional<T> Bind<T>(Func<O, Optional<T>> bindOnSome);

        /// <summary>
        /// Applies a function if the Optional is None, returning a new Optional.
        /// </summary>
        /// <param name="bindOnNone">Function to apply if value is absent.</param>
        /// <returns>An Optional of the same type.</returns>
        [Pure]
        Optional<O> BindNone(Func<Optional<O>> bindOnNone);

        /// <summary>
        /// Asynchronously applies a function to the contained value if present (Some), returning a new Optional.
        /// </summary>
        /// <typeparam name="T">The result type of the bind function.</typeparam>
        /// <param name="bindAsyncOnSome">Async function to apply if value is present.</param>
        /// <returns>A Task of Optional of type T.</returns>
        [Pure]
        Task<Optional<T>> BindAsync<T>(Func<O, Task<Optional<T>>> bindAsyncOnSome);

        /// <summary>
        /// Asynchronously applies a function if the Optional is None, returning a new Optional.
        /// </summary>
        /// <param name="bindAsyncOnNone">Async function to apply if value is absent.</param>
        /// <returns>A Task of Optional of the same type.</returns>
        [Pure] 
        Task<Optional<O>> BindNoneAsync(Func<Task<Optional<O>>> bindAsyncOnNone);

        // OnSome methods
        /// <summary>
        /// Executes an action if the Optional is Some, then returns the Optional.
        /// </summary>
        /// <param name="action">Action to execute if value is present.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        Optional<O> OnSome(Action<O> action);

        /// <summary>
        /// Executes a function if the Optional is Some, discards the result, then returns the Optional.
        /// </summary>
        /// <typeparam name="T">The return type of the function (ignored).</typeparam>
        /// <param name="funcAsAction">Function to execute if value is present.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        Optional<O> OnSome<T>(Func<O, T> funcAsAction);

        // OnNone methods
        /// <summary>
        /// Executes an action if the Optional is None, then returns the Optional.
        /// </summary>
        /// <param name="action">Action to execute if value is absent.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        Optional<O> OnNone(Action action);

        /// <summary>
        /// Executes a function if the Optional is None, discards the result, then returns the Optional.
        /// </summary>
        /// <typeparam name="T">The return type of the function (ignored).</typeparam>
        /// <param name="funcAsAction">Function to execute if value is absent.</param>
        /// <returns>The original Optional.</returns>
        [Pure]
        Optional<O> OnNone<T>(Func<T> funcAsAction);

        // Do methods
        /// <summary>
        /// Applies a set of actions to the contained value if present (Some), then returns the Optional.
        /// </summary>
        /// <param name="actionsToApplyOnSubject">Actions to apply to the contained value.</param>
        /// <returns>The original Optional.</returns>
        Optional<O> Do(params Action<O>[] actionsToApplyOnSubject);

        /// <summary>
        /// Applies a set of functions to the contained value if present (Some), discards the results, then returns the Optional.
        /// </summary>
        /// <typeparam name="K">The return type of the functions (ignored).</typeparam>
        /// <param name="functionsToApplyOnSubject">Functions to apply to the contained value.</param>
        /// <returns>The original Optional.</returns>
        Optional<O> Do<K>(params Func<O, K>[] functionsToApplyOnSubject);

        // Or methods
        /// <summary>
        /// Returns the right Optional if the current Optional is None, or based on the provided condition; otherwise returns the current Optional.
        /// </summary>
        Optional<O> Or(Optional<O> orRightValue, bool chooseRight = false);
        Optional<O> Or(Optional<O> orRightValue, Func<bool> chooseRightWhen);
        Optional<O> Or(Optional<O> orRightValue, Func<O, bool> chooseRightWhen);
        Optional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false);
        Optional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen);
        Optional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen);

        // Map methods
        /// <summary>
        /// Transforms the contained value if present (Some) using the provided function, returning a new Optional.
        /// </summary>
        /// <typeparam name="B">The result type of the map function.</typeparam>
        /// <param name="mapOnSome">Function to apply if value is present.</param>
        /// <returns>An Optional of type B.</returns>
        [Pure]
        Optional<B> Map<B>(Func<O, B> mapOnSome);

        /// <summary>
        /// Transforms the Optional if it is None using the provided function, returning a new Optional.
        /// </summary>
        /// <param name="mapOnNone">Function to generate a value if Optional is None.</param>
        /// <returns>An Optional of the same type.</returns>
        [Pure]
        Optional<O> MapNone(Func<O> mapOnNone);

        // Match methods
        /// <summary>
        /// Returns the result of <paramref name="mapOnNone"/> if Optional is None; otherwise returns the contained value.
        /// </summary>
        /// <param name="mapOnNone">Function to generate a value if Optional is None.</param>
        /// <returns>The contained value or the result of mapOnNone.</returns>
        [Pure]
        O MatchNone(Func<O> mapOnNone);

        /// <summary>
        /// Returns <paramref name="valueWhenNone"/> if Optional is None; otherwise returns the contained value.
        /// </summary>
        /// <param name="valueWhenNone">Value to return if Optional is None.</param>
        /// <returns>The contained value or valueWhenNone.</returns>
        [Pure]
        O MatchNone(O valueWhenNone);

        /// <summary>
        /// Matches on Some/None, returning the result of the appropriate function.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="mapOnSome">Function to apply if value is present.</param>
        /// <param name="mapOnNone">Function to apply if value is absent.</param>
        /// <returns>The result of the appropriate function.</returns>
        [Pure]
        T Match<T>(Func<O, T> mapOnSome, Func<T> mapOnNone);

        /// <summary>
        /// Matches on Some/None, returning the result of the appropriate function or value.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="mapOnSome">Function to apply if value is present.</param>
        /// <param name="valueOnNone">Value to return if value is absent.</param>
        /// <returns>The result of the function or value.</returns>
        [Pure]
        T Match<T>(Func<O, T> mapOnSome, T valueOnNone);

        // ToOutcome methods
        /// <summary>
        /// Converts the Optional to an Outcome, using the provided function to generate the failure value if None.
        /// </summary>
        /// <typeparam name="F">The failure type.</typeparam>
        /// <param name="onNone">Function to generate the failure value.</param>
        /// <returns>An Outcome representing success or failure.</returns>
        [Pure]
        Outcome<F, O> ToOutcome<F>(Func<F> onNone);

        /// <summary>
        /// Converts the Optional to an Outcome, using the provided value as the failure value if None.
        /// </summary>
        /// <typeparam name="F">The failure type.</typeparam>
        /// <param name="valueOnNone">The failure value to use if None.</param>
        /// <returns>An Outcome representing success or failure.</returns>
        [Pure]
        Outcome<F, O> ToOutcome<F>(F valueOnNone);

        /// <summary>
        /// Gets a value indicating whether the Optional contains a value (is Some).
        /// </summary>
        bool IsSome { get; }

        /// <summary>
        /// Gets a value indicating whether the Optional is None (does not contain a value).
        /// </summary>
        bool IsNone { get; }
    }
}
