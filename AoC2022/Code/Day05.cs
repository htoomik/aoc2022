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

        public string Solve2(string input)
        {
            var parts = input.Replace("\r\n", "\n").Split("\n\n");

            var stacks = ParseStacks(parts[0]);
            var instructions = ParseInstructions(parts[1]);

            var final = Apply2(stacks, instructions);

            return string.Join("", final.Skip(1).Select(l => l.First()));
        }

        private static List<List<char>> Apply(List<List<char>> stacks, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                var fromStack = stacks[instruction.From];
                var toStack = stacks[instruction.To];
                
                for (int i = 0; i < instruction.Count; i++)
                {
                    var crate = fromStack.First();
                    fromStack.RemoveAt(0);
                    toStack.Insert(0, crate);
                }
            }
            return stacks;
        }

        private static List<List<char>> Apply2(List<List<char>> stacks, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                var fromStack = stacks[instruction.From];
                var toStack = stacks[instruction.To];

                var crates = fromStack.Take(instruction.Count).ToList();
                fromStack.RemoveRange(0, instruction.Count);
                toStack.InsertRange(0, crates);
            }
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
                var count = int.Parse(parts[1]);
                var from = int.Parse(parts[3]);
                var to = int.Parse(parts[5]);

                return new Instruction { From = from, To = to, Count = count };
            }
        }
    }
}