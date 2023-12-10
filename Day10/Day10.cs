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

        public static int GetLength(char[][] input, Point point, Point dir, bool markPath = false)
        {
            var length = 0;
            while (true)
            {
                point = new Point(point.Item1 + dir.Item1, point.Item2 + dir.Item2);
                if (point.Item1 < 0 || point.Item1 >= input.Length ||
                    point.Item2 < 0 || point.Item2 >= input[point.Item1].Length) return -1;
                var p = input[point.Item1][point.Item2];
                if (markPath) input[point.Item1][point.Item2] = 'X';
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
            var in_copy = input.Select(s => s.ToArray()).ToArray();
            var start = GetStart(input);
            var length = 0;
            length = GetLength(in_copy, start, new Point(-1, 0));
            if (length > 0) return length/2;
            length = GetLength(in_copy, start, new Point(1, 0));
            if (length > 0) return length/2;
            length = GetLength(in_copy, start, new Point(0, -1));
            if (length > 0) return length/2;
            length = GetLength(in_copy, start, new Point(0, 1));
            if (length > 0) return length/2;

            return 0;
        }

        public static Int64 Day10b(string[] input)
        {
            var start = GetStart(input);
            var length = 0;
            var in_copy = new char[input.Length][];
            in_copy = input.Select(s => s.ToArray()).ToArray();

            length = GetLength(in_copy, start, new Point(-1, 0), true);
            if (length < 0)
            {
                in_copy = input.Select(s => s.ToArray()).ToArray();
                length = GetLength(in_copy, start, new Point(1, 0), true);
                if (length < 0)
                {
                    in_copy = input.Select(s => s.ToArray()).ToArray();
                    length = GetLength(in_copy, start, new Point(0, -1), true);
                    if (length < 0)
                    {
                        in_copy = input.Select(s => s.ToArray()).ToArray();
                        length = GetLength(in_copy, start, new Point(0, 1), true);
                        if (length < 0)
                        {
                            return 0;
                        }
                    }
                }
            };
            var incells = 0;
            for (var r = 0; r != input.Length; r++)
            {
                bool inside = false;
                char lastcorner = '.';
                for (var c = 0; c != input[0].Length; c++)
                {
                    if (in_copy[r][c] == 'X')
                    {
                        if (input[r][c] == '|') inside = !inside;
                        else if (input[r][c] == 'L' || input[r][c] == 'F') lastcorner = input[r][c];
                        else if (input[r][c] == 'J' && lastcorner == 'F' ||
                            input[r][c] == '7' && lastcorner == 'L')
                        {
                            inside = !inside;
                            lastcorner = '.';
                        }
                    }
                    else if (inside)
                    {
                        incells++;
                        lastcorner = '.';
                    }
                }
            }

            return incells;
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
