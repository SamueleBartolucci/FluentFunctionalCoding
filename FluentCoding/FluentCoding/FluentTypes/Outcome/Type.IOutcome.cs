
namespace FluentCoding
{
    public interface IOutcome<F, S>
    {
        // Properties
        bool IsSuccess { get; }
        bool IsFailure { get; }

        // On methods
        IOutcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure);
        IOutcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess);
        IOutcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure);
        IOutcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure);
        IOutcome<F, S> OnSuccess(Action<S> doOnSuccess);
        IOutcome<F, S> OnFailure(Action<F> doOnFailure);

        // Match methods
        M Match<M>(Func<S, M> onSuccess, Func<F, M> onFailure);
        M Match<M>(Func<S, M> onSuccess, M valueOnFailure);

        // Bind methods
        IOutcome<F, S1> Bind<S1>(Func<S, IOutcome<F, S1>> bindOnSuccess);
        IOutcome<F1, S> BindFailure<F1>(Func<F, IOutcome<F1, S>> bindOnFailure);
        IOutcome<F1, S1> BindFull<F1, S1>(Func<S, IOutcome<F1, S1>> bindOnSuccess, Func<F, IOutcome<F1, S1>> bindOnFailure);

        // Do methods
        IOutcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccessSubject);
        IOutcome<F, S> Do<T>(params Func<S, T>[] funcsAsActionsToApplyOnSuccessSubject);

        // Map methods
        IOutcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure);
        IOutcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess);
        IOutcome<F1, S> MapFailure<F1>(Func<F, F1> mapOnFailure);

        // To Methods
        IOptional<S> ToOptional();
        IOptional<F> ToOptionalFailure();

    }
}
