using System;
using System.Collections.Generic;
using System.Linq;

class Test_1
{
	[CodilityFunc]
	public int solution(int[] A, int X)
	{
		int N = A.Length;
		if (N == 0)
		{
			return (-1);
		}
		int l = 0;
		int r = N - 1;
		while (l <= r)  // while (l < r)
		{
			int m = (l + r) / 2;
			if (A[m] >= X) // if (A[m] > X)
			{
				r = m - 1;
			}
			else
			{
				l = m + 1; // l = m;
			}
		}
		if (A[l] == X)
		{
			return l;
		}
		return -1;
	}

	[CodilityFunc]
	public int test1(int[] A, int X)
	{
		var res = Array.BinarySearch<int>(A, X);

		return res > 0 ? res : -1;
	}
}
