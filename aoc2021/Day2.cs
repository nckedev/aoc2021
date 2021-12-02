using System.Linq;
namespace aoc2021
{

    class Day2 : Problem
    {
        struct Command 
        {
            public string command { get; set; }
            public int value { get; set; }
        }
        struct Sub
        {
            public int depth;
            public int hor;
        }

        struct Sub2 
        {
            public int aim;
            public int depth;
            public int hor;
        }
        private List<Command> commands;
        private Sub sub;
        private Sub2 sub2;
        public Day2() : base(2)
        {
             commands = File.ReadLines("input/2.txt").Select(x => {
                var line = x.Split(' ');
                var c = new Command();
                c.command = line[0];
                c.value = int.Parse(line[1]);
                return c;
            }).ToList();

            var sub = new Sub();
            var sub2 = new Sub2();
        }


        public override long Solve()
        {
            foreach(Command c in commands)
            {
                if (c.command == "forward")
                {
                    sub.hor += c.value;
                }
                else if (c.command == "up")
                {
                    sub.depth -= c.value;
                }
                else if (c.command == "down")
                {
                    sub.depth += c.value;
                }
                
            }
            return sub.depth * sub.hor;
        }

        public override long Solve2()
        {
            foreach(Command c in commands)
            {
                if (c.command == "forward")
                {
                    sub2.hor += c.value;
                    sub2.depth += c.value * sub2.aim;
                }
                else if (c.command == "up")
                {
                    sub2.aim -= c.value;
                }
                else if (c.command == "down")
                {
                    sub2.aim += c.value;
                }
                
            }
            return sub2.depth * sub2.hor;
        }
    }
}
