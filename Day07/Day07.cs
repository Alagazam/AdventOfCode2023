using System.Diagnostics;
using System.Reflection.Metadata;

namespace AoC
{
    public static class Day07
    {
        public enum type { none, pair, twopair, three, full, four, five };
        public struct Hand
        {
            public string cards;
            public Int64 bet;
            public Hand(string s)
            {
                var c = s[0..5];
                cards = c;
                bet = Int64.Parse(s[6..]);
            }
            public readonly type GetHandType(bool withJoker = false)
            {
                var c = cards.ToList();
                c.Sort();
                if (withJoker)
                {
                    c.RemoveAll(c => c=='J');
                }
                if (c.Count == 5)
                {
                    if (c[0] == c[1] &&
                        c[1] == c[2] &&
                        c[2] == c[3] &&
                        c[3] == c[4]) return type.five;
                    if ((c[0] == c[1] || c[3] == c[4]) &&
                        c[1] == c[2] &&
                        c[2] == c[3]) return type.four;
                    if (c[0] == c[1] &&
                        (c[1] == c[2] || c[2] == c[3]) &&
                        c[3] == c[4]) return type.full;
                    if (c[0] == c[1] && c[1] == c[2] ||
                        c[1] == c[2] && c[2] == c[3] ||
                        c[2] == c[3] && c[3] == c[4]) return type.three;
                    if (c[0] == c[1] && c[2] == c[3] ||
                        c[0] == c[1] && c[3] == c[4] ||
                        c[1] == c[2] && c[3] == c[4]) return type.twopair;
                    if (c[0] == c[1] ||
                        c[1] == c[2] ||
                        c[2] == c[3] ||
                        c[3] == c[4]) return type.pair;
                    return type.none;
                }
                else if (c.Count == 4)
                {
                    if (c[0] == c[1] &&
                        c[1] == c[2] &&
                        c[2] == c[3]) return type.five;
                    if ((c[0] == c[1] || c[2] == c[3]) &&
                        c[1] == c[2]) return type.four;
                    if (c[0] == c[1] &&
                        c[2] == c[3]) return type.full;
                    if (c[0] == c[1] ||
                        c[1] == c[2] ||
                        c[2] == c[3]) return type.three;
                    return type.pair;
                }
                else if (c.Count == 3)
                {
                    if (c[0] == c[1] &&
                        c[1] == c[2]) return type.five;
                    if (c[0] == c[1] ||
                        c[1] == c[2]) return type.four;
                    return type.three;
                }
                else if (c.Count == 2)
                {
                    if (c[0] == c[1]) return type.five;
                    return type.four;
                }
                return type.five;
            }
        }

        public class HandCompare : System.Collections.Generic.IComparer<Hand>
        {
            bool _withJoker = false;

            public HandCompare(bool withJoker = false)
            {
                _withJoker = withJoker;
            }

            public int Compare(Hand x, Hand y)
            {
                var tx = x.GetHandType(_withJoker);
                var ty = y.GetHandType(_withJoker);
                if (tx < ty) return -1;
                if (tx > ty) return 1;
                string values = "23456789TJQKA";
                if (_withJoker) values = "J23456789TQKA";
                foreach (var card in x.cards.Zip(y.cards, Tuple.Create))
                {
                    var ca = values.IndexOf(card.Item1);
                    var cb = values.IndexOf(card.Item2);
                    if (ca < cb) return -1;
                    if (ca > cb) return 1;
                }
                return 0;
            }
        }

        public static Int64 Day07a(string[] input)
        {
            List<Hand> hands = new List<Hand>();
            foreach (var s in input)
            {
                hands.Add(new Hand(s));
            }
            hands.Sort(new HandCompare());
            Int64 win = 0;
            var i = 1; 
            foreach(var h in hands)
            {
                win += h.bet * i;
                ++i;
            }
            return win;
        }

        public static Int64 Day07b(string[] input)
        {
            List<Hand> hands = new List<Hand>();
            foreach (var s in input)
            {
                hands.Add(new Hand(s));
            }
            hands.Sort(new HandCompare(true));
            Int64 win = 0;
            var i = 1;
            foreach (var h in hands)
            {
                win += h.bet * i;
                ++i;
            }
            return win;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day07.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day07a : {0}   Time: {1}", Day07a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day07b : {0}   Time: {1}", Day07b(lines), sw.ElapsedMilliseconds);
        }
    }
}
