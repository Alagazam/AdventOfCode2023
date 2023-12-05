using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day03Test
    {
        readonly string input =
@"467..114.
...*.....
..35..633
......#..
617*.....
.....+.58
..592....
......755
...$.*...
.664.598.";

        readonly Int64 resultA = 4361;
        readonly Int64 resultB = 467835;

        [Fact]
        public void Day03a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day03.Day03a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day03a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day03b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day03.Day03b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day03b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day03Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
