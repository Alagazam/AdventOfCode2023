using System.Diagnostics;

using Node = System.Collections.Generic.Dictionary<string, System.Tuple<string, string>>;
namespace AoC
{
    public static class Day08
    {
        
        public static Int64 Day08a(string[] input)
        {
            var node = new Node();
            foreach(var s in input.Skip(1))
            {
                if (s == "") continue;
                var parts = s.Split(' ');
                node[parts[0]] = new Tuple<string, string>( parts[2].Substring(1, 3), parts[3].Substring(0, 3));
            }
            var current = "AAA";
            var steps = 0;
            while (current!="ZZZ")
            {
                foreach(var c in input[0])
                {
                    if (c == 'L') current = node[current].Item1;
                    else current = node[current].Item2;
                    steps++;
                    if (current == "ZZZ") break;
                }
            }
            return steps;
        }

        public static Int64 Day08b(string[] input)
        {
            var node = new Node();
            foreach (var s in input.Skip(1))
            {
                if (s == "") continue;
                var parts = s.Split(' ');
                node[parts[0]] = new Tuple<string, string>(parts[2].Substring(1, 3), parts[3].Substring(0, 3));
            }
            var startnodes = node.Keys.Where(s => s[2]=='A').ToArray();
            var loops = new List<Int64>();
            foreach (var start in startnodes)
            {
                var current = start;
                var steps = 0;
                while (current[2] != 'Z')
                {
                    foreach (var c in input[0])
                    {
                        if (c == 'L') current = node[current].Item1;
                        else current = node[current].Item2;
                        steps++;
                        if (current[2] == 'Z') break;
                    }
                }
                loops.Add(steps);
            }
            return AoC.Utils.LCM(loops);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day08.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day08a : {0}   Time: {1}", Day08a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day08b : {0}   Time: {1}", Day08b(lines), sw.ElapsedMilliseconds);
        }
    }
}
