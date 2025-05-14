namespace FluentFunctionalCoding
{
    /// <summary>
    /// Interface for an outcome that can be either a success or a failure.
    /// </summary>
    /// <typeparam name="F">The type of the failure value.</typeparam>
    /// <typeparam name="S">The type of the success value.</typeparam>
    public interface IOutcome<F, S>
    {
        /// <summary>
        /// Gets a value indicating whether this outcome is a success.
        /// </summary>
        bool IsSuccess { get; }
        /// <summary>
        /// Gets a value indicating whether this outcome is a failure.
        /// </summary>
        bool IsFailure { get; }

        // On methods
        /// <summary>
        /// Executes the provided functions depending on whether the outcome is success or failure. Returns the original outcome for fluent chaining.
        /// </summary>
        /// <typeparam name="X">The return type of the success function (ignored).</typeparam>
        /// <typeparam name="Y">The return type of the failure function (ignored).</typeparam>
        /// <param name="doOnSuccess">Function to execute if the outcome is a success.</param>
        /// <param name="doOnFailure">Function to execute if the outcome is a failure.</param>
        Outcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure);
        /// <summary>
        /// Executes the provided function if the outcome is a success. Returns the original outcome for fluent chaining.
        /// </summary>
        /// <typeparam name="X">The return type of the function (ignored).</typeparam>
        /// <param name="funcAsDoOnSuccess">Function to execute if the outcome is a success.</param>
        Outcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess);
        /// <summary>
        /// Executes the provided function if the outcome is a failure. Returns the original outcome for fluent chaining.
        /// </summary>
        /// <typeparam name="Y">The return type of the function (ignored).</typeparam>
        /// <param name="funcAsDoOnFailure">Function to execute if the outcome is a failure.</param>
        Outcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure);
        /// <summary>
        /// Executes the provided actions depending on whether the outcome is success or failure. Returns the original outcome for fluent chaining.
        /// </summary>
        /// <param name="doOnSuccess">Action to execute if the outcome is a success.</param>
        /// <param name="doOnFailure">Action to execute if the outcome is a failure.</param>
        Outcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure);
        /// <summary>
        /// Executes the provided action if the outcome is a success. Returns the original outcome for fluent chaining.
        /// </summary>
        /// <param name="doOnSuccess">Action to execute if the outcome is a success.</param>
        Outcome<F, S> OnSuccess(Action<S> doOnSuccess);
        /// <summary>
        /// Executes the provided action if the outcome is a failure. Returns the original outcome for fluent chaining.
        /// </summary>
        /// <param name="doOnFailure">Action to execute if the outcome is a failure.</param>
        Outcome<F, S> OnFailure(Action<F> doOnFailure);

        // Match methods
        /// <summary>
        /// Matches the outcome and executes the corresponding function.
        /// </summary>
        /// <typeparam name="M">The return type of the match function.</typeparam>
        /// <param name="onSuccess">Function to execute if the outcome is a success.</param>
        /// <param name="onFailure">Function to execute if the outcome is a failure.</param>
        M Match<M>(Func<S, M> onSuccess, Func<F, M> onFailure);
        /// <summary>
        /// Matches the outcome and executes the success function or returns a value on failure.
        /// </summary>
        /// <typeparam name="M">The return type of the match function.</typeparam>
        /// <param name="onSuccess">Function to execute if the outcome is a success.</param>
        /// <param name="valueOnFailure">Value to return if the outcome is a failure.</param>
        M Match<M>(Func<S, M> onSuccess, M valueOnFailure);

        // Bind methods
        /// <summary>
        /// Binds the outcome to a new outcome if it is a success.
        /// </summary>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="bindOnSuccess">Function to bind the success value to a new outcome.</param>
        Outcome<F, S1> Bind<S1>(Func<S, Outcome<F, S1>> bindOnSuccess);
        /// <summary>
        /// Binds the outcome to a new outcome if it is a failure.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <param name="bindOnFailure">Function to bind the failure value to a new outcome.</param>
        Outcome<F1, S> BindFailure<F1>(Func<F, Outcome<F1, S>> bindOnFailure);
        /// <summary>
        /// Binds the outcome to new outcomes for both success and failure cases.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="bindOnSuccess">Function to bind the success value to a new outcome.</param>
        /// <param name="bindOnFailure">Function to bind the failure value to a new outcome.</param>
        Outcome<F1, S1> BindFull<F1, S1>(Func<S, Outcome<F1, S1>> bindOnSuccess, Func<F, Outcome<F1, S1>> bindOnFailure);

        // Do methods
        /// <summary>
        /// Executes actions on the success value if present.
        /// </summary>
        /// <param name="actionsToApplyOnSuccessSubject">Actions to execute on the success value.</param>
        Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccessSubject);
        /// <summary>
        /// Executes functions on the success value if present.
        /// </summary>
        /// <typeparam name="T">The return type of the functions (ignored).</typeparam>
        /// <param name="funcsAsActionsToApplyOnSuccessSubject">Functions to execute on the success value.</param>
        Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsActionsToApplyOnSuccessSubject);

        // Map methods
        /// <summary>
        /// Maps the outcome to new types for both success and failure cases.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="mapOnSuccess">Function to map the success value to a new type.</param>
        /// <param name="mapOnFailure">Function to map the failure value to a new type.</param>
        Outcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure);
        /// <summary>
        /// Maps the success value to a new type.
        /// </summary>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="mapOnSuccess">Function to map the success value to a new type.</param>
        Outcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess);
        /// <summary>
        /// Maps the failure value to a new type.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <param name="mapOnFailure">Function to map the failure value to a new type.</param>
        Outcome<F1, S> MapFailure<F1>(Func<F, F1> mapOnFailure);

        // To Methods
        /// <summary>
        /// Converts the outcome to an optional success value.
        /// </summary>
        /// <returns>An optional success value.</returns>
        Optional<S> ToOptional();
        /// <summary>
        /// Converts the outcome to an optional failure value.
        /// </summary>
        /// <returns>An optional failure value.</returns>
        Optional<F> ToOptionalFailure();
    }
}
