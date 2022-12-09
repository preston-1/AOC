using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_9
{
    internal class Day_9
    {
        public int result { get; set; }

        public Dictionary<Tuple<int, int>, bool> gridSpace { get; set; }

        public class Rope 
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool head { get; set; }

            public Rope(bool _head) 
            {
                x = y = 0;
                head = _head ? true : false;
            }
        }

        public bool tailMove(Rope head, Rope tail) 
        {
            //on top of each other
            if (head.x == tail.x && head.y == tail.y)
            {
                return false;
            }
            //left right
            else if (head.y == tail.y && (head.x == tail.x + 1 || head.x == tail.x -1))
            {
                return false;
            }
            //up down
            else if (head.x == tail.x && (head.y == tail.y + 1 || head.y == tail.y -1))
            {
                return false;
            }
            //diags
            else if ((head.x == tail.x -1 && head.y == tail.y +1) || (head.x == tail.x - 1 && head.y == tail.y - 1) || (head.x == tail.x + 1 && head.y == tail.y - 1) || (head.x == tail.x + 1 && head.y == tail.y + 1)) 
            {
                return false;
            }
            return true;
        }

        public bool tailMove2(Rope2 head, Rope2 tail)
        {
            //on top of each other
            if (head.x == tail.x && head.y == tail.y)
            {
                return false;
            }
            //left right
            else if (head.y == tail.y && (head.x == tail.x + 1 || head.x == tail.x - 1))
            {
                return false;
            }
            //up down
            else if (head.x == tail.x && (head.y == tail.y + 1 || head.y == tail.y - 1))
            {
                return false;
            }
            //diags
            else if ((head.x == tail.x - 1 && head.y == tail.y + 1) || (head.x == tail.x - 1 && head.y == tail.y - 1) || (head.x == tail.x + 1 && head.y == tail.y - 1) || (head.x == tail.x + 1 && head.y == tail.y + 1))
            {
                return false;
            }
            return true;
        }

        public string getMove(Rope head, Rope tail) 
        {
            //move up
            if (head.x == tail.x && head.y == tail.y + 2)
                return "U";
            //move down
            else if (head.x == tail.x && head.y == tail.y - 2)
                return "D";
            //move left
            else if (head.x == tail.x - 2 && head.y == tail.y)
                return "L";
            //move right
            else if (head.x == tail.x + 2 && head.y == tail.y)
                return "R";
            //move diag up left
            else if ((head.x == tail.x - 2 && head.y == tail.y + 1) || (head.x == tail.x - 2 && head.y == tail.y + 2) || (head.x == tail.x - 1 && head.y == tail.y + 2))
                return "UL";
            //move diag  up right
            else if ((head.x == tail.x + 2 && head.y == tail.y + 1) || (head.x == tail.x + 2 && head.y == tail.y + 2) || (head.x == tail.x + 1 && head.y == tail.y + 2))
                return "UR";
            //move diag down right
            else if ((head.x == tail.x + 1 && head.y == tail.y - 2) || (head.x == tail.x + 2 && head.y == tail.y - 2) || (head.x == tail.x + 2 && head.y == tail.y - 1))
                return "DR";
            else
                return "DL";
        }

        public string getMove2(Rope2 head, Rope2 tail)
        {
            //move up
            if (head.x == tail.x && head.y == tail.y + 2)
                return "U";
            //move down
            else if (head.x == tail.x && head.y == tail.y - 2)
                return "D";
            //move left
            else if (head.x == tail.x - 2 && head.y == tail.y)
                return "L";
            //move right
            else if (head.x == tail.x + 2 && head.y == tail.y)
                return "R";
            //move diag up left
            else if ((head.x == tail.x - 2 && head.y == tail.y + 1) || (head.x == tail.x - 2 && head.y == tail.y + 2) || (head.x == tail.x - 1 && head.y == tail.y + 2))
                return "UL";
            //move diag  up right
            else if ((head.x == tail.x + 2 && head.y == tail.y + 1) || (head.x == tail.x + 2 && head.y == tail.y + 2) || (head.x == tail.x + 1 && head.y == tail.y + 2))
                return "UR";
            //move diag down right
            else if ((head.x == tail.x + 1 && head.y == tail.y - 2) || (head.x == tail.x + 2 && head.y == tail.y - 2) || (head.x == tail.x + 2 && head.y == tail.y - 1))
                return "DR";
            else
                return "DL";
        }

        public void move(ref Rope head, ref Rope tail, string direction) 
        {
            //right
            if (direction == "R")
            {
                head.x++;
            }
            //left
            else if (direction == "L")
            {
                head.x--;
            }
            //up
            else if (direction == "U")
            {
                head.y++;
            }
            //down
            else
            {
                head.y--;
            }
            if (tailMove(head, tail))
            {
                //do stuff
                string tailDir = getMove(head, tail);
                switch (tailDir)
                {
                    case "U":
                        {
                            tail.y++;
                            break;
                        }
                    case "D":
                        {
                            tail.y--;
                            break;
                        }
                    case "R":
                        {
                            tail.x++;
                            break;
                        }
                    case "L":
                        {
                            tail.x--;
                            break;
                        }
                    case "UR":
                        {
                            tail.x++;
                            tail.y++;
                            break;
                        }
                    case "UL":
                        {
                            tail.x--;
                            tail.y++;
                            break;
                        }
                    case "DR":
                        {
                            tail.x++;
                            tail.y--;
                            break;
                        }
                    case "DL":
                        {
                            tail.x--;
                            tail.y--;
                            break;
                        }
                }
            }
            Tuple<int,int> move = Tuple.Create(tail.x, tail.y);
            if (!gridSpace.ContainsKey(move)) 
            {
                gridSpace.Add(move, true);
            }
        }

        public void move2(ref Rope2 head, ref Rope2 tail, string direction)
        {
            //right
            if (direction == "R" && tail.head)
            {
                head.x++;
            }
            //left
            else if (direction == "L" && tail.head)
            {
                head.x--;
            }
            //up
            else if (direction == "U" && tail.head )
            {
                head.y++;
            }
            //down
            else if(tail.head)
            {
                head.y--;
            }
            if (tailMove2(head, tail))
            {
                //do stuff
                string tailDir = getMove2(head, tail);
                switch (tailDir)
                {
                    case "U":
                        {
                            tail.y++;
                            break;
                        }
                    case "D":
                        {
                            tail.y--;
                            break;
                        }
                    case "R":
                        {
                            tail.x++;
                            break;
                        }
                    case "L":
                        {
                            tail.x--;
                            break;
                        }
                    case "UR":
                        {
                            tail.x++;
                            tail.y++;
                            break;
                        }
                    case "UL":
                        {
                            tail.x--;
                            tail.y++;
                            break;
                        }
                    case "DR":
                        {
                            tail.x++;
                            tail.y--;
                            break;
                        }
                    case "DL":
                        {
                            tail.x--;
                            tail.y--;
                            break;
                        }
                }
            }
            if (tail.tail) 
            {
                Tuple<int, int> move = Tuple.Create(tail.x, tail.y);
                if (!gridSpace.ContainsKey(move))
                {
                    gridSpace.Add(move, true);
                }
            }

        }

        public void handleMove(Rope head, Rope tail, string direction, int steps) 
        {
            while (steps > 0)
            {
                move(ref head, ref tail, direction);
                steps--;
            }            
        }

        public void handleMove2(List<Rope2> rope, string direction, int steps) 
        {
            while (steps > 0) 
            {
                for (int i = 0; i < 10; i++) 
                {
                    if (rope[i].head)
                    {
                        Rope2 currentHead = rope[i];
                        move2(ref currentHead, ref currentHead, direction);
                        rope[i] = currentHead;
                        steps--;
                    }
                    else 
                    {    
                        Rope2 tail = rope[i];
                        Rope2 parent = tail.parent;
                        move2(ref parent, ref tail, direction);
                        rope[i] = tail;
                    }
                }
            }
        }

        public class Rope2
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool head { get; set; }
            public bool tail { get; set; }

            public Rope2 parent { get; set; }
            public Rope2()
            {
                x = y = 0;
                head = true;
            }
            public Rope2(Rope2 _parent, bool isTail)
            {
                x = y = 0;
                parent = _parent;
                head = false;
                tail = isTail;
            }
        }

        public Day_9(bool part1) 
        {
            if (part1)
            {
                //starting point
                gridSpace = new Dictionary<Tuple<int, int>, bool>();
                gridSpace.Add(Tuple.Create(0, 0), true);
                Rope head = new Rope(true);
                Rope tail = new Rope(false);
                foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_9/input.txt"))
                {
                    string[] parts = line.Split(" ");
                    //direction, steps, g
                    handleMove(head, tail, parts[0], int.Parse(parts[1]));
                }
                result = gridSpace.Count;
            }
            else 
            {
                gridSpace = new Dictionary<Tuple<int, int>, bool>();
                gridSpace.Add(Tuple.Create(0, 0), true);
                List<Rope2> rope = new List<Rope2>(); 
                for (int i = 0; i < 10; i++) {
                    if (i == 0)
                    {
                        var newRope = new Rope2();
                        rope.Add(newRope);
                    }
                    else if (i < 9)
                    {
                        var newRope = new Rope2(rope.Last(), false);
                        rope.Add(newRope);
                    }
                    else 
                    {
                        var newRope = new Rope2(rope.Last(), true);
                        rope.Add(newRope);
                    }
                }
                foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_9/input.txt"))
                {
                    string[] parts = line.Split(" ");
                    //direction, steps, g
                    handleMove2(rope, parts[0], int.Parse(parts[1]));
                }
                result = gridSpace.Count;
            }
            
        }
    }
}
