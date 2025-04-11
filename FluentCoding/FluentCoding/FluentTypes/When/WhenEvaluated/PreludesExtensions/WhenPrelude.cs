using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
	public static partial class WhenIsExtension
	{
		internal static IWhen<T> ToWhen<T>(this IWhenIs<T> whenIs, Func<T, bool> isTrue) =>
			whenIs switch
			{
				WhenIs<T>(T sbj) => When<T>.WhenMatch(sbj, isTrue(sbj)),
				_ => throw new ArgumentException("Invalid type")
			};

		internal static IWhen<T> ToWhen<T>(this IWhen<T> when) =>
			when switch
			{
				When<T> w => w,
				_ => throw new ArgumentException("Invalid type")
			};

		internal static T Subject<T>(this IWhen<T> when) =>
			when switch
			{
				When<T>(T sbj) => sbj,
				_ => throw new ArgumentException("Invalid type")
			};

	}
}
