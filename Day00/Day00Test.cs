using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day00Test
    {
        readonly string input =
@"";

        readonly Int64 resultA = 0;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day00a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day00.Day00a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day00a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day00b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day00.Day00b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day00b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day00Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
