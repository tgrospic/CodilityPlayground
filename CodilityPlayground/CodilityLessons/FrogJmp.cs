using System;
using System.Collections.Generic;
using System.Linq;

class FrogJmp
{
	[CodilityFunc]
	public int solution(int X, int Y, int D)
	{
		return (int)Math.Ceiling((Y - X) / (double)D);
	}

	[CodilityFunc]
	public int test1(int X, int Y, int D)
	{
		var jump = 0;
		while (true)
		{
			if (X >= Y)
			{
				return jump;
			}
			X += D;
			jump++;
		}
	}
}
