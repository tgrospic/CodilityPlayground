using System;
using System.Collections.Generic;
using System.Linq;

static class LinqExtensions
{
	// Foldl with intermediate result
	public static IEnumerable<T> Scan<T>(this IEnumerable<T> source, Func<T, T, T> transformation)
	{
		using (IEnumerator<T> enumerator = source.GetEnumerator())
		{
			if (!enumerator.MoveNext())
				yield break;
			T state = enumerator.Current;
			yield return state;
			while (enumerator.MoveNext())
			{
				state = transformation(state, enumerator.Current);
				yield return state;
			}
		}
	}

	public static IEnumerable<TState> Scan<TSource, TState>(this IEnumerable<TSource> source, TState seed, Func<TState, TSource, TState> transformation)
	{
		using (var i = source.GetEnumerator())
		{
			var aggregator = seed;

			while (i.MoveNext())
			{
				yield return aggregator;
				aggregator = transformation(aggregator, i.Current);
			}
			yield return aggregator;
		}
	}
}