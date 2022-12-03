using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    [TestFixture]
    public class Test01
    {
        private const string Data = @"
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
        
        [Test]
        public void Example1()
        {
            var result = new Day01().Solve1(Data);
            result.ShouldBe(24000);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(1);
            var result = new Day01().Solve1(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            var result = new Day01().Solve2(Data);
            result.ShouldBe(45000);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(1);
            var result = new Day01().Solve2(input);
            Console.WriteLine(result);
        }
    }
}