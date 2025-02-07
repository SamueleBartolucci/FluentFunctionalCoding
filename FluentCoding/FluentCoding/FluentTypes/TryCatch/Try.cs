using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public abstract partial record Try<S, R, E>
    {
        internal static NotImplementedException UnknowImplementation() => new NotImplementedException($"Unknown type, expected: {nameof(TrySuccess<S, R, E>)} or {nameof(TryFailure<S, R, E>)}");
        //private readonly S _subject;
        public bool IsSuccess => this switch
            {
                TrySuccess<S, R, E> => true,
                _ => false,
            };

        public bool IsFail => this switch
            {
                TrySuccess<S, R, E> => false,
                _ => true,
            };

        internal Try() {  }


        //private static readonly Func<S, Exception, Exception> _defaultOnCatchFunc = (sbj, ex) => ex;

        internal static Try<S,R,E> Wrap(S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
        {
            try
            {
                return new TrySuccess<S, R, E>(subject, funcToTry(subject));                
            }
            catch (Exception e)
            {
                return new TryFailure<S, R, E>(subject, onCatchFunc(subject, e), e);
            }
            
        }

        internal static Try<S, R, Exception> Wrap(S subject, Func<S, R> funcToTry)
        {
            try
            {
                return new TrySuccess<S, R, Exception>(subject, funcToTry(subject));
            }
            catch (Exception e)
            {
                return new TryFailure<S, R, Exception>(subject, e, e);
            }

        }
    }
}

