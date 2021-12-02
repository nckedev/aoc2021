using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace aoc2021
{
    abstract class Problem
    {
        private const string sessionid = "53616c7465645f5ff21648947804cf328b562656fa93a21c70304df23a50e9e6c177547848c0785b3ff68b2325ed8d66";
        private const string year = "2021";
        private const string baseurl = $"https://adventofcode.com/{year}/day/";

        protected string dayfile;
        protected int day;
        protected string input;
        public Problem(int day)
        {
            input = GetInputFile(day);
            this.day = day;
            this.dayfile = $"{day}.txt";

        }

        private string GetInputFile(int day)
        {
            /* if (!File.Exists($"input/{dayfile}")) */
            /* { */
            /*     //create file */
            /*     string url = baseurl + $"{day}/input"; */
            /* } */
            /* else */
            /* { */
            /* } */
            return $"input/{dayfile}";
        }
        protected virtual List<T> ReadFileGeneric<T>() 
        {
            if (typeof(T) is int) {
            }
			return new List<T>();
        }
        protected virtual List<int> ReadFileInts()
        {
            return File.ReadLines(input).Select(x => int.Parse(x)).ToList();
        }
        protected virtual List<string> ReadFile()
        {
            return File.ReadAllLines(input).ToList();
        }
        protected virtual string[] ReadFileAsArray()
        {
            return File.ReadAllLines(input);
        }

        protected virtual void Print<T>(string varname, T message)
        {
            Console.WriteLine($"{varname} = {message}");
        }

        public abstract long Solve();
        public abstract long Solve2();


    }
}
