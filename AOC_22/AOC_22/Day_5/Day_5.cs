using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_5
{
    public class Day_5
    {
        public int result { get; set; }
        public Day_5(bool part1) {
            int current_row = 0;
            List<List<char>> cargo = new List<List<char>>();
            List<List<int>> moves = new List<List<int>>();
            bool tokenize = true;
            foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_5/input.txt")) 
            {
                if (tokenize) {
                    if (line == "") 
                    {
                        tokenize = false;
                        continue;
                    }
                    string current_line = line;
                    int current_idx = 0;
                    for(int i = 0; i < current_line.Length; i++)
                    {
                        if (current_line[i] == ' ')
                        {
                            if (current_row == 0)
                            {
                                cargo.Add(new List<char>());
                            }
                            if (current_line[i+1] == '1')
                            {
                                break;
                            }
                            current_line = current_line.Remove(0, 3);
                            if (current_line.Length != 0)
                            {
                                //take out the space if we are not at the end of line
                                current_line = current_line.Remove(0, 1);

                            }
                            current_idx++;
                            i = -1;
                        }
                        else if (current_line[i] == '[')
                        {
                            if (current_row == 0)
                            {
                                cargo.Add(new List<char>());
                            }
                            cargo[current_idx].Add(current_line[i + 1]);
                            current_line = current_line.Remove(0, 3);
                            if (current_line.Length != 0)
                            {
                                //take out the space if we are not at the end of line
                                current_line = current_line.Remove(0, 1);

                            }
                            current_idx++;
                            i = -1;
                        }
                        else 
                        {
                            // 1 2 3
                            break;
                        }
                    }
                    current_row += 1;
                }
                //we have our 2d array so then we can make out moves;
                if (!tokenize) 
                {
                    //yay
                    string sMove = "";
                    string sFrom = "";
                    string sTo = "";

                    string noMove = line.Remove(0, 5);
                    int moveIdx = 0;
                    while (noMove[moveIdx] != ' ') 
                    {
                        sMove += noMove[moveIdx];
                        moveIdx++;
                    }
                    moveIdx += 6;

                    while (noMove[moveIdx] != ' ') 
                    {
                        sFrom += noMove[moveIdx];
                        moveIdx++;
                    }
                    moveIdx += 4;

                    for (int i = moveIdx; i < noMove.Length; i++) 
                    {
                        sTo += noMove[moveIdx];                        
                    }

                    moves.Add(new List<int>() { int.Parse(sMove), int.Parse(sFrom), int.Parse(sTo) });
                }
            }

            foreach (var row in moves) 
            {
                if (part1) 
                {
                    //how many moves we make
                    for (int i = 0; i < row[0]; i++)
                    {
                        //get what you want to move
                        char toPlace = cargo[row[1] - 1].First();
                        //remove from
                        cargo[row[1] - 1].RemoveAt(0);
                        //place to
                        cargo[row[2] - 1].Insert(0, toPlace);
                    }
                }
                else 
                {
                    if (row[0] > 1)
                    {
                        List<char> bunch = new List<char>();
                        for (int i = 0; i < row[0]; i++)
                        {
                            //get what you want to move
                            char toPlace = cargo[row[1] - 1].First();
                            //remove from
                            cargo[row[1] - 1].RemoveAt(0);
                            //place to
                            bunch.Insert(0, toPlace);
                        }
                        foreach (var item in bunch) 
                        {
                            cargo[row[2] - 1].Insert(0, item);
                        }
                    }
                    else 
                    {
                        for (int i = 0; i < row[0]; i++)
                        {
                            //get what you want to move
                            char toPlace = cargo[row[1] - 1].First();
                            //remove from
                            cargo[row[1] - 1].RemoveAt(0);
                            //place to
                            cargo[row[2] - 1].Insert(0, toPlace);
                        }
                    }
                }
                
            }
            foreach (var row in cargo) 
            {
                Console.WriteLine(row.First());
            }
        }
    }
}
