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
            var mappings = new Dictionary<int, string>()
            {
                {0, "abcefg"},
                {1, "cf"},
                {2, "acdeg"},
                {3, "acdfg"},
                {4, "bcdfg"},
                {5, "abdfg"},
                {6, "abdefg"},
                {7, "acf"},
                {8, "abcdefg"},
                {9, "abcdfg"}
            };
            bool[] number = new bool[8];
            
            
            
            return 0;
        }

        struct Number
        {
            private char[] pos = new char[8];

            public Number()
            {
            }

            public void Add(string s)
            {
                
            }
        }
    }
}