using System;
using System.Linq;

namespace CodilityTest
{
	class Program
	{
		static void Main(string[] args)
		{
			// Test 1
			Codility.Run<Test_1>(() => new object[] { new[] { 1, 2, 5, 9, 9 }, 5 });
			Codility.Run<Test_1>(() => new object[] { Codility.RandomInts(2000000, -2000000).OrderBy(x => x).ToArray(), 34234 });

			// Test 2
			Codility.Run<Test_2>(() => new object[] { "13+62*7+*" });
			Codility.Run<Test_2>(() => new object[] { "11++" });
			Codility.Run<Test_2>(() => new object[] { "11+9*9*9*9*9*9*678" });
			
			// Test 3
			Codility.Run<Test_3>(() => new object[] { 6, new[] { 3, 4, 3, 3 } });
			Codility.Run<Test_3>(() => new object[] { 6, new[] { 1, 8, -3, 0, 1, 3, -2, 4, 5, 3 } });
			Codility.Run<Test_3>(() => new object[] { 6, new[] { 1, 8, -3, 0, 1, 3, -2, 4, 5 } });
			Codility.Run<Test_3>(() => new object[] { Codility.RandomInts(10000).First(), Codility.RandomInts(10000, -10000) });

			#region Codility lessons

			Codility.Run<TapeEquilibrium>(() => new object[] { Codility.RandomInts(10000) });
			
			Codility.Run<MinAbsSumOfTwo>(() => new object[] { Codility.RandomInts(1000) });
			
			Codility.Run<FrogJmp>(() => new object[] { 1, 1000000000, 23 });
			
			Codility.Run<PermMissingElem>(() => new object[] { Codility.RandomUniqueInts(1000000, 1).Skip(1).ToArray() });
	
			Codility.Run<MaxCounters>(() => new object[] { 5, new[] { 3, 4, 4, 6, 1, 4, 4 } });
			Codility.Run<MaxCounters>(() => new object[] { 100000, Codility.RandomInts(100000) });

			Codility.Run<GenomicRangeQuery>(() => new object[] { "CAGCCTA", new[] { 2, 5, 0 }, new[] { 4, 5, 6 } });
			Codility.Run<GenomicRangeQuery>(GenomicRangeQuery.GenomicRangeQueryArgs);

			Codility.Run<EquilibriumIndex>(() => new object[] { new[] { -7, 1, 5, 2, -4, 3, 0 } });
			Codility.Run<EquilibriumIndex>(() => new object[] { Codility.RandomInts(10, -10) });

			#endregion
		}
	}
}
