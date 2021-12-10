using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    struct BoardNumber
    {
        public int Number { get; private set; }
        public bool Marked { get; set; }

        public BoardNumber(int number, bool marked = false)
        {
            this.Number = number;
            this.Marked = marked;
        }
    }
    class Board
    {
        public bool HasHadBingo = false;
        public const int SIZE = 5;
        private BoardNumber[] board;
        public Board(List<BoardNumber> list)
        {
            board = new BoardNumber[SIZE * SIZE];
            board = list.ToArray();
        }

        public bool SetMarked(int number)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].Number == number)
                {
                    board[i].Marked = true;
                    return true;
                }
            }
            return false;
        }
        public bool HasBingo()
        {
            if (HasHadBingo) // for part 2
            {
                return false;
            }

            for (int i = 0; i < board.Length; i += 5)
            {
                var bingo = board.Take(new Range(i, i + 5)).Where(x => x.Marked == true).Count() == 5;
                if (bingo)
                {
                    HasHadBingo = true; // for part 2
                    return true;
                }
            }
            var col = 0;
            var markedcount = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    col = ((SIZE * j) + i) % 25;
                    if (board[col].Marked == true)
                    {
                        markedcount++;
                    }
                }
                if (markedcount == 5)
                {
                    HasHadBingo = true; // for part 2
                    return true;
                }
                markedcount = 0;
            }
            return false;
        }

        public long CalcBoard(int winningNumber)
        {
            var res = 0;
            foreach (var n in board)
            {
                if (n.Marked == false)
                {
                    res += n.Number;
                }
            }
            return res * winningNumber;
        }
    }
    class Day4 : Problem
    {
        private List<int> bingoNumbers;
        private List<Board> boards;
        public Day4() : base(4)
        {
            var input = File.ReadAllLines(file);
            boards = new List<Board>();
            bingoNumbers = input[0].Split(",").Select(x => Convert.ToInt32(x)).ToList();

            var board = new List<BoardNumber>();
            int boardcount = 0;
            for (int i = 2; i < input.Length; i++)
            {
                if (input[i] != "")
                {
                    board.AddRange(input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(x => new BoardNumber(Convert.ToInt32(x)))
                                           .ToList());

                    boardcount++;
                    if (boardcount % 5 == 0)
                    {
                        boards.Add(new Board(board));
                        board.Clear();
                    }
                }
            }
        }
        public override long Solve()
        {
            foreach (var n in bingoNumbers)
            {
                foreach (var b in boards)
                {
                    b.SetMarked(n);
                    if (b.HasBingo())
                    {
                        return b.CalcBoard(n);
                    }
                }
            }
            return 0;
        }
        public override long Solve2()
        {
            long last = 0;
            foreach (var n in bingoNumbers)
            {
                foreach (var b in boards)
                {
                    b.SetMarked(n);
                    if (b.HasBingo())
                    {
                        last = b.CalcBoard(n);
                    }
                }
                if (n == 0)
                {
                    Console.WriteLine("0");
                }
            }
            return last;
        }
    }
}
