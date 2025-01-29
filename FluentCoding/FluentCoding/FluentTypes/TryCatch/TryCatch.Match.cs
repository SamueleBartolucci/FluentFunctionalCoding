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
        public R MatchFail(Func<E, R> onError)
            => IsSuccess ? _result : onError(_error);

        public R MatchFail(R valueOnFail)
            => IsSuccess ? _result : valueOnFail;

        public M Match<M>(Func<R, M> onSuccess, Func<E, M> onError)
            => IsSuccess ? onSuccess(_result) : onError(_error);
    }
}
