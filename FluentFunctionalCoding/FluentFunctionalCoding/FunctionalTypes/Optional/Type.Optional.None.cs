namespace FluentFunctionalCoding
{

    sealed internal record None<O> : Optional<O>
    {
        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public override bool IsSome => false;        
    }
}
