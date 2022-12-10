using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test09
    {
        const string Data = @"
R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";
        
        [Test]
        public void Example1()
        {
            
            var input = DataHelper.SplitLines(Data);
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
            var input = DataHelper.SplitLines(Data);
            var result = new Day09().Solve2(input);
            result.ShouldBe(1);
        }

        [Test]
        public void Example2B()
        {
            var data = @"
R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20";
            var input = DataHelper.SplitLines(data);
            var result = new Day09().Solve2(input);
            result.ShouldBe(36);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(9);
            var result = new Day09().Solve2(input);
            Console.WriteLine(result);
        }
    }
}