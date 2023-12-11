using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day11Test
    {
        readonly string input =
@"...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....
";

        readonly Int64 resultA = 374;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day11a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day11.Day11a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day11a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day11b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day11.Day11b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day11b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day11Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
