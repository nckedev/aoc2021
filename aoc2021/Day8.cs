using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Day8 : Problem
    {
        public Day8() : base(8)
        {
            var input = File.ReadLines(file).ToList();

            foreach (var s in input)
            {
            }
        }

        public override long Solve()
        {
            return File.ReadLines(file).Select(x => x.Split("|")[1])
                .Select(x =>
                    x.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Count(y => y.Length is 2 or 3 or 4 or 7))
                .Sum();
        }   

        public override long Solve2()
        {
            //vilken pos
            //vilken bokstav
            //nummer det bildar
            //mappa till riktiga nummer
            bool[] number = new bool[8];
            
            return 0;
        }
    }
}