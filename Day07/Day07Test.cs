using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day07Test
    {
        readonly string input =
@"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483
";

        readonly Int64 resultA = 6440;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day07a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day07.Day07a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day07a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day07b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day07.Day07b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day07b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        [Fact]
        public void TestCompareHand()
        {
            var comp = new Day07.HandCompare();
            Assert.Equal(0, comp.Compare(new Day07.Hand("QQQQQ 1"), new Day07.Hand("QQQQQ 1")));
            Assert.Equal(0, comp.Compare(new Day07.Hand("23456 1"), new Day07.Hand("23456 1")));

            Assert.Equal(-1, comp.Compare(new Day07.Hand("QQQQQ 1"), new Day07.Hand("AAAAA 1")));
            Assert.Equal(-1, comp.Compare(new Day07.Hand("23456 1"), new Day07.Hand("37456 1")));

            Assert.Equal(1, comp.Compare(new Day07.Hand("KK677 1"), new Day07.Hand("KTJJT 1")));
            Assert.Equal(-1, comp.Compare(new Day07.Hand("T55J5 1"), new Day07.Hand("QQQJA 1")));
        }

        public Day07Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
