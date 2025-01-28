namespace FluentCoding
{
    public readonly partial struct SwitchMap<TIn, TOut>
    {

        public TOut Match()
        {
            var sbj = this._subject;
            return (_casesByPriority.FirstOrDefault(testCase => testCase.Key(sbj)).Value ?? _defaultCase)(sbj);
        }
    }
}
