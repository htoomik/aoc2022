using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test09
    {
        [Test]
        public void Example1()
        {
            const string data = @"
R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";
            var input = DataHelper.SplitLines(data);
            var result = new Day09().Solve(input);
            result.ShouldBe(13);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(9);
            var result = new Day09().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new Day09().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day09().Solve2(input);
            Console.WriteLine(result);
        }
    }
}