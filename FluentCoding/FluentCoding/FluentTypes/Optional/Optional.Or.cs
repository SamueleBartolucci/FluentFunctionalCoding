
namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        public Optional<O> Or(Optional<O> orRightValue, bool chooseRight = false)
               => this switch
               {
                   OptionalNone<O> => orRightValue,
                   OptionalJust<O> => chooseRight ? orRightValue : this,
                   _ => throw UnknowOptionalType()
               };

        public Optional<O> Or(Optional<O> orRightValue, Func<bool> chooseRightWhen)
            => this switch
            {
                OptionalNone<O> => orRightValue,
                OptionalJust<O> => chooseRightWhen() ? orRightValue : this,
                _ => throw UnknowOptionalType()
            };

        public Optional<O> Or(Optional<O> orRightValue, Func<O, bool> chooseRightWhen)
          => this switch
          {
              OptionalNone<O> => orRightValue,
              OptionalJust<O>(var v) => chooseRightWhen(v) ? orRightValue : this,
              _ => throw UnknowOptionalType()
          };

        public Optional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false)
              => this switch
              {
                  OptionalNone<O> => orRightValueFunc().ToOptional(),
                  OptionalJust<O> => chooseRight ? orRightValueFunc().ToOptional() : this,
                  _ => throw UnknowOptionalType()
              };

        public Optional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen)
            => this switch
            {
                OptionalNone<O> => orRightValueFunc().ToOptional(),
                OptionalJust<O> => chooseRightWhen() ? orRightValueFunc() : this,
                _ => throw UnknowOptionalType()
            };

        public Optional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen)
           => this switch
           {
               OptionalNone<O> => orRightValueFunc().ToOptional(),
               OptionalJust<O>(var v) => chooseRightWhen(v) ? orRightValueFunc().ToOptional() : this,
               _ => throw UnknowOptionalType()
           };

    }
}
