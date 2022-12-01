using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{

    public class solution
    {
        public int _result {get; set;}
        public int _topThreeResult { get; set; }

        public solution(bool topthree)
        {
            if (topthree)
            {
                int first_elf = 0;
                int second_elf = 0;
                int third_elf = 0;
                int current_elf = 0;
                foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_1/input.txt"))
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        if (current_elf > first_elf)
                        {
                            third_elf = second_elf;
                            second_elf = first_elf;
                            first_elf = current_elf;
                        }
                        else if (current_elf > second_elf)
                        {
                            third_elf = second_elf;
                            second_elf = current_elf;
                        }
                        else if (current_elf > third_elf) 
                        {
                            third_elf = current_elf;
                        }
                        current_elf = 0;
                    }
                    else
                    {
                        int val;
                        Int32.TryParse(line, out val);
                        current_elf += val;
                    }
                }
                _topThreeResult = first_elf + second_elf + third_elf;
            }
            else 
            {
                int max_elf = 0;
                int current_elf = 0;
                foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_1/input.txt"))
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        if (current_elf > max_elf)
                        {
                            max_elf = current_elf;
                        }
                        current_elf = 0;

                    }
                    else
                    {
                        int val;
                        Int32.TryParse(line, out val);
                        current_elf += val;
                    }
                }
                _result = max_elf;
            }
        }
    }
}
