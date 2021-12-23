namespace aoc2021
{
    class Day9 : Problem
    {
        private readonly int ROWLEN;
        private readonly int COLLEN;
        private readonly char[][] grid;
        private bool[,] visited;

        public Day9() : base(9)
        {
            grid = File.ReadLines(file).Select(x => x.ToArray()).ToArray();
            ROWLEN = grid.Length;
            COLLEN = grid[0].Length;
            visited = new bool[ROWLEN, COLLEN];
        }

        public override long Solve()
        {
            int left = 99;
            int right = 99;
            int up = 99;
            int down = 99;
            int count = 0;

            for (int i = 0; i < ROWLEN; i++)
            {
                for (int j = 0; j < COLLEN; j++)
                {
                    if (i - 1 >= 0) up = grid[i - 1][j];
                    if (i + 1 < ROWLEN) down = grid[i + 1][j];
                    if (j - 1 >= 0) left = grid[i][j - 1];
                    if (j + 1 < COLLEN) right = grid[i][j + 1];
                    char current = grid[i][j];
                    if (current < up && current < down && current < left && current < right)
                    {
                        count += current - '0' + 1;
                    }

                    up = 99;
                    down = 99;
                    left = 99;
                    right = 99;
                }
            }

            return count;
        }

        public override long Solve2()
        {
            List<int> res = new List<int>();

            int left = 99;
            int right = 99;
            int up = 99;
            int down = 99;
            int count = 0;

            for (int i = 0; i < ROWLEN; i++)
            {
                for (int j = 0; j < COLLEN; j++)
                {
                    if (i - 1 >= 0) up = grid[i - 1][j];
                    if (i + 1 < ROWLEN) down = grid[i + 1][j];
                    if (j - 1 >= 0) left = grid[i][j - 1];
                    if (j + 1 < COLLEN) right = grid[i][j + 1];
                    char current = grid[i][j];
                    if (current < up && current < down && current < left && current < right)
                    {
                        count += current - '0' + 1;
                        var a = CountBasin(i, j);
                        // Console.WriteLine($" ---- count: {a}");
                        if (a > 0)
                        {
                            res.Add(a);
                        }
                    }

                    up = 99;
                    down = 99;
                    left = 99;
                    right = 99;
                }
            }

            res.Sort((a, b) => b - a);
            return res.Take(3).Aggregate((a, b) => a * b);
        }


        public int CountBasin(int row, int col)
        {
            int count = 0;
            if (row < 0 || col < 0 || row >= ROWLEN || col >= COLLEN || visited[row, col] == true ||
                grid[row][col] == '9')
            {
                return 0;
            }

            visited[row, col] = true;
            count++;
            count += CountBasin(row + 1, col); //down
            count += CountBasin(row, col - 1); //left
            count += CountBasin(row - 1, col); //up
            count += CountBasin(row, col + 1); //right
            // Console.WriteLine($"row: {row} col: {col} count: {count}, value {current - '0'}");
            return count;
        }
    }
}