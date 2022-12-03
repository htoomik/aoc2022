using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test02
    {
        [Test]
        public void Example1()
        {
            const string data = @"
A Y
B X
C Z";
            var input = DataHelper.SplitLines(data);
            var result = new Day02().Solve(input);
            result.ShouldBe(15);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(2);
            var result = new Day02().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
A Y
B X
C Z";
            var input = DataHelper.SplitLines(data);
            var result = new Day02().Solve2(input);
            result.ShouldBe(12);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(2);
            var result = new Day02().Solve2(input);
            Console.WriteLine(result);
        }
    }
}