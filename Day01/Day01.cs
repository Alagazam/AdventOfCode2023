using System.Diagnostics;
using System.Threading;

namespace AoC
{
    public static class Day01
    {
        public static Int64 Day01a(string[] input)
        {
            var sum = 0;
            foreach (string s in input)
            {
                if (s.Length != 0)
                {
                    var digits = s.Where(c => Char.IsDigit(c));
                    var first = digits.First() - '0';
                    var last = digits.Last() - '0';
                    sum += first * 10 + last;
                }
            }
            return sum;
        }

        public static Int64 Day01b(string[] input)
        {
            var sum = 0;
            string[] numbers = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
            string[] digits = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
            foreach (string s in input)
            {
                if (s.Length != 0)
                {
                    var first = -1;
                    var last = -1;
                    for (var i = 0; i != s.Length; i++)
                    {
                        for (var n = 0; n < digits.Length; n++)
                        {
                            if (first == -1)
                            {
                                if (s.Substring(i).StartsWith(digits[n]))
                                {
                                    first = n;
                                }
                                else if (s.Substring(i).StartsWith(numbers[n]))
                                {
                                    first = n;
                                }
                            }
                            if (last == -1)
                            {
                                if (s.Substring(s.Length - i - 1).StartsWith(digits[n]))
                                {
                                    last = n;
                                }
                                else if (s.Substring(s.Length - i - 1).StartsWith(numbers[n]))
                                {
                                    last = n;
                                }
                            }
                            if (first != -1 && last != -1) break;
                        }
                        if (first != -1 && last != -1) break;
                    }
                    if (first!=-1 && last!=-1)
                        sum += first * 10 + last;
                }
            }
            return sum;
        } 


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day01.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day01a : {0}   Time: {1}", Day01a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day01b : {0}   Time: {1}", Day01b(lines), sw.ElapsedMilliseconds);
        }
    }
}
