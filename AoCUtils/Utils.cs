using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    public class Utils
    {
        public static Int64 GCD(Int64 a, Int64 b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }

        public static Int64 LCM(IReadOnlyList<long> vec)
        {
            var lcm = vec[0];
            foreach (var v in vec)
            {
                var a = lcm;
                var b = v;
                var gcd_val = GCD(a, b);
                lcm = (lcm * v) / gcd_val;
            }
            return lcm;
        }
    }

}
