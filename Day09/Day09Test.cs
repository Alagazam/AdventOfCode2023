using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day09Test
    {
        readonly string input =
@"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45
";

        readonly Int64 resultA = 114;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day09a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day09.Day09a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day09a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day09b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day09.Day09b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day09b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day09Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
