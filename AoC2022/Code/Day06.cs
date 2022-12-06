using System.Linq;

namespace AoC2022.Code
{
    public class Day06
    {
        public int Solve(string input)
        {
            return SolveInner(input, 4);
        }

        public int Solve2(string input)
        {
            return SolveInner(input, 14);
        }

        private static int SolveInner(string input, int n)
        {
            for (int i = 0; i < input.Length - n + 1; i++)
            {
                var sub = input.Substring(i, n);
                var ary = sub.ToCharArray();
                var distinct = ary.Distinct().Count();

                if (distinct == n)
                    return i + n;
            }

            return 0;
        }
    }
}