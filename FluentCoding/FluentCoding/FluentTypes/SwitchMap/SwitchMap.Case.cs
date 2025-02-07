using System;

namespace FluentCoding
{
    public partial struct SwitchMap<TIn, TOut>
    {
        private void CheckAndSelectMapFunction(bool predicateValue, Func<TIn, TOut> mapFunc)
        {
            if (_truePredicateNotFound && predicateValue)
            {
                _defaultOrSelectedMapFunction = mapFunc;
                _truePredicateNotFound = true;
            }
        }

        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
        {
            CheckAndSelectMapFunction(predicate, map);
            return this;
        }
        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
        {
            CheckAndSelectMapFunction(predicate(), map);
            return this;
        }

        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
        {
            CheckAndSelectMapFunction(predicate(_subject), map);
            return this;
        }
    }
}
