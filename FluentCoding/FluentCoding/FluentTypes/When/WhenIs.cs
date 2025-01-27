using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public readonly struct WhenIs<T>
    {
        internal readonly T _subject;        
      
        public WhenIs(T subject) => this._subject = subject;

        public When<T> Is(bool isTrue) => new When<T>(_subject, isTrue);
        public When<T> Is(params Func<bool>[] predicates) => new When<T> (_subject, predicates.All(p => p()));
        public When<T> Is(params Func<T, bool>[] predicates)
        {
            var sbj = _subject;
            return new When<T>(_subject, predicates.All(p => p(sbj)));
        }
    }
}
