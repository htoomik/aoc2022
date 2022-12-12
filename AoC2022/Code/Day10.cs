using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Code
{
    public class Day10
    {
        private readonly List<string> _input;

        public Day10(List<string> input)
        {
            _input = input;
        }

        public int Solve()
        {
            
            var moments = new[] { 20, 60, 100, 140, 180, 220 };
            return moments.Select(GetSignalStrength).Sum();
        }

        public int GetSignalStrength(int readMoment)
        {
            var history = Process();
            return readMoment * history[readMoment - 1];
        }

        public List<int> Process()
        {
            var register = 1;
            var i = 0;
            var c = 1;
            var a = 0;
            var history = new List<int>();
            
            while (true)
            {
                // Cycle starts
                
                // During cycle
                history.Add(register);

                if (i == _input.Count)
                {
                    break;
                }

                // End of cycle
                var instruction = _input[i].Substring(0, 4);
                if (instruction == "noop")
                {
                    i++;
                }
                else if (instruction == "addx")
                {
                    if (a == 0)
                    {
                        a++;
                    }
                    else if(a == 1)
                    {
                        var toAdd = int.Parse(_input[i].Substring(4));
                        register += toAdd;
                        a = 0;
                        i++;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }

                c++;
            }

            return history;
        }

        public string Solve2()
        {
            var history = Process();
            var s = string.Empty;
            var pos = 0;
            for (int cycle = 1; cycle <= 240; cycle++)
            {
                var reg = history[cycle - 1];
                var pixel = Math.Abs(pos - reg) <= 1 ? "#" : ".";
                s += pixel;

                // Console.WriteLine($"cycle: {cycle}, pos: {pos}, reg: {reg}, pixel: {pixel}");
                
                if ((pos + 1) % 40 == 0)
                {
                    pos = 0;
                    s += "\r\n";
                }
                else
                {
                    pos++;
                }
            }
            return s.Trim();
        }
    }
}