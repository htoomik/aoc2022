using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;
// ReSharper disable StringLiteralTypo

namespace AoC2022.Tests
{
    public class Test03
    {
        const string Data = @"
vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
        
        [Test]
        public void Example1()
        {
            var input = DataHelper.SplitLines(Data);
            var result = new Day03().Solve(input);
            result.ShouldBe(157);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(3);
            var result = new Day03().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            var input = DataHelper.SplitLines(Data);
            var result = new Day03().Solve2(input);
            result.ShouldBe(70);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(3);
            var result = new Day03().Solve2(input);
            Console.WriteLine(result);
        }
    }
}