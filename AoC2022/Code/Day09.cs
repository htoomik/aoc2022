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
            var rope = new Rope();
            var tailPositions = new HashSet<End>();

            foreach (var line in input)
            {
                var direction = line[0];
                var count = int.Parse(line[2..]);

                for (var i = 0; i < count; i++)
                {
                    rope.MoveHead(direction);
                    tailPositions.Add(rope.Tail);
                }
            }

            // Print(tailPositions);
            
            return tailPositions.Count;
        }

        private static void Print(HashSet<End> positions)
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
                    var pos = new End { X = x, Y = y };
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

        public int Solve2(List<string> input)
        {
            return 0;
        }

        private class Rope
        {
            public End Tail;
            public End Head;

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

                if (!Touching())
                {
                    MoveTail();
                }
            }

            private bool Touching()
            {
                var xd = Math.Abs(Head.X - Tail.X);
                var yd = Math.Abs(Head.Y - Tail.Y);
                return xd <= 1 && yd <= 1;
            }

            private void MoveTail()
            {
                if (Head.X == Tail.X)
                {
                    if (Head.Y > Tail.Y)
                    {
                        Tail.Y++;
                    }
                    else if (Head.Y < Tail.Y)
                    {
                        Tail.Y--;
                    }
                }
                else if (Head.X > Tail.X)
                {
                    if (Head.Y == Tail.Y)
                    {
                        Tail.X++;
                    }
                    else if (Head.Y > Tail.Y)
                    {
                        Tail.X++;
                        Tail.Y++;
                    }
                    else if (Head.Y < Tail.Y)
                    {
                        Tail.X++;
                        Tail.Y--;
                    }
                }
                else if (Head.X < Tail.X)
                {
                    if (Head.Y == Tail.Y)
                    {
                        Tail.X--;
                    }
                    else if (Head.Y > Tail.Y)
                    {
                        Tail.X--;
                        Tail.Y++;
                    }
                    else if (Head.Y < Tail.Y)
                    {
                        Tail.X--;
                        Tail.Y--;
                    }
                }
            }
        }

        [DebuggerDisplay("X: {X}, Y: {Y}")]
        private struct End
        {
            public int X;
            public int Y;
        }
    }
}