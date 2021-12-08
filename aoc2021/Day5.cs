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

    class GridPoint : Point
    {
        public int Crossed { get; set; } = 0;
        public GridPoint(int x, int y) : base(x, y)
        {

        }
    }

    class Line
    {
        Point A { get; set; }
        Point B { get; set; }
        public Line(Point a, Point b)
        {
            this.A = a;
            this.B = b;
        }

        public int GetCrossedPoits()
        {
            return 1;
        }
    }
    class Day5 : Problem
    {
        private List<Point> intersections;
        private List<GridPoint> grid;
        private List<Line> lines;
        public Day5() : base(5)
        {
            string[] del = { @" -> ", @", " };
			

            var test2 = File.ReadLines(file).Select(x => x.Replace(" -> ", ",").Split(",", StringSplitOptions.RemoveEmptyEntries)).ToList();
			var test = test2.Select(x => Convert.ToInt32(x)).ToList();
            Console.WriteLine(test.First());
			for (int i = 0; i < test.Count(); i++){
				if (i % 3 == 0 && i != 0){
					/* lines.Add(new Line(new Point(test[i-3], test[i-2]), new Point(test[i-1], test[i]))); */
				}
			}
        }
        public override long Solve()
        {
            return 0;
        }
        public override long Solve2()
        {
            return 0;
        }

    }
}
