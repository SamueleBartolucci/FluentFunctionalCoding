
namespace FluentCoding
{
    public readonly partial struct Optional<O>
    {
        public Optional<O> Or(Optional<O> orRightValue, bool chooseRight = false)
          => (!_isSomething || chooseRight) ? orRightValue : this;

        public Optional<O> Or(Optional<O> orRightValue, Func<bool> chooseRightWhen)
            => (!_isSomething || chooseRightWhen()) ? orRightValue : this;

        public Optional<O> Or(Optional<O> orRightValue, Func<O, bool> chooseRightWhen)
           => this.Match(chooseRightWhen, () => true) ? orRightValue : this;

        public Optional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false)
            => (!_isSomething || chooseRight) ? Optional<O>.Some(orRightValueFunc()) : this;

        public Optional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen)
            => (!_isSomething || chooseRightWhen()) ? Optional<O>.Some(orRightValueFunc()) : this;

        public Optional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen)
           => this.Match(chooseRightWhen, () => true) ? Optional<O>.Some(orRightValueFunc()) : this;

    }
}
