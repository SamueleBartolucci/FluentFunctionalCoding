namespace FluentCoding
{
    public partial record SwitchMap<TIn, TOut> : ISwitchMap<TIn, TOut>
    {
        public TOut Match() => _defaultOrSelectedMapFunction(_subject);
    }
}
