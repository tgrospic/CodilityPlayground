using System;
using System.Collections.Generic;
using System.Linq;

class Test_2
{
	[CodilityFunc]
	public int solution(string S)
	{
		var stack = new Stack<int>();

		Func<int, bool> isStackError = x => stack.Count < x;
		Func<int, bool> isOverflowError = x => x > 1023;

		foreach (var c in S)
		{
			if (char.IsDigit(c))
			{
				var d = int.Parse(c.ToString());
				stack.Push(d);
			}
			else if (c == '+')
			{
				if (isStackError(2)) return -1;
				var l = stack.Pop();
				var r = stack.Pop();
				var op = l + r;
				if (isOverflowError(op)) return -1;
				stack.Push(op);
			}
			else if(c == '*')
			{
				if (isStackError(2)) return -1;
				var l = stack.Pop();
				var r = stack.Pop();
				var op = l * r;
				if (isOverflowError(op)) return -1;
				stack.Push(op);
			}
		}
		if (isStackError(1)) return -1;
		return stack.Pop();
	}
}
