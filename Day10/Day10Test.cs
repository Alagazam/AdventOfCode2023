using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day10Test
    {
        readonly string input1 =
@".....
.S-7.
.|.|.
.L-J.
.....
";
        readonly string input2 =
@"-L|F7
7S-7|
L|7||
-L-J|
L|-JF
";
        readonly string input3 =
@"..F7.
.FJ|.
SJ.L7
|F--J
LJ...
";
        readonly string input4 =
@"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ
";

        readonly Int64 resultA1 = 4;
        readonly Int64 resultA2 = 4;
        readonly Int64 resultA3 = 8;
        readonly Int64 resultA4 = 8;

        [Fact]
        public void Day10a1()
        {
            var sw = Stopwatch.StartNew();
            var lines = input1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = Day10.Day10a(lines);
            Assert.Equal(resultA1, result);
            Console.WriteLine("Day10a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }
        [Fact]
        public void Day10a2()
        {
            var sw = Stopwatch.StartNew();
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = Day10.Day10a(lines);
            Assert.Equal(resultA2, result);
            Console.WriteLine("Day10a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }
        [Fact]
        public void Day10a3()
        {
            var sw = Stopwatch.StartNew();
            var lines = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = Day10.Day10a(lines);
            Assert.Equal(resultA3, result);
            Console.WriteLine("Day10a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }
        [Fact]
        public void Day10a4()
        {
            var sw = Stopwatch.StartNew();
            var lines = input4.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = Day10.Day10a(lines);
            Assert.Equal(resultA4, result);

            Console.WriteLine("Day10a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        readonly string input5 =
@"...........
.S-------7.
.|F-----7|.
.||.....||.
.||.....||.
.|L-7.F-J|.
.|..|.|..|.
.L--J.L--J.
...........
";
        readonly Int64 resultB5 = 4;

        [Fact]
        public void Day10b5()
        {
            var sw = Stopwatch.StartNew();
            var lines = input5.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day10.Day10b(lines);
            Assert.Equal(resultB5, result);

            Console.WriteLine("Day10b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        readonly string input6 =
@"..........
.S------7.
.|F----7|.
.||....||.
.||....||.
.|L-7F-J|.
.|..||..|.
.L--JL--J.
..........
";
        readonly Int64 resultB6 = 4;


        [Fact]
        public void Day10b6()
        {
            var sw = Stopwatch.StartNew();
            var lines = input6.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day10.Day10b(lines);
            Assert.Equal(resultB6, result);

            Console.WriteLine("Day10b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        readonly string input7 =
@"FF7FSF7F7F7F7F7F---7
L|LJ||||||||||||F--J
FL-7LJLJ||||||LJL-77
F--JF--7||LJLJ7F7FJ-
L---JF-JLJ.||-FJLJJ7
|F|F-JF---7F7-L7L|7|
|FFJF7L7F-JF7|JL---7
7-L-JL7||F7|L7F-7F7|
L.L7LFJ|||||FJL7||LJ
L7JLJL-JLJLJL--JLJ.L
";
        readonly Int64 resultB7 = 10;


        [Fact]
        public void Day10b7()
        {
            var sw = Stopwatch.StartNew();
            var lines = input7.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day10.Day10b(lines);
            Assert.Equal(resultB7, result);

            Console.WriteLine("Day10b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }



        public Day10Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
