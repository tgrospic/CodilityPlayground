using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

class Codility
{
	public static void Run<T>(Func<object[]> argsGenerator) where T : new()
	{
		while (true)
		{
			Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

			var methodArgs = argsGenerator();

			var test = new T();
			Console.WriteLine(typeof(T).Name);

			Console.WriteLine("  ARGS:");
			methodArgs.PrettyString().Iter((x, i) => Console.WriteLine("     {0}: {1:d}".PadRight(10), i, x));

			var sw = new Stopwatch();

			foreach (var m in GetCodilityFunctions<T>())
			{
				Console.Write("{0} = ", m.Name.ToUpper().PadRight(15));

				sw.Restart();

				var result = m.Invoke(test, methodArgs);

				var elapsed = sw.ElapsedMilliseconds;

				if (result is IEnumerable)
				{
					var resultList = (result as IEnumerable).OfType<object>().PrettyString();
					foreach (var x in resultList)
					{
						Console.WriteLine("{0}  : {1:N3}ms", x, elapsed / 1000.0);
					}
				}
				else
				{
					Console.WriteLine("{0}  : {1:N3}ms", result, elapsed / 1000.0);
				}
			}

			Console.WriteLine("Repeat: Y, Next: ENTER");
			var key = Console.ReadKey(true);
			if (key.Key != ConsoleKey.Y)
			{
				break;
			}
		}
	}

	public static MethodInfo[] GetCodilityFunctions<T>()
	{
		var methods = typeof(T).GetMethods().Where(x => x.GetCustomAttributes<CodilityFuncAttribute>().Any());

		return methods.ToArray();
	}

	public static int[] RandomInts(int count, int? min = 0, int? max = null)
	{
		var rnd = new Random(DateTime.Now.Millisecond);

		return Enumerable.Range(0, count).Select(_ => rnd.Next(min.Value, max ?? count)).ToArray();
	}

	public static int[] RandomUniqueInts(int count, int? min = 0)
	{
		var list = Enumerable.Range(min.Value, count).ToArray();
		var rnd = new Random(DateTime.Now.Millisecond);
		var idxMax = list.Length - 1;

		// Shuffle list length times
		foreach (var x in list)
		{
			var r1 = rnd.Next(idxMax);
			var r2 = rnd.Next(idxMax);
			var v1 = list[r1];
			var v2 = list[r2];
			list[r1] = v2;
			list[r2] = v1;
		}
		return list;
	}
}
