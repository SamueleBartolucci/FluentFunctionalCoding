using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public readonly struct When<T>
    {
        internal readonly T _subject;
        internal readonly bool _isTrue = false;

                
        public When(T switchSubject, bool isTrue)
        {
            this._subject = switchSubject;
            this._isTrue = isTrue;
        }

        public When<T> OnTrue(Action<T> actionToCallOnSubject)
        {
            if(_isTrue) 
                actionToCallOnSubject(_subject);

            return this;
        }

        public When<T> OnFalse(Action<T> actionToCallOnSubject)
        {
            if (!_isTrue)
                actionToCallOnSubject(_subject);

            return this;
        }

        public T1 Match<T1>(Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => (_isTrue? mapOnTrue : mapOnFalse)(_subject);

        public T MatchTrue(Func<T, T> mapOnTrue)
            => _isTrue ? mapOnTrue(_subject) : _subject;

        public T MatchFalse(Func<T, T> mapOnFalse)
            => _isTrue ? _subject : mapOnFalse(_subject);
    }
}
