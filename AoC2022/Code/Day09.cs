using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC2022.Code
{
    public class Day09
    {
        public int Solve(List<string> input)
        {
            return SolveInner(input, 2);
        }

        public int Solve2(List<string> input)
        {
            return SolveInner(input, 10);
        }

        private static int SolveInner(List<string> input, int knots)
        {
            var rope = new Rope(knots);
            var tailPositions = new HashSet<(int, int)>();

            foreach (var line in input)
            {
                var direction = line[0];
                var count = int.Parse(line[2..]);

                for (var i = 0; i < count; i++)
                {
                    rope.MoveHead(direction);
                    tailPositions.Add((rope.Tail.X, rope.Tail.Y));
                }
            }

            // Print(tailPositions);

            return tailPositions.Count;
        }

        private static void Print(HashSet<Knot> positions)
        {
            var minX = positions.Select(p => p.X).Min();
            var minY = positions.Select(p => p.Y).Min();
            var maxX = positions.Select(p => p.X).Max();
            var maxY = positions.Select(p => p.Y).Max();

            for (int y = maxY; y >= minY; y--)
            {
                var line = string.Empty;
                for (int x = minX; x <= maxX; x++)
                {
                    var pos = new Knot { X = x, Y = y };
                    if (x == 0 && y == 0)
                    {
                        line += "s";
                    }
                    else if (positions.Contains(pos))
                    {
                        line += "#";
                    }
                    else
                    {
                        line += ".";
                    }
                }
                Console.WriteLine(line);
            }
        }

        private class Rope
        {
            public readonly List<Knot> Knots = new();
            public Knot Head => Knots[0];
            public Knot Tail => Knots.Last();

            public Rope(int knots)
            {
                for (var i = 0; i < knots; i++)
                {
                    Knots.Add(new Knot());
                }
            }

            public void MoveHead(char direction)
            {
                switch (direction)
                {
                    case 'R':
                        Head.X++;
                        break;
                    case 'L':
                        Head.X--;
                        break;
                    case 'U':
                        Head.Y++;
                        break;
                    case 'D':
                        Head.Y--;
                        break;
                }

                for (int i = 0; i < Knots.Count - 1; i++)
                {
                    if (!Touching(Knots[i], Knots[i + 1]))
                    {
                        MoveTail(Knots[i], Knots[i + 1]);
                    }
                }
            }

            private static bool Touching(Knot head, Knot tail)
            {
                var xd = Math.Abs(head.X - tail.X);
                var yd = Math.Abs(head.Y - tail.Y);
                return xd <= 1 && yd <= 1;
            }

            private static void MoveTail(Knot head, Knot tail)
            {
                if (head.X == tail.X)
                {
                    if (head.Y > tail.Y)
                    {
                        tail.Y++;
                    }
                    else if (head.Y < tail.Y)
                    {
                        tail.Y--;
                    }
                }
                else if (head.X > tail.X)
                {
                    if (head.Y == tail.Y)
                    {
                        tail.X++;
                    }
                    else if (head.Y > tail.Y)
                    {
                        tail.X++;
                        tail.Y++;
                    }
                    else if (head.Y < tail.Y)
                    {
                        tail.X++;
                        tail.Y--;
                    }
                }
                else if (head.X < tail.X)
                {
                    if (head.Y == tail.Y)
                    {
                        tail.X--;
                    }
                    else if (head.Y > tail.Y)
                    {
                        tail.X--;
                        tail.Y++;
                    }
                    else if (head.Y < tail.Y)
                    {
                        tail.X--;
                        tail.Y--;
                    }
                }
            }
        }

        [DebuggerDisplay("X: {X}, Y: {Y}")]
        private class Knot
        {
            public int X;
            public int Y;
        }
    }
}