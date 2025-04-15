namespace FluentFunctionalCoding
{
    public partial record SwitchMap<TIn, TOut> //: SwitchMap<TIn, TOut>
    {
        public TOut Match() => _defaultOrSelectedMapFunction(_subject);
    }
}
