
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Day7 : Problem
    {
        List<int> inp = new List<int>();
        public Day7() : base(7)
        {

            inp = File.ReadAllText(file).Split(",").Select(x => Convert.ToInt32(x)).ToList();
        }
        public override long Solve()
        {
            inp.Sort();
            var a = inp[inp.Count() / 2];
            int count = 0;
            foreach (var x in inp)
            {
                count += Math.Abs(a - x);
            }
            return count;
        }
        public override long Solve2()
        {
            int count = 0;
            var mean = inp.Sum() / inp.Count();
            foreach (var x in inp)
            {
                var n = Math.Abs(mean - x);
                count += n * (n + 1) / 2;
            }
            return count;
        }

    }
}

