using System;
using System.Collections.Generic;
using System.Linq;
using AoC2022.Helpers;

namespace AoC2022.Code
{
    public class Day05
    {
        // Stacks are viewed from top - topmost item comes first
        
        public string Solve(string input)
        {
            var parts = input.Replace("\r\n", "\n").Split("\n\n");

            var stacks = ParseStacks(parts[0]);
            var instructions = ParseInstructions(parts[1]);

            var final = Apply(stacks, instructions);

            return string.Join("", final.Skip(1).Select(l => l.First()));
        }

        public int Solve2(List<string> input)
        {
            return 0;
        }

        private static List<List<char>> Apply(List<List<char>> stacks, List<Instruction> instructions)
        {
            return stacks;
        }

        private static List<List<char>> ParseStacks(string input)
        {
            var lines = input.Split("\n");
            var stackCount = int.Parse(lines.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());
            var stacks = new List<List<char>>();
            for (int i = 0; i <= stackCount; i++)
            {
                stacks.Add(new List<char>());
            }

            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            
            foreach (var line in lines)
            {
                if (line.Contains('['))
                {
                    var s = 1;
                    for (int i = 1; i <= line.Length; i+=4)
                    {
                        var c = line[i];
                        
                        if (alphabet.Contains(c))
                        {
                            stacks[s].Add(c);
                        }
                        
                        s++;
                    }
                }
            }

            return stacks;
        }

        private static List<Instruction> ParseInstructions(string input)
        {
            var lines = DataHelper.SplitLines(input);
            return lines.Select(Instruction.Parse).ToList();
        }
        

        private struct Instruction
        {
            public int From;
            public int To;
            public int Count;

            public static Instruction Parse(string s)
            {
                var parts = s.Split(' ');
                var from = int.Parse(parts[1]);
                var to = int.Parse(parts[3]);
                var count = int.Parse(parts[5]);

                return new Instruction { From = from, To = to, Count = count };
            }
        }
    }
}