using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCoding
{
	public static partial class WhenIsExtension
	{		
        internal static When<T> _ToWhen<T>(this WhenIs<T> whenIs, Func<T, bool> isTrue) =>
			whenIs switch
			{
				WhenIs<T>(T sbj) => Prelude._WhenMatch(sbj, isTrue(sbj)),
				_ => throw new ArgumentException("Invalid type")
			};
	}
}
