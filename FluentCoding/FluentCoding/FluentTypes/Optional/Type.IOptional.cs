using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public interface IOptional<O>
    {
        // Bind methods
        [Pure]
        Optional<T> Bind<T>(Func<O, Optional<T>> bindOnSome);

        [Pure]
        Optional<O> BindNone(Func<Optional<O>> bindOnNone);

        [Pure]
        Task<Optional<T>> BindAsync<T>(Func<O, Task<Optional<T>>> bindAsyncOnSome);

        [Pure] 
        Task<Optional<O>> BindNoneAsync(Func<Task<Optional<O>>> bindAsyncOnNone);

        // OnSome methods
        [Pure]
        Optional<O> OnSome(Action<O> action);

        [Pure]
        Optional<O> OnSome<T>(Func<O, T> funcAsAction);

        // OnNone methods
        [Pure]
        Optional<O> OnNone(Action action);

        [Pure]
        Optional<O> OnNone<T>(Func<T> funcAsAction);

        // Do methods
        Optional<O> Do(params Action<O>[] actionsToApplyOnSubject);

        Optional<O> Do<K>(params Func<O, K>[] functionsToApplyOnSubject);

        // Or methods
        Optional<O> Or(Optional<O> orRightValue, bool chooseRight = false);

        Optional<O> Or(Optional<O> orRightValue, Func<bool> chooseRightWhen);

        Optional<O> Or(Optional<O> orRightValue, Func<O, bool> chooseRightWhen);

        Optional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false);

        Optional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen);

        Optional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen);

        // Map methods
        [Pure]
        Optional<B> Map<B>(Func<O, B> mapOnSome);

        [Pure]
        Optional<O> MapNone(Func<O> mapOnNone);

        // Match methods
        [Pure]
        O MatchNone(Func<O> mapOnNone);

        [Pure]
        O MatchNone(O valueWhenNone);

        [Pure]
        T Match<T>(Func<O, T> mapOnSome, Func<T> mapOnNone);

        [Pure]
        T Match<T>(Func<O, T> mapOnSome, T valueOnNone);

        // ToOutcome methods
        [Pure]
        Outcome<F, O> ToOutcome<F>(Func<F> onNone);

        [Pure]
        Outcome<F, O> ToOutcome<F>(F valueOnNone);

        // Properties
        bool IsSome { get; }

        bool IsNone { get; }
    }
}
