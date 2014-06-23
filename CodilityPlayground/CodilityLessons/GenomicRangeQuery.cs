using System;
using System.Collections.Generic;
using System.Linq;

class GenomicRangeQuery
{
	public static Dictionary<char, int> Map = new Dictionary<char, int>()
	{
		{ 'A', 1 },
		{ 'C', 2 },
		{ 'G', 3 },
		{ 'T', 4 }
	};

	[CodilityFunc]
	public int[] solution(string S, int[] P, int[] Q)
	{
		var fst = new { A = 0, C = 0, G = 0, T = 0 };
		var expand = S.Scan(fst, (acc, x) =>
		{
			int A, C, G, T = 0;
			A = C = G = T = 0;
			switch (x)
			{
				case 'A': A = 1; break;
				case 'C': C = 1; break;
				case 'G': G = 1; break;
				case 'T': T = 1; break;
			}
			return new { A = acc.A + A, C = acc.C + C, G = acc.G + G, T = acc.T + T };
		}).ToArray();

		var res = P.Zip(Q, (p, q) => new { p, q })
			.Select(x =>
			{
				var ps = expand[x.p];
				var qs = expand[x.q + 1];

				if (qs.A - ps.A > 0) return 1;
				if (qs.C - ps.C > 0) return 2;
				if (qs.G - ps.G > 0) return 3;
				if (qs.T - ps.T > 0) return 4;

				return 0;
			});
		return res.ToArray();
	}

	[CodilityFunc]
	public int[] solution1(string S, int[] P, int[] Q)
	{
		var fst = new int[4];
		var expand = S.Scan(fst, (acc, x) =>
		{
			// 1s slower
			//var a = fst.Zip(acc, (l, r) => l + r).ToArray();
			//var idx = Map[x] - 1;
			//a[idx] += 1;

			var a = new int[4];
			for (int i = 0; i < 4; i++)
			{
				a[i] = fst[i] + acc[i];
			}
			var idx = Map[x] - 1;
			a[idx] += 1;

			return a;
		}).ToArray();

		var res = P.Zip(Q, (p, q) => new { p, q })
			.Select(x =>
			{
				var ps = expand[x.p];
				var qs = expand[x.q + 1];

				var idx = 0;
				for (var i = 0; i < 4; i++)
				{
					idx = i;
					var p = ps[i];
					var q = qs[i];
					if (q - p > 0)
						break;
				}
				return idx + 1;
			});
		return res.ToArray();
	}

	[CodilityFunc]
	public int[] solution2(string S, int[] P, int[] Q)
	{
		int len = S.Length;
		int[][] arr = new int[len][];
		int[] result = new int[P.Length];

		for (int i = 0; i < len; i++)
		{
			arr[i] = new int[4];
			char c = S[i];
			if (c == 'A') arr[i][0] = 1;
			if (c == 'C') arr[i][1] = 1;
			if (c == 'G') arr[i][2] = 1;
			if (c == 'T') arr[i][3] = 1;
		}
		// compute prefixes
		for (int i = 1; i < len; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				arr[i][j] += arr[i - 1][j];
			}
		}

		for (int i = 0; i < P.Length; i++)
		{
			int x = P[i];
			int y = Q[i];

			for (int a = 0; a < 4; a++)
			{
				int sub = 0;
				if (x - 1 >= 0) sub = arr[x - 1][a];
				if (arr[y][a] - sub > 0)
				{
					result[i] = a + 1;
					break;
				}
			}
		}
		return result;
	}

	[CodilityFunc]
	public int[] test1(string S, int[] P, int[] Q)
	{
		var s = S.Select(x => Map[x]).ToArray();
		var res = P.Zip(Q, (p, q) => s.Skip(p).Take(q - p + 1).Min());

		return res.ToArray();
	}

	[CodilityFunc]
	public int[] test2(string S, int[] P, int[] Q)
	{
		var s = S.Select(x => Map[x]).ToArray();
		var idxMax = P.Length;
		var res = new int[idxMax];

		for (int i = 0; i < idxMax; i++)
		{
			var p = P[i];
			var q = Q[i];
			res[i] = s.Skip(p).Take(q - p + 1).Min();
		}
		return res;
	}

	// Helpers
	public static object[] GenomicRangeQueryArgs()
	{
		var max = 4;
		var map = GenomicRangeQuery.Map;
		var chars = map.Keys.ToArray();
		var ints = Codility.RandomInts(1000000, 0, max);
		var str1 = ints.Select(x => chars[x]).ToArray();
		var str = new String(str1);

		var rnd = new Random(DateTime.Now.Millisecond);
		var P = Codility.RandomInts(1000000, 0, max);
		var Q = P.Select(x =>
		{
			var q = rnd.Next(max);
			if (q < x)
			{
				q = Math.Max(x, x + 1);
			}
			return q;
		}).ToArray();

		return new object[] { str, P, Q };
	}
}
