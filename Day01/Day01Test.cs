using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day01Test
    {
        readonly string inputA =
@"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet
";

        readonly string inputB =
@"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen
";
        readonly Int64 resultA = 142;
        readonly Int64 resultB = 281;

        [Fact]
        public void Day01a()
        {
            var sw = Stopwatch.StartNew();
            var lines = inputA.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day01.Day01a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day01a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day01b()
        {
            var sw = Stopwatch.StartNew();
            var lines = inputB.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day01.Day01b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day01b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day01Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
