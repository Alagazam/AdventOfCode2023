using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day08Test
    {
        readonly string input1 =
@"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)
";

        readonly string input2 =
@"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)
";

        readonly string input3 =
@"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)
";

        readonly Int64 resultA1 = 2;
        readonly Int64 resultA2 = 6;
        readonly Int64 resultB = 6;

        [Fact]
        public void Day08a1()
        {
            var sw = Stopwatch.StartNew();
            var lines = input1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day08.Day08a(lines);
            Assert.Equal(resultA1, result);

            Console.WriteLine("Day08a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }
        [Fact]
        public void Day08a2()
        {
            var sw = Stopwatch.StartNew();
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day08.Day08a(lines);
            Assert.Equal(resultA2, result);

            Console.WriteLine("Day08a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day08b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day08.Day08b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day08b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day08Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
