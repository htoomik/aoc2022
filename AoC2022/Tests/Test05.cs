using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test05
    {
        private const string Data = @"
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
        
        [Test]
        public void Example1()
        {
            var result = new Day05().Solve(Data);
            result.ShouldBe("CMZ");
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(5);
            var result = new Day05().Solve(input);
            Console.WriteLine(result);
        }

        [Test]
        public void Example2()
        {
            const string data = @"
";
            var input = DataHelper.SplitLines(data);
            var result = new Day05().Solve2(input);
            result.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadLines(0);
            var result = new Day05().Solve2(input);
            Console.WriteLine(result);
        }
    }
}