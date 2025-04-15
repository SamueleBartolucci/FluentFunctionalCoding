
namespace FluentFunctionalCoding
{
    public interface IWhen<T>
    {
        // Properties
        bool IsTrue { get; }
        bool IsFalse { get; }

        // On methods
        IWhen<T> OnTrue(Action<T> funcAsActionToCallOnSubject);
        IWhen<T> OnFalse(Action<T> funcAsActionToCallOnSubject);
        IWhen<T> OnTrue<X>(Func<T, X> funcAsActionToCallOnSubject);
        IWhen<T> OnFalse<X>(Func<T, X> funcAsActionToCallOnSubject);

        // Match methods
        T1 Match<T1>(Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse);
        T MatchTrue(Func<T, T> mapOnTrue);
        T MatchFalse(Func<T, T> mapOnFalse);
    }
}
