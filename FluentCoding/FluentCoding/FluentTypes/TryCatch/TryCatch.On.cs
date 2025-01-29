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
        public readonly TryCatch<S, R, E> OnFail(Action<S, E> actionOnError)
        { 
            if(IsFail) 
                actionOnError(_subject, _error); 

            return this;
        }
        //public readonly TryCatch<S, R, E> OnFail(Action<E> actionOnError)
        //{
        //    if (IsFail)
        //        actionOnError(_error);

        //    return this;
        //}

        public TryCatch<S, R, E> OnFail(Action<S> doOnsubjectWhenOnError)
        {
            if (IsFail)
                doOnsubjectWhenOnError(_subject);

            return this;
        }


        public TryCatch<S, R, E> OnSuccess(Action<S, R> actionOnSuccess)
        {
            if (IsSuccess)
                actionOnSuccess(_subject, _result);

            return this;
        }

        public TryCatch<S, R, E> OnSuccess(Action<R> doOnResultWhenOnSuccess)
        {
            if (IsSuccess)
                doOnResultWhenOnSuccess(_result);

            return this;
        }

        //public TryCatch<S, R, E> OnSuccess(Action<S> actionOnSuccess)
        //{
        //    if (IsSuccess)
        //        actionOnSuccess(_subject);

        //    return this;
        //}
    }
}
