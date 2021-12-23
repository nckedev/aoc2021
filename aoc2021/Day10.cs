using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    struct Pair
    {
        private char open;
        private char close;

        public Pair(char open, char close)
        {
            this.open = open;
            this.close = close;
        }
    }

    class Day10 : Problem
    {
        private Stack<char>? stack;
        private List<string> input;
        private readonly Dictionary<char, int> scoreDict;
        private readonly Dictionary<char, int> completeScoreDict;

        public Day10() : base(10)
        {
            input = File.ReadLines(file).ToList();
            scoreDict = new Dictionary<char, int> {{')', 3}, {']', 57}, {'}', 1197}, {'>', 25137}};
            completeScoreDict = new Dictionary<char, int> {{')', 1}, {']', 2}, {'}', 3}, {'>', 4}};
        }

        public override long Solve()
        {
            stack = new Stack<char>();
            int score = 0;
            foreach (var line in input)
            {
                foreach (var c in line)
                {
                    if (IsOpen(c))
                    {
                        stack.Push(c);
                    }

                    if (IsClose(c))
                    {
                        if (c == GetMatch(stack.Peek()))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            score += scoreDict[c];
                            break;
                        }
                    }
                }

                stack.Clear();
            }

            return score;
        }

        public override long Solve2()
        {
            stack = new Stack<char>();
            var scores = new List<long>();
            long score = 0;
            var incomplete = new List<Stack<char>>();
            bool discard = false;
            foreach (var line in input)
            {
                foreach (var c in line)
                {
                    if (IsOpen(c))
                    {
                        stack.Push(c);
                    }

                    else if (IsClose(c))
                    {
                        if (c == GetMatch(stack.Peek()))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            discard = true;
                            break;
                        }
                    }
                }

                if (stack.Count > 0 && discard == false)
                {
                    incomplete.Add(new Stack<char>(stack));
                }

                discard = false;
                stack.Clear();
            }


            score = 0;
            foreach (var stack in incomplete)
            {
                foreach (var c in stack.Reverse().ToList())
                {
                    var match = GetMatch(c);
                    score = 5 * score + completeScoreDict[match];
                }

                scores.Add(score);
                score = 0;
            }
            scores.Sort();
            return scores[scores.Count / 2];
        }

        private bool IsOpen(char c)
        {
            string open = "<{([";
            return open.Contains(c);
        }

        private bool IsClose(char c)
        {
            string close = ">]})";
            return close.Contains(c);
        }

        private char GetMatch(char c)
        {
            string brace = "<{([])}>";
            var i = brace.IndexOf(c);
            return brace[brace.Length - 1 - i];
        }
    }
}