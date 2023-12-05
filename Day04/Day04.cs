using System.Diagnostics;

namespace AoC
{
    public static class Day04
    {
        public static Int64 Day04a(string[] input)
        {
            var sum = 0;
            foreach(var s in input)
            {
                var score = win(s);
                if (score !=0 )
                    sum += 1 << (score-1);
            }
            return sum;
        }

        public static int win(string card)
        {
            var parts = card.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var div = Array.IndexOf(parts, "|");
            var score = 0;
            for (var i = 2; i != div; i++)
            {
                if (parts[(div + 1)..].Contains(parts[i]))
                {
                    score++;
                }
            }
            return score;
        }

        public static Int64 Day04b(string[] input)
        {
            var count = 0;
            var next = new List<int>() { 1 };
            foreach (var s in input)
            {
                var thiscount = next[0];
                count += thiscount;
                next.RemoveAt(0);
                var score = win(s);
                while (next.Count <= score) next.Add(1);
                for (var i = 0;  i < score; i++)
                {
                    next[i]+= thiscount;
                }
            }
            return count;

        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day04.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day04a : {0}   Time: {1}", Day04a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day04b : {0}   Time: {1}", Day04b(lines), sw.ElapsedMilliseconds);
        }
    }
}
