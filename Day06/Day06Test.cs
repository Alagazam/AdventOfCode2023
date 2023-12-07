using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day06Test
    {
        readonly string input =
@"Time:      7  15   30
Distance:  9  40  200
";

        readonly Int64 resultA = 288;
        readonly Int64 resultB = 71503;

        [Fact]
        public void Day06a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day06.Day06a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day06a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day06b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day06.Day06b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day06b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day06Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
