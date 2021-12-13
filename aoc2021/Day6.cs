using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    public class Day6 : Problem
    {
        private List<int> inp;
        public Day6() : base(6)
        {
            inp = File.ReadAllText(file).Split(",").Select(x => Convert.ToInt32(x)).ToList();
        }
        public override long Solve()
        {
            var list = new List<int>(inp);
            var newfish = new List<int>();
            for (int d =0; d < 80 ; d++)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i]--;
                    if (list[i] == -1)
                    {
                        list[i] = 6;
                        newfish.Add(8);
                    }
                }
                list.AddRange(newfish);
                newfish.Clear();
            }
            return list.Count();
        }
        public override long Solve2()
        {
            var list = new List<int>(inp);
            long[] offset = new long[9];
            foreach (var f in list)
            {
                offset[f]++;
            }

            long newfish;
            for (int d = 0; d < 256; d++)
            {
                newfish = offset[d % 7];
                offset[d % 7] += offset[7];
                offset[7] = offset[8];

                offset[8] = newfish;
            }
           return  offset[0..9].Sum();
        }

    }

}

