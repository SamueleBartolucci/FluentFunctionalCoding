using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public partial struct TryCatch<S, R, E>
    {
        internal readonly S _subject;
        internal R _result;        
        internal E _error;
        internal Exception _exception;
        internal bool _isSuccessful;

        //internal readonly Func<S, R> _funcToTry;
        //internal readonly Func<S, Exception, E> _funcOnCatch;

        public bool IsSuccess => _isSuccessful;
        public bool IsFail => !_isSuccessful;

        internal TryCatch(S subject)
        {
            _subject = subject;            
        }

        private TryCatch(S subject, Func<S, R> tryFunc, Func<S, Exception, E> onCatchFunc)
        {
            _subject = subject;
            Try(tryFunc, onCatchFunc);
        }


        //public static TryCatch<S, R, Exception> ToTry(S subject, Func<S, R> tryFunc) 
        //    => new TryCatch<S, R, Exception>(subject, tryFunc, (sbj, ex) => ex);

        //public static TryCatch<S, Nothing, Exception> ToTry(S subject, Action<S> tryFunc)
        //    => new TryCatch<S, Nothing, Exception>(subject, sbj => Nothing.Null.Do(_ => tryFunc(sbj)), (sbj, ex) => ex);


        public static TryCatch<S, R, E> ToTry(S subject, Func<S, R> tryFunc, Func<S, Exception, E> onCatchFunc)
            => new TryCatch<S, R, E>(subject, tryFunc, onCatchFunc);

        public static TryCatch<S, Nothing, E> ToTry(S subject, Action<S> tryFunc, Func<S, Exception, E> onCatchFunc)
            => new TryCatch<S, Nothing, E>(subject, sbj => Nothing.Null.Do(_ => tryFunc(sbj)), onCatchFunc);


        internal TryCatch<S, R, E> Try(Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
        {
            try
            {
                _result = funcToTry(_subject);
                _isSuccessful = true;
            }
            catch (Exception e)
            {
                _exception = e;
                _isSuccessful = false;
                _error = onCatchFunc(_subject, e);
            }
            return this;
        }

        public Optional<R> ToOptional => IsSuccess ? _result.Some() : Optional<R>.None();
    }
}
