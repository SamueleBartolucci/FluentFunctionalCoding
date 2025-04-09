using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public interface IOptional<O>
    {
        // Bind methods
        [Pure]
        IOptional<T> Bind<T>(Func<O, IOptional<T>> bindOnSome);

        [Pure]
        IOptional<O> BindNone(Func<IOptional<O>> bindOnNone);

        // OnSome methods
        [Pure]
        IOptional<O> OnSome(Action<O> action);

        [Pure]
        IOptional<O> OnSome<T>(Func<O, T> funcAsAction);

        // OnNone methods
        [Pure]
        IOptional<O> OnNone(Action action);

        [Pure]
        IOptional<O> OnNone<T>(Func<T> funcAsAction);

        // Do methods
        IOptional<O> Do(params Action<O>[] actionsToApplyOnSubject);

        IOptional<O> Do<K>(params Func<O, K>[] functionsToApplyOnSubject);

        // Or methods
        IOptional<O> Or(IOptional<O> orRightValue, bool chooseRight = false);

        IOptional<O> Or(IOptional<O> orRightValue, Func<bool> chooseRightWhen);

        IOptional<O> Or(IOptional<O> orRightValue, Func<O, bool> chooseRightWhen);

        IOptional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false);

        IOptional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen);

        IOptional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen);

        // Map methods
        [Pure]
        IOptional<B> Map<B>(Func<O, B> mapOnSome);

        [Pure]
        IOptional<O> MapNone(Func<O> mapOnNone);

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
