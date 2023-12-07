using System.Diagnostics;

namespace AoC
{
    public static class Day06
    {
        public static Int64 Day06a(string[] input)
        {
            var time = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(Int64.Parse).ToList();
            var record = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(Int64.Parse).ToList();
            var margin = 1;
            for (int i = 0; i!=time.Count(); ++i)
            {
                var wins = 0;
                for (int t = 1; t <= time[i]; ++t)
                {
                    if ((time[i] - t) * t > record[i]) wins++;
                }
                margin *= wins;
            }
            return margin;
        }

        public static Int64 Day06b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day06.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day06a : {0}   Time: {1}", Day06a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day06b : {0}   Time: {1}", Day06b(lines), sw.ElapsedMilliseconds);
        }
    }
}
