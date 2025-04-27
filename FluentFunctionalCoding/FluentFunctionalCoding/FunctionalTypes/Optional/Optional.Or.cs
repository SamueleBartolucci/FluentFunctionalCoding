
using FluentFunctionalCoding.FluentPreludes;

namespace FluentFunctionalCoding
{
    public abstract partial record Optional<O>// : Optional<O>
    {
        public Optional<O> Or(Optional<O> orRightValue, bool chooseRight = false)
               => this switch
               {
                   None<O> => orRightValue,
                   Some<O> => chooseRight ? orRightValue : this,
                   _ => throw UnknowOptionalType()
               };

        public Optional<O> Or(Optional<O> orRightValue, Func<bool> chooseRightWhen)
            => this switch
            {
                None<O> => orRightValue,
                Some<O> => chooseRightWhen() ? orRightValue : this,
                _ => throw UnknowOptionalType()
            };

        public Optional<O> Or(Optional<O> orRightValue, Func<O, bool> chooseRightWhen)
          => this switch
          {
              None<O> => orRightValue,
              Some<O>(var v) => chooseRightWhen(v) ? orRightValue : this,
              _ => throw UnknowOptionalType()
          };

        public Optional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false)
              => this switch
              {
                  None<O> => orRightValueFunc().ToOptional(),
                  Some<O> => chooseRight ? orRightValueFunc().ToOptional() : this,
                  _ => throw UnknowOptionalType()
              };

        public Optional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen)
            => this switch
            {
                None<O> => orRightValueFunc().ToOptional(),
                Some<O> => chooseRightWhen() ? orRightValueFunc() : this,
                _ => throw UnknowOptionalType()
            };

        public Optional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen)
           => this switch
           {
               None<O> => orRightValueFunc().ToOptional(),
               Some<O>(var v) => chooseRightWhen(v) ? orRightValueFunc().ToOptional() : this,
               _ => throw UnknowOptionalType()
           };

    }
}
