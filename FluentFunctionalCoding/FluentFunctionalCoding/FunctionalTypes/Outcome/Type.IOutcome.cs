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
        /// Executes the provided functions depending on whether the outcome is success or failure.
        /// </summary>
        Outcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure);
        /// <summary>
        /// Executes the provided function if the outcome is a success.
        /// </summary>
        Outcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess);
        /// <summary>
        /// Executes the provided function if the outcome is a failure.
        /// </summary>
        Outcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure);
        /// <summary>
        /// Executes the provided actions depending on whether the outcome is success or failure.
        /// </summary>
        Outcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure);
        /// <summary>
        /// Executes the provided action if the outcome is a success.
        /// </summary>
        Outcome<F, S> OnSuccess(Action<S> doOnSuccess);
        /// <summary>
        /// Executes the provided action if the outcome is a failure.
        /// </summary>
        Outcome<F, S> OnFailure(Action<F> doOnFailure);

        // Match methods
        /// <summary>
        /// Matches the outcome and executes the corresponding function.
        /// </summary>
        M Match<M>(Func<S, M> onSuccess, Func<F, M> onFailure);
        /// <summary>
        /// Matches the outcome and executes the success function or returns a value on failure.
        /// </summary>
        M Match<M>(Func<S, M> onSuccess, M valueOnFailure);

        // Bind methods
        /// <summary>
        /// Binds the outcome to a new outcome if it is a success.
        /// </summary>
        Outcome<F, S1> Bind<S1>(Func<S, Outcome<F, S1>> bindOnSuccess);
        /// <summary>
        /// Binds the outcome to a new outcome if it is a failure.
        /// </summary>
        Outcome<F1, S> BindFailure<F1>(Func<F, Outcome<F1, S>> bindOnFailure);
        /// <summary>
        /// Binds the outcome to new outcomes for both success and failure cases.
        /// </summary>
        Outcome<F1, S1> BindFull<F1, S1>(Func<S, Outcome<F1, S1>> bindOnSuccess, Func<F, Outcome<F1, S1>> bindOnFailure);

        // Do methods
        /// <summary>
        /// Executes actions on the success value if present.
        /// </summary>
        Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccessSubject);
        /// <summary>
        /// Executes functions on the success value if present.
        /// </summary>
        Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsActionsToApplyOnSuccessSubject);

        // Map methods
        /// <summary>
        /// Maps the outcome to new types for both success and failure cases.
        /// </summary>
        Outcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure);
        /// <summary>
        /// Maps the success value to a new type.
        /// </summary>
        Outcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess);
        /// <summary>
        /// Maps the failure value to a new type.
        /// </summary>
        Outcome<F1, S> MapFailure<F1>(Func<F, F1> mapOnFailure);

        // To Methods
        /// <summary>
        /// Converts the outcome to an optional success value.
        /// </summary>
        Optional<S> ToOptional();
        /// <summary>
        /// Converts the outcome to an optional failure value.
        /// </summary>
        Optional<F> ToOptionalFailure();

    }
}
