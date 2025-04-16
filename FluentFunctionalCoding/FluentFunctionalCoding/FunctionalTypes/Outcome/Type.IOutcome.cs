
namespace FluentFunctionalCoding
{
    public interface IOutcome<F, S>
    {
        // Properties
        bool IsSuccess { get; }
        bool IsFailure { get; }

        // On methods
        Outcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure);
        Outcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess);
        Outcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure);
        Outcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure);
        Outcome<F, S> OnSuccess(Action<S> doOnSuccess);
        Outcome<F, S> OnFailure(Action<F> doOnFailure);

        // Match methods
        M Match<M>(Func<S, M> onSuccess, Func<F, M> onFailure);
        M Match<M>(Func<S, M> onSuccess, M valueOnFailure);

        // Bind methods
        Outcome<F, S1> Bind<S1>(Func<S, Outcome<F, S1>> bindOnSuccess);
        Outcome<F1, S> BindFailure<F1>(Func<F, Outcome<F1, S>> bindOnFailure);
        Outcome<F1, S1> BindFull<F1, S1>(Func<S, Outcome<F1, S1>> bindOnSuccess, Func<F, Outcome<F1, S1>> bindOnFailure);

        // Do methods
        Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccessSubject);
        Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsActionsToApplyOnSuccessSubject);

        // Map methods
        Outcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure);
        Outcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess);
        Outcome<F1, S> MapFailure<F1>(Func<F, F1> mapOnFailure);

        // To Methods
        Optional<S> ToOptional();
        Optional<F> ToOptionalFailure();

    }
}
