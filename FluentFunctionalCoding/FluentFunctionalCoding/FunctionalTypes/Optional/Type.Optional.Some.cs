namespace FluentFunctionalCoding
{   
    sealed internal record Some<O> : Optional<O>
    {
        internal O _value;
        internal Some(O Value) => _value = Value;

        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public override bool IsSome => true;

        internal void Deconstruct(out O value) => (value) = (_value);
    }
}
