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
            int oxygen;
            int co2;

            int mostcommon = 0;
            int column = 0;
            int one  =0;
            int zero = 0;

            var data = input;
            while (true)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if ((data[i] & (1 << (11 - column))) > 0)
                    {
                        //count 1's
                        one++;    
                    }
                    else
                    {
                        zero++;
                    }
                }
                mostcommon = one >= zero ? 1 : 0;
                data = data.Where(x => mostcommon == 1 ? (x & (1 << (11 - column))) > 0 : (x & (1 << 11 -column)) == 0).ToList();
                column++;
                one = zero = 0;
                if (data.Count == 1)
                {
                    oxygen = data[0];
                    break;
                }
            }

            data = input;
            column = 0;
            int leastcommon = 0;
            while (true)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if ((data[i] & (1 << (11 - column))) == 0)
                    {
                        zero++;
                    }
                    else
                    {
                        one++;
                    }
                }
                leastcommon = one < zero ? 1: 0;    
                data = data.Where(x => leastcommon == 1 ? (x & (1 << (11 - column))) > 0 : (x & (1 << 11 - column)) == 0).ToList();
                column++;
                one = zero = 0; 
                if (data.Count == 1)
                {
                    co2 = data[0];
                    break;
                }
            }
            return oxygen * co2;
        }

    }
}
