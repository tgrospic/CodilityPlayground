using System;
using System.Collections.Generic;
using System.Linq;

class Test_3
{
	[CodilityFunc]
	public int solution(int K, int[] A)
	{
		var sorted = A.OrderBy(x => x).ToArray();
		var count = 0;
		for (int i = 0; i < sorted.Length; i++)
		{
			var a = K - sorted[i];
			var b = BinarySearchCount(sorted, a);
			count += b;
		}
		return count;
	}

	private int BinarySearchCount(int[] sorted, int K)
	{
		var count = 0;
		var len = sorted.Length; 
		var idx = Array.BinarySearch<int>(sorted, K);
		if (idx > -1)
		{
			count++;
			// Search up index
			for (int i = idx + 1; i < len; i++)
			{
				var y = sorted[i];
				if (K == y)
					count++;
				else
					break;
			}
			// Search down index
			for (int i = idx - 1; i >= 0; i--)
			{
				var y = sorted[i];
				if (K == y)
					count++;
				else
					break;
			}
		}
		return count;
	}

	[CodilityFunc]
	public int test1(int K, int[] A)
	{
		var count = 0;
		foreach (var x1 in A)
		{
			foreach (var x2 in A)
			{
				long s = x1 + x2;
				if (s == K)
				{
					//Console.WriteLine("{0}, {1}", x1, x2);
					count++;
				}
			}
		}
		return count;
	}
}
