namespace FluentFunctionalCoding
{
    public abstract partial record Try<S, R, E>
    {
        internal static NotImplementedException UnknowImplementation() => new NotImplementedException($"Unknown type, expected: {nameof(Success<S, R, E>)} or {nameof(Failure<S, R, E>)}");
        //private readonly S _subject;
        public bool IsSuccess => this switch
        {
            Success<S, R, E> => true,
            _ => false,
        };

        public bool IsFail => !IsSuccess;

        internal Try() { }


        //private static readonly Func<S, Exception, Exception> _defaultOnCatchFunc = (sbj, ex) => ex;

        internal static Try<S, R, E> Wrap(S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
        {
            try
            {
                return new Success<S, R, E>(subject, funcToTry(subject));
            }
            catch (Exception e)
            {
                return new Failure<S, R, E>(subject, onCatchFunc(subject, e), e);
            }

        }

        internal static Try<S, R, Exception> Wrap(S subject, Func<S, R> funcToTry)
        {
            try
            {
                return new Success<S, R, Exception>(subject, funcToTry(subject));
            }
            catch (Exception e)
            {
                return new Failure<S, R, Exception>(subject, e, e);
            }

        }
    }
}

