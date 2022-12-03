using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Code
{
    public class Day01
    {
        public int Solve1(string input)
        {
            input = input.Trim().Replace("\r", "");
            var chunks = input.Split("\n\n");
            return chunks.Select(c => c.Split("\n").Select(int.Parse).Sum()).Max();
        }

        public int Solve2(string input)
        {
            input = input.Trim().Replace("\r", "");
            var chunks = input.Split("\n\n");
            return chunks.Select(c => c.Split("\n").Select(int.Parse).Sum()).OrderByDescending(i => i).Take(3).Sum();
        }
    }
}