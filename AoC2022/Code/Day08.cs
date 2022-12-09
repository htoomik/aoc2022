using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Code
{
    public class Day08
    {
        public int Solve(List<string> input)
        {
            var rotated = Rotate(input);
            var visibleCount = 0;
            var map = new List<string>();
            for (var r = 0; r < input.Count; r++)
            {
                var row = string.Empty;
                for (var c = 0; c < input[0].Length; c++)
                {
                    var visible = IsVisible(input, rotated, r, c);
                    if (visible)
                    {
                        visibleCount++;
                        row += "T";
                    }
                    else
                    {
                        row += ".";
                    }
                }
                map.Add(row);
            }

            // Print(map);

            return visibleCount;
        }

        public static List<string> Rotate(List<string> input)
        {
            return input.Select((t, i) => string.Join("", input.Select(s => s[i]))).ToList();
        }

        private static bool IsVisible(List<string> input, List<string> rotated, int r, int c)
        {
            var target = input[r][c];
            if (r == 0 || c == 0 || r == input.Count - 1 || c == input.Count - 1)
                return true;
            if (input[r].Take(c).All(t => t < target))
                return true;
            if (input[r].Skip(c + 1).All(t => t < target))
                return true;
            if (rotated[c].Take(r).All(t => t < target))
                return true;
            if (rotated[c].Skip(r + 1).All(t => t < target))
                return true;
            return false;
        }

        private static void Print(List<string> input)
        {
            foreach (var line in input)
            {
                Console.WriteLine(line);
            }
        }

        public (int r, int c, int score) Solve2(List<string> input)
        {
            var rotated = Rotate(input);
            var bestScore = (0, 0, 0);
            for (var r = 0; r < input.Count; r++)
            {
                var row = string.Empty;
                for (var c = 0; c < input[0].Length; c++)
                {
                    var score = Score(input, rotated, r, c);
                    if (score > bestScore.Item3)
                    {
                        bestScore = (r, c, score);
                    }
                }
            }
            return bestScore;
        }

        public int Score(List<string> input, List<string> rotated, int r, int c)
        {
            var target = input[r][c];
            
            var right = 0;
            for (var i = c + 1; i < input.Count; i++)
            {
                right++;
                if (input[r][i] >= target)
                    break;
            }

            var left = 0;
            for (var i = c - 1; i >= 0; i--)
            {
                left++;
                if (input[r][i] >= target)
                    break;
            }

            var up = 0;
            for (var i = r - 1; i >= 0; i--)
            {
                up++;
                if (input[i][c] >= target)
                    break;
            }

            var down = 0;
            for (var i = r + 1; i < input.Count; i++)
            {
                down++;
                if (input[i][c] >= target)
                    break;
            }

            return up * down * left * right;
        }
    }
}