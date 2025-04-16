namespace FluentFunctionalCoding
{
    sealed internal record Some<O> : Optional<O>
    {
        internal O _value;
        internal Some(O Value) => _value = Value;

        internal void Deconstruct(out O value) => (value) = (_value);
    }
}
