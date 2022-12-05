using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Code
{
    public class Day04
    {
        public int Solve(List<string> input)
        {
            var elves = input.Select(Parse);
            var wastedWork = elves.Where(FullyContained).ToList();
            return wastedWork.Count();
        }

        public int Solve2(List<string> input)
        {
            var elves = input.Select(Parse);
            var wastedWork = elves.Where(Overlap).ToList();
            return wastedWork.Count();
        }

        private static (Tuple<int,int> elf1, Tuple<int, int> elf2) Parse(string s)
        {
            var parts = s.Split(',');
            var r1 = parts[0].Split('-');
            var r2 = parts[1].Split('-');
            var elf1 = new Tuple<int, int>(int.Parse(r1[0]), int.Parse(r1[1]));
            var elf2 = new Tuple<int, int>(int.Parse(r2[0]), int.Parse(r2[1]));
            return (elf1, elf2);
        }

        private static bool FullyContained((Tuple<int,int> elf1, Tuple<int, int> elf2) elves)
        {
            var e1 = elves.elf1;
            var e2 = elves.elf2;

            if (e1.Item1 <= e2.Item1 &&
                e2.Item2 <= e1.Item2)
                return true;

            if (e2.Item1 <= e1.Item1 &&
                e1.Item2 <= e2.Item2)
                return true;

            return false;
        }
        
        private static bool Overlap((Tuple<int,int> elf1, Tuple<int, int> elf2) elves)
        {
            var e1 = elves.elf1;
            var e2 = elves.elf2;

            if (e1.Item1 <= e2.Item2 &&
                e2.Item1 <= e1.Item2)
                return true;

            return false;
        }
    }
}