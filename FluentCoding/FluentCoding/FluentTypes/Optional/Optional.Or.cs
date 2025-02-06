
namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        public Optional<O> Or(Optional<O> orRightValue, bool chooseRight = false)
               => this switch
               {
                   Nothing<O> => orRightValue,
                   Just<O> => chooseRight ? orRightValue : this,
                   _ => throw UnknowImplementation()
               };

        public Optional<O> Or(Optional<O> orRightValue, Func<bool> chooseRightWhen)
            => this switch
            {
                Nothing<O> => orRightValue,
                Just<O> => chooseRightWhen() ? orRightValue : this,
                _ => throw UnknowImplementation()
            };

        public Optional<O> Or(Optional<O> orRightValue, Func<O, bool> chooseRightWhen)
          => this switch
          {
              Nothing<O> => orRightValue,
              Just<O>(var v) => chooseRightWhen(v) ? orRightValue : this,
              _ => throw UnknowImplementation()
          };

        public Optional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false)
              => this switch
              {
                  Nothing<O> => orRightValueFunc(),
                  Just<O> => chooseRight ? orRightValueFunc() : this,
                  _ => throw UnknowImplementation()
              };

        public Optional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen)
            => this switch
            {
                Nothing<O> => orRightValueFunc(),
                Just<O> => chooseRightWhen() ? orRightValueFunc() : this,
                _ => throw UnknowImplementation()
            };

        public Optional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen)
           => this switch
           {
               Nothing<O> => orRightValueFunc(),
               Just<O>(var v) => chooseRightWhen(v) ? orRightValueFunc() : this,
               _ => throw UnknowImplementation()
           };

    }
}
