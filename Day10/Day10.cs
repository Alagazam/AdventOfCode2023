using System.Diagnostics;

using Point = System.Tuple<int, int>;

namespace AoC
{
    public static class Day10
    {
        public static Point GetStart(string[] input)
        {
            var r = 0;
            foreach (var s in input)
            {
                var c = s.IndexOf('S');
                if (c >= 0) return new Point(r, c);
                ++r;
            }
            return new Point(-1, -1);
        }

        public static int GetLength(string[] input, Point point, Point dir)
        {
            var length = 0;
            while (true)
            {
                point = new Point(point.Item1 + dir.Item1, point.Item2 + dir.Item2);
                var p = input[point.Item1][point.Item2];
                ++length;
                if (p == 'S') return length;
                if (p == '.') return -1;

                if (dir.Item1 == -1 && (p == '|' || p == '7' || p == 'F'))
                {
                    switch (p)
                    {
                        case '|': break;
                        case '7': dir = new Point(0, -1); break;
                        case 'F': dir = new Point(0, 1); break;
                    }
                }
                else if (dir.Item1 == 1 && (p == '|' || p == 'J' || p == 'L'))
                {
                    switch (p)
                    {
                        case '|': break;
                        case 'J': dir = new Point(0, -1); break;
                        case 'L': dir = new Point(0, 1); break;
                    }
                }
                else if (dir.Item2 == -1 && (p == '-' || p == 'L' || p == 'F'))
                {
                    switch (p)
                    {
                        case '-': break;
                        case 'L': dir = new Point(-1, 0); break;
                        case 'F': dir = new Point(1, 0); break;
                    }
                }
                else if (dir.Item2 == 1 && (p == '-' || p == '7' || p == 'J'))
                {
                    switch (p)
                    {
                        case '-': break;
                        case 'J': dir = new Point(-1, 0); break;
                        case '7': dir = new Point(1, 0); break;
                    }
                }
                else
                    return -1;
            }
        }

        public static Int64 Day10a(string[] input)
        {
            var start = GetStart(input);
            var length = 0;
            length = GetLength(input, start, new Point(-1, 0));
            if (length > 0) return length/2;
            length = GetLength(input, start, new Point(1, 0));
            if (length > 0) return length/2;
            length = GetLength(input, start, new Point(0, -1));
            if (length > 0) return length/2;
            length = GetLength(input, start, new Point(0, 1));
            if (length > 0) return length/2;

            return 0;
        }

        public static Int64 Day10b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day10.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day10a : {0}   Time: {1}", Day10a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day10b : {0}   Time: {1}", Day10b(lines), sw.ElapsedMilliseconds);
        }
    }
}
