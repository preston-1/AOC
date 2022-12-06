using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_6
{
    public class Day_6
    {
        public int result { get; set; }

        public bool valid(string window) 
        {
            Hashtable lookup = new Hashtable();
            foreach (char c in window) 
            {
                if (!lookup.Contains(c))
                {
                    lookup.Add(c, c);
                }
                else 
                {
                    return false;
                }
            }
            return true;
        }
        public Day_6(bool part1)
        {
            Hashtable cTable = new Hashtable();
            string line = File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_6/input.txt").First();
            for (int i = 0; i < line.Length; i++) 
            {
                //get a window
                if (part1)
                {
                    if (i + 3 < line.Length)
                    {
                        string window = line.Substring(i, 4);
                        if (valid(window))
                        {
                            result = i + 4;
                            break;
                        }
                    }
                }
                else 
                {
                    if (i + 13 < line.Length)
                    {
                        string window = line.Substring(i, 14);
                        if (valid(window))
                        {
                            result = i + 14;
                            break;
                        }
                    }
                }
            }
        }
    }
}
