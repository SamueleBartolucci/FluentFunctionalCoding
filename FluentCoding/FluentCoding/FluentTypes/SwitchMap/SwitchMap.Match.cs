namespace FluentCoding
{
    public partial struct SwitchMap<TIn, TOut>
    {
        public TOut Match() => _defaultOrSelectedMapFunction(_subject);
    }
}
