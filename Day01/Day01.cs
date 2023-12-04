using System.Diagnostics;

namespace AoC
{
    public static class Day01
    {
        public static Int64 Day01a(string[] input)
        {
            var sum = 0;
            foreach (string s in input)
            {
                if (s.Length != 0)
                {
                    var digits = s.Where(c => Char.IsDigit(c));
                    var first = digits.First() - '0';
                    var last = digits.Last() - '0';
                    sum += first * 10 + last;
                }
            }
            return sum;
        }

        public static Int64 Day01b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day01.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day01a : {0}   Time: {1}", Day01a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day01b : {0}   Time: {1}", Day01b(lines), sw.ElapsedMilliseconds);
        }
    }
}
