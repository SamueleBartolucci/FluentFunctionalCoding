using FluentAssertions;
using FluentFunctionalCoding;
using System.Runtime.CompilerServices;

namespace FluentCodingTest.SwitchMap
{    
    internal static class SwitchMapUtils
    {
        public static (TI _subject, Func<TI, TO> _defaultOrSelectedMapFunction) AsValues<TI, TO>(this SwitchMap<TI, TO> switchMap) => switchMap switch
        {
            DefaultCase<TI, TO>(TI sbj, Func<TI, TO> func) => (_subject: sbj, _defaultOrSelectedMapFunction: func),
            PredicateMatchCase<TI, TO>(TI sbj, Func<TI, TO> funcMatch) => (_subject: sbj, _defaultOrSelectedMapFunction: funcMatch),
            _ => throw SwitchMap<TI, TO>.UnknowOptionalType()
        };
    }
}
