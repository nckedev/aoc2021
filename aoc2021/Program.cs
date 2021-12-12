using System;
using System.Collections.Generic;
using System.Diagnostics;
using aoc2021;
Console.WriteLine("AOC 2021");
Stopwatch s = new Stopwatch();
Problem problem = new Day6();
s.Start();
Console.WriteLine($"Problem 1: {problem.Solve()}");
s.Stop();
Console.WriteLine(s.ElapsedMilliseconds + "ms");
s.Restart();
Console.WriteLine($"Problem 2: {problem.Solve2()}");
s.Stop();
Console.WriteLine(s.ElapsedMilliseconds + "ms");

