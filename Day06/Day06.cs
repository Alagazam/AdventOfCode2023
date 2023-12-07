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
            var time = input[0].Replace(" ","").Split(':').Skip(1).Select(Int64.Parse).ToList()[0];
            var record = input[1].Replace(" ", "").Split(':').Skip(1).Select(Int64.Parse).ToList()[0];

            var root1 = (time + Math.Sqrt(time * time - 4 * record))/2;
            var root2 = (time - Math.Sqrt(time * time - 4 * record))/2;

            return (Int64)Math.Abs(root1 - root2);
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
