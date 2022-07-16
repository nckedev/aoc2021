namespace aoc2021
{
    public class Grid
    {
        private const int SIZE = 10;
        private readonly Cell[] grid;
        private int _index = 0;

        public Grid()
        {
            grid = new Cell[SIZE * SIZE];
        }

        public void PopulateGrid(string[] lines)
        {
            var g = 0;
            foreach (var line in lines)
            {
                foreach (var ch in line)
                {
                    grid[g++].Value = Convert.ToInt32(ch - '0');
                }
            }
        }

        public int GetFlashes() => grid.Count(c => c.Value == 0);

        public void IncrementAdjacent(int index = -1)
        {
            var idx = index == -1 ? _index : index;
            if (grid[idx].Value == 0)
                grid[idx].IsAdjIncremented = true;

            var rowStart = idx - SIZE >= 0 ? idx - SIZE : idx;
            var rowEnd = idx + SIZE < SIZE * SIZE ? idx + SIZE : idx;

            for (int i = rowStart; i <= rowEnd; i += SIZE)
            {
                var start = i - 1 >= SIZE * (i / SIZE) ? i - 1 : i;
                var end = i + 1 < (SIZE * (i / SIZE)) + SIZE ? i + 1 : i;
                for (int j = start; j <= end; j++)
                {
                    var current = grid[j];
                    if (current.Value is > 0 and < 9)
                    {
                        grid[j].Value++;
                    }
                    else if (current.Value == 9 || (current.Value == 0 && current.IsAdjIncremented == false))
                    {
                        grid[j].Value = 0;
                        grid[j].IsAdjIncremented = true;
                        if (j != idx)
                        {
                            IncrementAdjacent(j);
                        }
                    }
                }
            }
        }


        public IEnumerable<Cell> IterateCurrentState()
        {
            _index = 0;
            foreach (var cell in grid)
            {
                yield return cell;
                _index++;
            }
        }

        public void Step()
        {
            _index = 0;
            for (var c = 0; c < grid.Length; c++)
            {
                grid[c].Increment();
            }
        }


        public void Print()
        {
            for (var c = 0; c < grid.Length; c++)
            {
                if (c % 10 == 0 && c > 0)
                {
                    Console.WriteLine();
                }

                Console.Write(grid[c].Value);
            }

            Console.WriteLine();
        }
    }

    public struct Cell
    {
        public int Value;
        public bool IsAdjIncremented = false;

        public Cell(int value, bool isAdjIncremented = false)
        {
            Value = value;
            IsAdjIncremented = isAdjIncremented;
        }

        public void Increment(bool isAdjIncremented = false)
        {
            IsAdjIncremented = isAdjIncremented;

            Value++;
            if (Value >= 10)
            {
                Value = 0;
            }
        }
    }

    class Day11 : Problem
    {
        private readonly Grid grid = new Grid();

        public Day11() : base(11)
        {
        }


        public sealed override long Solve()
        {
            grid.PopulateGrid(File.ReadAllLines(file));
            var flashes = 0;
            for (var i = 0; i < 100; i++)
            {
                grid.Step();
                foreach (var cell in grid.IterateCurrentState())
                {
                    if (cell.Value == 0 && cell.IsAdjIncremented == false)
                    {
                        grid.IncrementAdjacent();
                    }
                }

                flashes += grid.GetFlashes();
            }

            return flashes;
        }

        public sealed override long Solve2()
        {
            grid.PopulateGrid(File.ReadAllLines(file));
            for (var i = 0; ; i++)
            {
                grid.Step();
                foreach (var cell in grid.IterateCurrentState())
                {
                    if (cell.Value == 0 && cell.IsAdjIncremented == false)
                    {
                        grid.IncrementAdjacent();
                    }
                }

                if (grid.GetFlashes() == 100)
                {
                    return i;
                }
            }
        }
    }
}