using System;
using System.Collections.Generic;
using System.Linq;

class EquilibriumIndex
{
	[CodilityFunc]
	public int solution(int[] A)
	{
		if (A.Length == 0) return -1;

		var sum = A.Scan(0L, (acc, x) => acc + x).Skip(1).ToArray();
		var total = sum.Last();

		for (int i = 0; i < A.Length; i++)
		{
			var left = i == 0 ? 0 : sum[i - 1];
			var right = total - sum[i];
			if (left == right)
			{
				return i;
			}
		}
		return -1;
	}

	[CodilityFunc]
	public int solution1(int[] A)
	{
		if (A.Length == 0) return -1;

		var sum = A.Scan(0L, (acc, x) => acc + x).Skip(1).ToArray();
		var total = sum.Last();
		var init = new { eq = false, val = 0L, idx = -1 };
		var diffs = sum.Scan(init, (prev, x) => new { eq = x == total - prev.val, val = x, idx = prev.idx + 1 });
		var res = diffs.FirstOrDefault(x => x.eq);

		return res != null ? res.idx : -1;
	}

	[CodilityFunc]
	public int test1(int[] A)
	{
		for (int i = 0; i < A.Length; i++)
		{
			var suml = A.Take(i).Sum(x => (long)x);
			var sumr = A.Skip(i + 1).Sum(x => (long)x);
			var isSame = suml == sumr;
			if (isSame)
			{
				return i;
			}
		}
		return -1;
	}
}
