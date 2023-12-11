using System.Diagnostics;

namespace AoC
{
    public static class Day11
    {
        public static Int64 Day11a(string[] input)
        {
            return GetGalaxyDistanceSum(input);
        }

        public static Int64 GetGalaxyDistanceSum(string[] input, int growth = 2)
        {
            // Find empty rows
            var emptyRows = Enumerable.Range(0, input.Length).Where(i => input[i].IndexOf('#') == -1).ToArray();
            // Find empty columns
            var emptyCols = Enumerable.Range(0, input[0].Length).Where(i => input.All(s => s[i] == '.')).ToArray();

            var galaxies = new List<Tuple<int, int>>();
            foreach (var row in Enumerable.Range(0, input.Length))
            {
                foreach (var col in Enumerable.Range(0, input[row].Length))
                {
                    if (input[row][col] == '#') galaxies.Add(new Tuple<int, int>(row, col));
                }
            }
            Int64 sum = 0;
            foreach (var g1 in Enumerable.Range(0, galaxies.Count - 1))
            {
                foreach (var g2 in Enumerable.Range(g1 + 1, galaxies.Count - g1 - 1))
                {
                    Int64 dist = Math.Abs(galaxies[g1].Item2 - galaxies[g2].Item2) + Math.Abs(galaxies[g1].Item1 - galaxies[g2].Item1);

                    Int64 addRows = emptyRows.Count(r => r > galaxies[g1].Item1 && r < galaxies[g2].Item1 || r > galaxies[g2].Item1 && r < galaxies[g1].Item1);
                    Int64 addCols = emptyCols.Count(c => c > galaxies[g1].Item2 && c < galaxies[g2].Item2 || c > galaxies[g2].Item2 && c < galaxies[g1].Item2);

                    sum += dist + addCols * (growth - 1) + addRows * (growth - 1);
                }
            }

            return sum;
        }

        public static Int64 Day11b(string[] input)
        {
            return GetGalaxyDistanceSum(input, 1000000);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day11.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day11a : {0}   Time: {1}", Day11a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day11b : {0}   Time: {1}", Day11b(lines), sw.ElapsedMilliseconds);
        }
    }
}
