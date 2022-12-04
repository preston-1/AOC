using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_4
{
    public class Day_4
    {
        public int result { get; set; }
        public Day_4(bool part1)
        {
            int res = 0;

            foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_4/input.txt"))
            {
                string[] halves = line.Split(',');
                string[] f = halves[0].Split('-');
                string[] s = halves[1].Split('-');
                int f1 = int.Parse(f[0]);
                int f2 = int.Parse(f[1]);
                int s1 = int.Parse(s[0]);
                int s2 = int.Parse(s[1]);
                if (part1 && (s1 >= f1 && s2 <= f2 || s1 <= f1 && s2 >= f2))
                    res += 1;
                //very ugly (need to refactor) first section is partial overlap and second covers full overlap 
                if (!part1 && ((f1 <= s1 && (f2 <= s2 && f2 >= s1) ) || (s1 <= f1 && (s2 <= f2 && s2 >= f1)) || ((f1 < s1 && f2 > s2) || (s1 < f1 && s2 > f2))))
                    res += 1;
            }
            result = res;
        }
    }
}
