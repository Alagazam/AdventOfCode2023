using System.Diagnostics;

namespace AoC
{
    public static class Day09
    {
        public static Int64 GetNextValue(IReadOnlyList<Int64> array)
        {
            if (array.All(x => x == 0)) { return 0; }
            var next = Enumerable.Range(0, array.Count - 1).Select(i => array[i + 1] - array[i]).ToList();

            return array[array.Count-1] + GetNextValue(next);
        }

        public static Int64 Day09a(string[] input)
        {
            var sum = 0L;
            foreach(string s in input)
            {
                var array = s.Split(' ').Select(v=> Int64.Parse(v)).ToList();
                sum += GetNextValue(array);
            }
            return sum;
        }

        public static Int64 Day09b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day09.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day09a : {0}   Time: {1}", Day09a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day09b : {0}   Time: {1}", Day09b(lines), sw.ElapsedMilliseconds);
        }
    }
}
