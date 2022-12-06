using System;
using AoC2022.Code;
using AoC2022.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AoC2022.Tests
{
    public class Test06
    {
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void Example1(string input, int expected)
        {
            var result = new Day06().Solve(input);
            result.ShouldBe(expected);
        }

        [Test]
        public void Part1()
        {
            var input = DataHelper.ReadFile(6);
            var result = new Day06().Solve(input);
            Console.WriteLine(result);
        }

        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void Example2(string input, int expected)
        {
            var result = new Day06().Solve2(input);
            result.ShouldBe(expected);
        }

        [Test]
        public void Part2()
        {
            var input = DataHelper.ReadFile(6);
            var result = new Day06().Solve2(input);
            Console.WriteLine(result);
        }
    }
}