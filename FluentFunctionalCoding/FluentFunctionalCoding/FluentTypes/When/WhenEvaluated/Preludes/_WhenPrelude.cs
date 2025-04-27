using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFunctionalCoding
{
	public static partial class Prelude
	{
		internal static When<T> _WhenMatch<T>(T whenSubject, bool isTrue) => new When<T>(whenSubject, isTrue);
	}
}
