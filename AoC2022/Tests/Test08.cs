using System;
using System.Collections.Generic;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test08
    {
        const string Data = @"
30373
25512
65332
33549
35390";
        
        [Test]
        public void Example1()
        {
            
            var input = DataHelper.SplitLines(Data);
            var result = new Day08().Solve(input);
            result.ShouldBe(21);
        }

        [Test]
        public void Rotate()
        {
            var data = new List<string> { "ab", "cd" };
            var rotated = Day08.Rotate(data);
            rotated.ShouldBeEquivalentTo(new List<string>{"ac", "bd"});
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(8);
            var result = new Day08().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            var input = DataHelper.SplitLines(Data);
            var (r, c, result) = new Day08().Solve2(input);
            r.ShouldBe(3);
            c.ShouldBe(2);
            result.ShouldBe(8);
        }

        [Test]
        public void Score()
        {
            var input = DataHelper.SplitLines(Data);
            var result = new Day08().Score(input, Day08.Rotate(input), 1, 2);
            result.ShouldBe(4);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(8);
            var result = new Day08().Solve2(input);
            Console.WriteLine(result);
        }
    }
}