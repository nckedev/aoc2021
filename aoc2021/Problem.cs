namespace aoc2021
{
    public abstract class Problem
    {
        private const string Year = "2021";
        private const string Baseurl = $"https://adventofcode.com/{Year}/day/";

        private int day;
        protected readonly string file;
        protected string file_test;

        protected Problem(int day)
        {
            this.day = day;
            this.file = @$"input/{day}.txt";
            this.file_test = @$"input/{day}_test.txt";

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
            return $"input/{file}";
        }
        protected virtual List<T> ReadFileGeneric<T>() 
        {
            if (typeof(T) is int) {
            }
			return new List<T>();
        }
        protected virtual List<int> ReadFileInts()
        {
            return File.ReadLines(file).Select(x => int.Parse(x)).ToList();
        }
        protected virtual List<string> ReadFile()
        {
            return File.ReadAllLines(file).ToList();
        }
        protected virtual string[] ReadFileAsArray()
        {
            return File.ReadAllLines(file);
        }

        protected virtual void Print<T>(string varname, T message)
        {
            Console.WriteLine($"{varname} = {message}");
        }

        public abstract long Solve();
        public abstract long Solve2();


    }
}
