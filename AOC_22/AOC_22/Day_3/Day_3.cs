using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_3
{
    public class Day_3
    {
        public int result { get; set; }

        private int getValue(char[] fh, char[] sh) {
            Hashtable shTable = new Hashtable();
            int rval = 0;
            foreach (char c in sh) 
            {
                if(!shTable.ContainsKey(c))
                    shTable.Add(c, c);
            }
            foreach (char c in fh) {
                if (shTable.Contains(c)) 
                {
                    rval = char.IsUpper(c) ? char.ToLower(c) - 'a' + 27 : c - 'a' + 1;
                    break;
                }
            }
            return rval;
        }

        private int getValueP2(string r1, string r2, string r3) 
        {
            Hashtable r1Table = new Hashtable();
            Hashtable r2Table = new Hashtable();
            Hashtable r3Table = new Hashtable();

            int rval = 0;
            foreach (char c in r1)
            {
                if (!r1Table.ContainsKey(c))
                    r1Table.Add(c, c);
            }
            foreach (char c in r2)
            {
                if (!r2Table.ContainsKey(c))
                    r2Table.Add(c, c);
            }
            foreach (char c in r3)
            {
                if (!r3Table.ContainsKey(c))
                    r3Table.Add(c, c);
            }
            foreach (char c in r1)
            {
                if (r1Table.Contains(c) && r2Table.Contains(c) && r3.Contains(c))
                {
                    rval = char.IsUpper(c) ? char.ToLower(c) - 'a' + 27 : c - 'a' + 1;
                    break;
                }
            }
            return rval;

        }

        public Day_3(bool part1) {
            int counter = 0;
            string r1 = "";
            string r2 = "";
            foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_3/input.txt"))
            {
                if (part1)
                {
                    string[] parts = line.Insert(line.Length / 2, "|").Split('|');
                    int current_res = getValue(parts[0].ToArray(), parts[1].ToArray());
                    result += current_res;
                }
                else 
                {
                    switch(counter)
                    {
                        case 0 : 
                            r1 = line;
                            counter++;
                            break;
                        case 1:
                            r2 = line;
                            counter++;
                            break;
                        case 2:
                            int current_res = getValueP2(r1, r2, line);
                            result += current_res;
                            counter = 0;
                            break;
                    }
                }
               
            }
        }
    }
}
