using System.Linq;

namespace aoc2021
{
    class Day1 : Problem
    {
        private List<int> input;

        public Day1() : base(1)
        {
            input = File.ReadLines(file).Select(int.Parse).ToList();
        }


        public override long Solve()
        {
            int count = 0;
            input.Aggregate((current, next) =>
            {
                if (next > current)
                {
                    count++;
                }

                return next;
            });
            return count;
        }

        public override long Solve2()
        {
            int count = 0;
            var array = input.ToArray();
            for (int i = 0; i < array.Length - 3; i++)
            {
                var current = new Range(i, i + 3);
                var next = new Range(i + 1, i + 1 + 3);
                if (array[next].Sum() > array[current].Sum())
                {
                    count++;
                }
            }

            return count;
        }
    }
}