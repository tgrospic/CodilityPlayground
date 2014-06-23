using System;
using System.Collections.Generic;
using System.Linq;

class MinAbsSumOfTwo
{
	[CodilityFunc]
	public int solution(int[] list)
	{
		var xs = list.Select(x => new { x, abs = Math.Abs(x), isMinus = x < 0 }).OrderBy(x => x.abs);
		var h = xs.First();
		var c = h;
		var min = Math.Abs(h.x + h.x);
		foreach (var x in xs)
		{
			if (c.isMinus != x.isMinus)
			{
				var abs = Math.Abs(c.x + x.x);
				if (abs < min)
				{
					min = abs;
				}
			}
			c = x;
		}
		return min;
	}

	[CodilityFunc]
	public int solution1(int[] list)
	{
		var xs = list.Select(x => new { x, abs = Math.Abs(x), isMinus = x < 0, min = Math.Abs(x + x) }).OrderBy(x => x.abs);
		var h = xs.First();

		var res = xs.Aggregate(h,
			(c, x) =>
			{
				var min = c.min;

				if (c.isMinus != x.isMinus)
				{
					var abs = Math.Abs(c.x + x.x);
					if (abs < c.min)
					{
						min = abs;
					}
				}

				return new { x = x.x, abs = x.abs, isMinus = x.isMinus, min = min };
			});

		return res.min;
	}

	[CodilityFunc]
	public int test1(int[] list)
	{
		var xs = from x in list
				 from y in list
				 select Math.Abs(x + y);

		return xs.Min();
	}
}
