using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Code
{
    public class Day03
    {
        private const string AllChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public int Solve(List<string> input)
        {
            return input.Select(Score).Sum();
        }

        public int Solve2(List<string> input)
        {
            var groups = Partition(input, 3);
            return groups.Select(FindBadge).Select(Score).Sum();
        }

        private static int Score(string bag)
        {
            var length = bag.Length / 2;
            var comp1 = bag[0..length].ToCharArray();
            var comp2 = bag[length..].ToCharArray();
            var inBoth = comp1.Intersect(comp2).Single();
            return Score(inBoth);
        }

        private static char FindBadge(IEnumerable<string> group)
        {
            foreach (var c in AllChars)
            {
                if (group.All(g => g.Contains(c)))
                {
                    return c;
                }
            }

            throw new Exception("No badge found");
        }

        private static int Score(char c)
        {
            return AllChars.IndexOf(c) + 1;
        }

        private static IEnumerable<IEnumerable<T>> Partition<T>(IEnumerable<T> values, int chunkSize)
        {
            while (values.Any())
            {
                yield return values.Take(chunkSize).ToList();
                values = values.Skip(chunkSize).ToList();
            }
        }
    }
}