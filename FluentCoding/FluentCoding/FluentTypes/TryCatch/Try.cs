using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public partial struct TryCatch<S, R>
    {
        internal readonly S _subject;
        internal R _result;
        internal Exception _exception;
        internal bool _isSuccessful;

        //internal readonly Func<S, R> _funcToTry;
        //internal readonly Func<S, Exception, E> _funcOnCatch;

        public readonly bool IsSuccess => _isSuccessful;
        public readonly bool IsFail => !_isSuccessful;

        private TryCatch(S subject)
        {
            _subject = subject;            
        }

        private TryCatch(S subject, Func<S, R> tryFunc)
        {
            _subject = subject;
            TryWrap(tryFunc);
        }


        public static TryCatch<S, R> ToTry(S subject, Func<S, R> tryFunc) 
            => new (subject, tryFunc);

        public static TryCatch<S, Nothing> ToTry(S subject, Action<S> tryFunc)
            => new (subject, sbj => Nothing.Null.Do(_ => tryFunc(sbj)));


        internal TryCatch<S, R> TryWrap(Func<S, R> funcToTry)
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
            }
            return this;
        }

        public Optional<R> ToOptional() => IsSuccess ? _result.Some() : Optional<R>.None();
    }
}
