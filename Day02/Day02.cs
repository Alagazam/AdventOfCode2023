using System.Diagnostics;

namespace AoC
{
    public static class Day02
    {
        public static Int64 Day02a(string[] input)
        {
            var sum = 0;
            foreach (var s in input)
            {
                var tokens = s.Split(' ');
                var game = int.Parse(tokens[1].Substring(0, tokens[1].Length-1));
                var valid = true;
                for (int i = 2;  i < tokens.Length; i+=2)
                {
                    var n = int.Parse(tokens[i]);
                    var col = tokens[i + 1][0];
                    if (col == 'r' && n > 12) { valid = false; break; }
                    if (col == 'g' && n > 13) { valid = false; break; }
                    if (col == 'b' && n > 14) { valid = false; break; }

                }
                if (valid) sum += game;
            }
            return sum;
        }

        public static Int64 Day02b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day02.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day02a : {0}   Time: {1}", Day02a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day02b : {0}   Time: {1}", Day02b(lines), sw.ElapsedMilliseconds);
        }
    }
}
