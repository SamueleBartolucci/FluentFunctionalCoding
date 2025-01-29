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
        public TryCatch<S, R, E2> Catch<E2>(Func<S, Exception, E2> functOnCatch)
            => new TryCatch<S, R, E2>(this._subject)
            {                
                _result = this._result,
                _error = IsFail? functOnCatch(_subject, _exception) : default,
                _exception = this._exception,
                _isSuccessful = this._isSuccessful
            };
             //=> new TryCatch<S, R, E2> { }
    }
}
