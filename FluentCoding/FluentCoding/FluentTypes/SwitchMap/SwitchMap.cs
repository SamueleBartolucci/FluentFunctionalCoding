using System.Collections.ObjectModel;

namespace FluentCoding
{
    public readonly struct SwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;
        internal readonly Func<TIn, TOut> _defaultCase = null;
        internal readonly Dictionary<Func<TIn, bool>, Func<TIn, TOut>> _casesByPriority = new Dictionary<Func<TIn, bool>, Func<TIn, TOut>>();

        private SwitchMap(TIn switchSubject) => this._subject = switchSubject;

        public SwitchMap(TIn switchSubject, Func<TIn, TOut> defaultCase) : this(switchSubject)
            => this._defaultCase = defaultCase;

        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
        {
            _casesByPriority.Add(_ => predicate, map);
            return this;
        }
        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
        {
            _casesByPriority.Add(_ => predicate(), map);
            return this;
        }

        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
        {
            _casesByPriority.Add(predicate, map);
            return this;
        }

        public TOut Match()
        {
            var sbj = this._subject;
            return (_casesByPriority.FirstOrDefault(testCase => testCase.Key(sbj)).Value ?? _defaultCase)(sbj);
        }
    }
}
