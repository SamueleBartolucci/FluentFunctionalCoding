namespace FluentCoding
{
    public interface ISwitchMap<out TIn, TOut>
    {
        ISwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map);

        ISwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map);

        ISwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map);

        public TOut Match();
    }

}
