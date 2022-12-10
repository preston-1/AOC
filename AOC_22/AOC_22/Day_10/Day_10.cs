using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_10
{
    internal class Day_10
    {
        public int result { get; set; }

        public bool checkCycle(int cycle) 
        {
            if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
                return true;
            return false;
        }
        public bool checkCycle2(int cycle)
        {
            if (cycle == 41 || cycle == 81 || cycle == 121 || cycle == 161 || cycle == 201 || cycle == 240)
                return true;
            return false;
        }
        public Day_10(bool part1) 
        {
            if (part1)
            {
                int x = 1;
                int cycle = 0;
                List<int> counts = new List<int>();
                foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_10/input.txt"))
                {
                    string[] splits = line.Split(" ");
                    if (splits.Length == 2)
                    {
                        cycle++;
                        if (checkCycle2(cycle))
                        {
                            counts.Add(x * cycle);
                        }
                        cycle++;
                        if (checkCycle(cycle))
                        {
                            counts.Add(x * cycle);
                        }
                        x += int.Parse(splits[1]);
                    }
                    else
                    {
                        cycle++;
                        if (checkCycle(cycle))
                        {
                            counts.Add(x * cycle);
                        }
                    }
                }
                result = counts.Sum();
            }
            else 
            {
                int x = 1;
                int cycle = 1;
                int position = 0;
                int crtIdx = 0;
                string spritePosition = "###.....................................";
                List<string> crt = new List<string> { "........................................", "........................................", "........................................",
                    "........................................","........................................","........................................"};
                StringBuilder currentRow = new StringBuilder(crt[crtIdx]);
                foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_10/input.txt"))
                {
                    string[] splits = line.Split(" ");
                    if (splits.Length == 2)
                    {
                        if (checkCycle2(cycle))
                        {
                            crt[crtIdx] = currentRow.ToString();
                            crtIdx++;
                            if (crtIdx != 6)
                                currentRow = new StringBuilder(crt[crtIdx]);
                            position = 0;
                        }
                        if (spritePosition[position] == '#')
                        {
                            currentRow[position] = '#';
                        }
                        position++;
                        cycle++;
                        if (checkCycle2(cycle))
                        {
                            crt[crtIdx] = currentRow.ToString();
                            crtIdx++;
                            if (crtIdx != 6)
                                currentRow = new StringBuilder(crt[crtIdx]);
                            position = 0;
                        }
                        if (spritePosition[position] == '#')
                        {
                            currentRow[position] = '#';
                        }
                        x += int.Parse(splits[1]);
                        StringBuilder baseRow = new StringBuilder("........................................");
                        if (x >= 1 && x <= 38)
                        {
                            baseRow[x] = '#';
                            baseRow[x - 1] = '#';
                            baseRow[x + 1] = '#';
                        }
                        else if (x == 0)
                        {
                            baseRow[x + 1] = '#';
                            baseRow[x] = '#';
                        }
                        else if (x == 39) 
                        {
                            baseRow[x] = '#';
                            baseRow[x - 1] = '#';
                        }
                        spritePosition = baseRow.ToString();
                        position++;
                        cycle++;
                    }
                    else
                    {
                        if (checkCycle2(cycle))
                        {
                            crt[crtIdx] = currentRow.ToString();
                            crtIdx++;
                            if(crtIdx != 6)
                                currentRow = new StringBuilder(crt[crtIdx]);
                            position = 0;
                        }
                        if (spritePosition[position] == '#')
                        {
                            currentRow[position] = '#';
                        }
                        cycle++;
                        position++;
                    }
                }
                result = 0;
                foreach (var line in crt) 
                {
                    Console.WriteLine(line);
                }
                
            }

            
        }
    }
}
