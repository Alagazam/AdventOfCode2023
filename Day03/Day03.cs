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

        public static Int64 Day03b(string[] input)
        {
            return 0;
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
