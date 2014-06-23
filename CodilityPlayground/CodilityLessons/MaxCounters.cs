using System;
using System.Collections.Generic;
using System.Linq;

class MaxCounters
{
	[CodilityFunc]
	public int[] solution(int N, int[] A)
	{
		var counters = new int[N];
		var max = 0;
		var maxAll = 0;

		for (int i = 0; i < A.Length; i++)
		{
			var a = A[i];
			if (a >= 1 && a <= N)
			{
				var idx = a - 1;
				
				// Update counter with max value
				if (counters[idx] < maxAll)
					counters[idx] = maxAll;

				// Increase counter
				var inc = counters[idx] += 1;
				max = Math.Max(max, inc);
			}
			else if (a == N + 1)
			{
				// Set all counters to max of any counter
				maxAll = max;
			}
		}

		for (int k = 0; k < N; k++)
		{
			if(counters[k] < maxAll)
				counters[k] = maxAll;
		}

		return counters;
	}

	[CodilityFunc]
	public int[] solution1(int N, int[] A)
	{
		var counters = new int[N];
		var max = 0;

		for (int i = 0; i < A.Length; i++)
		{
			var a = A[i];
			if (a >= 1 && a <= N)
			{
				// Increase counter
				var idx = a - 1;
				var inc = counters[idx] += 1;
				max = Math.Max(max, inc);
			}
			else if (a == N + 1)
			{
				// Set all counters to max of any counter
				// SLOW <----------------------------------------------------------
				for (int k = 0; k < N; k++)
				{
					counters[k] = max;
				}
			}
		}
		return counters;
	}

	[CodilityFunc]
	public int[] test1(int N, int[] A)
	{
		var fst = new { c = new int[N], max = 0, maxAll = 0 };

		var res = A.Aggregate(fst, (acc, x) =>
		{
			var max = acc.max;
			var maxAll = acc.maxAll;
			if (x >= 1 && x <= N)
			{
				var idx = x - 1;

				// Update counter with max value
				if (acc.c[idx] < maxAll)
					acc.c[idx] = maxAll;

				// Increase counter
				var inc = acc.c[idx] += 1;
				max = Math.Max(max, inc);
			}
			else if (x == N + 1)
			{
				// Set all counters to max of any counter
				maxAll = max;
			}
			return new { c = acc.c, max, maxAll };
		});

		for (int k = 0; k < N; k++)
		{
			if(res.c[k] < res.maxAll)
				res.c[k] = res.maxAll;
		}

		return res.c;
	}
}
