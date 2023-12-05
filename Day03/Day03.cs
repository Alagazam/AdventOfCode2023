using System.Diagnostics;

namespace AoC
{
    public static class Day03
    {
        public static Int64 Day03a(string[] input)
        {
            var sum = 0;

            for (int y = 0; y!=input.Length; ++y)
            {
                var number = 0;
                var ispartnr = false;
                for (int x = 0; x != input[y].Length; ++x)
                {
                    if (Char.IsDigit(input[y][x]))
                    {
                        number = number * 10 + input[y][x] - '0';
                        if (!ispartnr)
                        {
                            ispartnr = CheckAdjacentCells(input, x, y);
                        }
                    }
                    else
                    {
                        if (ispartnr)
                        {
                            sum += number;
                        }
                        number = 0;
                        ispartnr= false;
                    }
                    if (x == input[y].Length-1 && ispartnr)
                    {
                        sum += number;
                    }
                }
            }
            return sum;
        }

        private static bool CheckAdjacent(string[] input, int x, int y)
        {
            try
            {
                if ("0123456789.".Contains(input[y][x])) return false;
                return true;
            }
            catch (IndexOutOfRangeException)
            { }

            return false;
        }

        private static bool CheckAdjacentCells(string[] input, int x, int y)
        {
            return
            CheckAdjacent(input, x - 1, y - 1) ||
            CheckAdjacent(input, x    , y - 1) ||
            CheckAdjacent(input, x + 1, y - 1) ||
            CheckAdjacent(input, x - 1, y    ) ||
            CheckAdjacent(input, x + 1, y    ) ||
            CheckAdjacent(input, x - 1, y + 1) ||
            CheckAdjacent(input, x    , y + 1) ||
            CheckAdjacent(input, x + 1, y + 1);
        }

        private static int GetGearParts(string[] input, int x, int y)
        {
            var first = 0;
            var second = 0;
            for (int dy = -1; dy <= 1; dy++)
            {
                if (y + dy < 0 || y + dy > input.Length) continue;
                for (int dx = -1; dx <= 1; dx++)
                {
                    if (dy == 0 && dx == 0) continue;
                    if (x + dx < 0 || x + dx > input[y + dy].Length) continue;
                    if (!Char.IsDigit(input[y + dy][x + dx])) continue;

                    while (x + dx > 0 && Char.IsDigit(input[y + dy][x + dx - 1])) dx--;
                    var a = 0;
                    while (x + dx < input[y+dy].Length && Char.IsDigit(input[y+dy][x + dx]))
                    {
                        a = a * 10 + input[y+dy][x + dx] - '0';
                        dx++;
                    }
                    if (first == 0)
                    {
                        first = a;
                    }
                    else
                    {
                        second = a;
                        return first * second;
                    }
                }
            }
            return 0;
        }

        public static Int64 Day03b(string[] input)
        {
            var sum = 0;

            for (int y = 0; y != input.Length; ++y)
            {
                for (int x = 0; x != input[y].Length; ++x)
                {
                    if (input[y][x] == '*')
                    {
                        sum += GetGearParts(input, x, y);
                    }
                }
            }
            return sum;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day03.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day03a : {0}   Time: {1}", Day03a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day03b : {0}   Time: {1}", Day03b(lines), sw.ElapsedMilliseconds);
        }
    }
}
