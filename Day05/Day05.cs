using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.Diagnostics;

namespace AoC
{
    public static class Day05
    {
        public static IEnumerable<Int64> seeds = new List<Int64>();

        public struct Map { public Int64 dest; public Int64 src; public Int64 count; };

        public static List<Map> seedToSoil = new List<Map> { };
        public static List<Map> soilToFertilizer = new List<Map> { };
        public static List<Map> fertilizerToWater = new List<Map> { };
        public static List<Map> waterToLight = new List<Map> { };
        public static List<Map> lightToTemperature = new List<Map> { };
        public static List<Map> temperatureToHumidity = new List<Map> { };
        public static List<Map> humidityToLocation = new List<Map> { };

        public static Int64 DoMap(Int64 item, List<Map> list)
        {
            var result = item;
            foreach (Map map in list)
            {
                if (item >= map.src && item < map.src + map.count) result = map.dest + (item - map.src);
            }
            return result;
        }

        public static Int64 Day05a(string[] input)
        {
            List<Map> currentMap = new List<Map>();
            foreach (string s in input)
            {
                if (s.Length == 0) continue;
                if (s.StartsWith("seeds:"))
                {
                    seeds = s.Split(' ').Skip(1).Select(Int64.Parse);
                    continue;
                }
                if (s.Contains("map:"))
                {
                    switch (s.Split(" ")[0])
                    {
                        case "seed-to-soil": currentMap = seedToSoil; break;
                        case "soil-to-fertilizer": currentMap = soilToFertilizer; break;
                        case "fertilizer-to-water": currentMap = fertilizerToWater; break;
                        case "water-to-light": currentMap = waterToLight; break;
                        case "light-to-temperature": currentMap = lightToTemperature; break;
                        case "temperature-to-humidity": currentMap = temperatureToHumidity; break;
                        case "humidity-to-location": currentMap = humidityToLocation; break;
                    }
                    continue;
                }
                var numbers = s.Split(' ').Select(Int64.Parse).ToList();
                currentMap.Add(new Map { dest = numbers[0], src = numbers[1], count = numbers[2] });
            }

            var minLoc = Int64.MaxValue;
            foreach (var seed in seeds)
            {
                var soil = DoMap(seed, seedToSoil);
                var fertilizer = DoMap(soil, soilToFertilizer);
                var water = DoMap(fertilizer, fertilizerToWater);
                var light = DoMap(water, waterToLight);
                var temperature = DoMap(light, lightToTemperature);
                var humidity = DoMap(temperature, temperatureToHumidity);
                var location = DoMap(humidity, humidityToLocation);

                minLoc = Math.Min(minLoc, location);
            }

            return minLoc;
        }

        public static Int64 Day05b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day05.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day05a : {0}   Time: {1}", Day05a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day05b : {0}   Time: {1}", Day05b(lines), sw.ElapsedMilliseconds);
        }
    }
}
