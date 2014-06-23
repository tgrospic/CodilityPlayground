using System;
using System.Collections.Generic;
using System.Linq;

class TapeEquilibrium
{
	[CodilityFunc]
	public int solution(int[] A)
	{
		var idxMax = A.Length - 1;

		var l = new int[idxMax];
		var r = new int[idxMax];

		var lSum = 0;
		var rSum = 0;
		for (int i = 0; i < idxMax; i++)
		{
			lSum = l[i] = A[i] + lSum;
			rSum = r[idxMax - i - 1] = A[idxMax - i] + rSum;
		}

		return l.Zip(r, (x, y) => Math.Abs(x - y)).Min();
	}

	[CodilityFunc]
	public int test1(int[] list)
	{
		var suml = list.Scan((acc, x) => acc + x);
		var sumr = list.Skip(1).Reverse().Scan((acc, x) => acc + x).Reverse();

		var result = suml.Zip(sumr, (x, y) => Math.Abs(x - y));

		return result.Min();
	}
}
