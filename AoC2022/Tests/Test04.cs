using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test04
    {
        private const string Data = @"
2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";
        
        [Test]
        public void Example1()
        {
            var input = DataHelper.SplitLines(Data);
            var result = new Day04().Solve(input);
            result.ShouldBe(2);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(4);
            var result = new Day04().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            var input = DataHelper.SplitLines(Data);
            var result = new Day04().Solve2(input);
            result.ShouldBe(4);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(4);
            var result = new Day04().Solve2(input);
            Console.WriteLine(result);
        }
    }
}