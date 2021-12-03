using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Day3 : Problem
    {
        List<int> input;
        public Day3() : base(3)
        {
            input = File.ReadLines(file).Select(x => Convert.ToInt32(x,2)).ToList();
        }
        public override long Solve()
        {
            int len = input.Count;
            int[] count = new int[12];
            int gamma = 0;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if ((input[i] & (1 << j)) > 0)
                    {
                        count[j]++;
                    }
                }
            }

            for (int i = 0;i < count.Length; i++)
            {
                if (count[i] > (len >> 1))
                {
                    gamma = gamma | (1 << i); 
                }
            }
           // input.Select(x => Enumerable.Range(0, 12).Select(a => (x & (1 << a)) > 0 ? count[a]++ : 0));
          //  gamma = count.Select((b, i) => b > (len >> 1) ?  (1 << i) : 0).Aggregate((a, b) => a | b);
            return gamma * (~gamma & 0xFFF);
        }
        public override long Solve2()
        {
            return 0;
        }

    }
}
