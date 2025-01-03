﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Line
    {
        public Point A { get; private set; }
        public Point B { get; private set; }
        public int DeltaX { get => A.X - B.X; }
        public int DeltaY { get => A.Y - B.Y; }
        public int DirX { get => A.X - B.X < 0 ? 1 : -1; }
        public int DirY { get => A.Y - B.Y < 0 ? 1 : -1; }
        public Line(Point a, Point b)
        {
            this.A = a;
            this.B = b;
        }
        public Line(int a, int b, int c, int d)
            : this(new Point(a, b), new Point(c, d))
        { }
    }
    class Day5 : Problem
    {
        private int[,] grid = new int[1000, 1000];
        private List<Line> lines = new();
        public Day5() : base(5)
        {
            var test = File.ReadLines(file).Select(x => x.Replace(" -> ", ",").Split(",").Select(y => Convert.ToInt32(y)).ToList());
            foreach (var n in test.ToList())
            {
                lines.Add(new Line(n[0], n[1], n[2], n[3]));
            }
        }
        public override long Solve()
        {
            int start = 0;
            int delta = 0;
            foreach (var line in lines)
            {
                if (line.DeltaY == 0)
                {
                    start = Math.Min(line.A.X, line.B.X);
                    delta = Math.Abs(line.DeltaX);
                    for (int i = start; i <= start + delta; i++)
                    {
                        grid[i, line.A.Y]++;
                    }
                }
                else if (line.DeltaX == 0)
                {
                    start = Math.Min(line.A.Y, line.B.Y);
                    delta = Math.Abs(line.DeltaY);
                    for (int i = start; i <= start + delta; i++)
                    {
                        grid[line.A.X, i]++;
                    }
                }
            }
            return CountGrid();
        }
        public override long Solve2()
        {
            foreach (var line in lines)
            {
                if (line.DeltaX != 0 && line.DeltaY != 0)
                {
                    int x = line.A.X;
                    int y = line.A.Y;
                    for (; ; )
                    {
                        if (x != line.A.X + line.DirX + (line.DirX * Math.Abs(line.DeltaX)) || y != line.A.Y + line.DirY + (line.DirY * Math.Abs(line.DeltaY)))
                        {
                            grid[x, y]++;
                        }
                        else
                        {
                            break;
                        }
                        x += line.DirX;
                        y += line.DirY;
                    }
                }
            }
            return CountGrid();
        }

        public long CountGrid()
        {
            long count = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (grid[i, j] >= 2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
