using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_2
{

    public class Day_2
    {
        public int result { get; set; }

        private Dictionary<string, int> _part1 = new Dictionary<string, int>()
        {
            {"AX", 4},{"AY",8},{ "AZ", 3},{ "BX", 1},{"BY",5}, { "BZ",9}, { "CX",7}, { "CY",2}, { "CZ",6}
        };

        private Dictionary<string, int> _part2 = new Dictionary<string, int>()
        {
            {"AX", 3},{"AY",4},{ "AZ", 8},{ "BX", 1},{"BY",5}, { "BZ",9}, { "CX",2}, { "CY",6}, { "CZ",7}
        };

        public Day_2(bool part1)
        {
            int current_total = 0;
            foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_2/input.txt"))
            {
                string[] picks = line.Split(' ');
                current_total +=  part1 ? _part1[picks[0]+picks[1]] : _part2[picks[0] + picks[1]];
            }
            result = current_total;
        }
    }
}
