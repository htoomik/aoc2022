using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test07
    {
        const string Data = @"
$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

        [Test]
        public void GetSize()
        {
            var input = DataHelper.SplitLines(Data);
            var top = Day07.Parse(input);
            var size = top.CalculateSize();
            size.ShouldBe(48381165);
        } 
        
        [Test]
        public void Example1()
        {
            var input = DataHelper.SplitLines(Data);
            var result = new Day07().Solve(input);
            
            result.ShouldBe(95437);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(7);
            var result = new Day07().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            var input = DataHelper.SplitLines(Data);
            var result = new Day07().Solve2(input);
            result.ShouldBe(24933642);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(7);
            var result = new Day07().Solve2(input);
            Console.WriteLine(result);
        }
    }
}