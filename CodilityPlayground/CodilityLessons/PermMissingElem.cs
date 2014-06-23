using System;
using System.Collections.Generic;
using System.Linq;

class PermMissingElem
{
	[CodilityFunc]
	public int solution(int[] A)
	{
		var sorted = A.OrderBy(x => x);

		var idx = 1;
		foreach (var x in sorted)
		{
			if (x != idx)
			{
				break;
			}
			idx++;
		}
		return idx;
	}

	[CodilityFunc]
	public int test1(int[] list)
	{
		var sorted = list.OrderBy(x => x);

		var h = sorted.First();
		var fst = new { x = h, idx = 1, missing = h != 1 };

		var result = sorted.Select((x, i) => new { x, idx = i + 1 });

		return result.Where(x => x.x != x.idx).Select(x => x.idx).First();
	}
}
