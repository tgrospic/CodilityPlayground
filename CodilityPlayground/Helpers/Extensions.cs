using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

static class Extensions
{
	// Iter
	public static IEnumerable<T> Iter<T>(this IEnumerable<T> source, Action<T> iter)
	{
		foreach (var x in source)
		{
			iter(x);
		}
		return source;
	}

	public static IEnumerable<T> Iter<T>(this IEnumerable<T> source, Action<T, int> iter)
	{
		var idx = 0;
		foreach (var x in source)
		{
			iter(x, idx);
			idx++;
		}
		return source;
	}

	// Pairwise
	public static IEnumerable<Tuple<T, T>> Pairwise<T>(this IEnumerable<T> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}

		var previous = default(T);

		using (var enumerator = source.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				previous = enumerator.Current;
			}

			while (enumerator.MoveNext())
			{
				yield return Tuple.Create(previous, enumerator.Current);
				previous = enumerator.Current;
			}
		}
	}

	public static IEnumerable<Tuple<U, U>> Pairwise<T, U>(this IEnumerable<T> source, Func<T, U> generator)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}

		var previous = default(T);

		using (var enumerator = source.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				previous = enumerator.Current;
			}

			while (enumerator.MoveNext())
			{
				yield return Tuple.Create(generator(previous), generator(enumerator.Current));
				previous = enumerator.Current;
			}
		}
	}

	public static IEnumerable<Tuple<U, U>> Pairwise<T, U>(this IEnumerable<T> source, Func<T, int, U> generator)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}

		var previous = default(T);

		using (var enumerator = source.GetEnumerator())
		{
			var idx = 0;
			if (enumerator.MoveNext())
			{
				previous = enumerator.Current;
			}

			while (enumerator.MoveNext())
			{
				yield return Tuple.Create(generator(previous, idx), generator(enumerator.Current, idx + 1));
				previous = enumerator.Current;
				idx++;
			}
		}
	}

	// Pretty string
	public static IEnumerable<string> PrettyString(this object source, int limit = 15)
	{
		if (source is IEnumerable)
		{
			var xs = (source as IEnumerable).OfType<object>();
			var elType = source.GetType().GetElementType();
			if (elType != null && !elType.IsValueType)
			{
				// Sub list
				foreach (var x in xs)
				{
					foreach (var x1 in PrettyString(x))
					{
						yield return x1;
					}
				}
			}
			else
			{
				yield return PrettyListImpl(xs);
			}
		}
		else
		{
			// Not list
			yield return string.Format("{0:d}", source);
		}
	}

	private static string PrettyListImpl(this IEnumerable<object> source, int limit = 15)
	{
		var c = source.Count();
		var more = c > limit ? "..." : "";

		return string.Format("N={2:N0} [{0}{1}]", string.Join(", ", source.Take(limit)), more, c);
	}
}