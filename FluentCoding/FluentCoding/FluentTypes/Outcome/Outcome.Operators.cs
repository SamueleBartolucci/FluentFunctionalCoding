using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public static implicit operator Outcome<F, S>(S success) => Success(success);
        public static implicit operator Outcome<F, S>(F failure) => Failure(failure);

        
        public static bool operator true(Outcome<F, S> value) => value.IsSuccess;                
        public static bool operator false(Outcome<F, S> value) => value.IsFailure;
        public static bool operator !(Outcome<F, S> value) => value.IsFailure;
    }
}
