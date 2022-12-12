using System;
using System.Linq;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test10
    {
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 4)]
        [TestCase(5, 4)]
        [TestCase(6, -1)]
        public void Example1A(int cycle, int expected)
        {
            var data = @"
noop
addx 3
addx -5";
            var input = DataHelper.SplitLines(data);
            var result = new Day10(input).Process()[cycle - 1];
            result.ShouldBe(expected);
        }
        
        [Test]
        public void Example1()
        {
            var input = DataHelper.ReadLines("example10.txt");
            var result = new Day10(input).Solve();
            result.ShouldBe(13140);
        }
        
        [TestCase(20, 420)]
        [TestCase(60, 1140)]
        [TestCase(100, 1800)]
        [TestCase(140, 2940)]
        [TestCase(180, 2880)]
        [TestCase(220, 3960)]
        public void Example1Parts(int cycle, int expected)
        {
            var input = DataHelper.ReadLines("example10.txt");
            var result = new Day10(input).GetSignalStrength(cycle);
            result.ShouldBe(expected);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadLines(10);
            var result = new Day10(input).Solve();
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string expected = @"
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....";
            var input = DataHelper.ReadLines("example10.txt");
            var result = new Day10(input).Solve2();
            result.ShouldBe(expected.Trim());
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(10);
            var result = new Day10(input).Solve2();
            Console.WriteLine(result);
        }
    }
}