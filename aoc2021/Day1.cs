using System.Linq;
namespace aoc2021
{

    class Day1 : Problem
    {
        private List< int> file;
        public Day1() : base(1)
        {
            file = File.ReadLines("input/1.txt").Select(x=>int.Parse(x)).ToList();
        }


        public override long Solve()
        {
			int count = 0;
            file.Aggregate((current, next) =>
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
            var array = file.ToArray();
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
