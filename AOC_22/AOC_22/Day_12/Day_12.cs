using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_12
{
    internal class Day_12
    {
        public class Cell
        {
            public int x { get; set; }
            public int y { get; set; }
            public char c { get; set; }
            public bool isStart { get; set; }
            public bool isEnd { get; set; }

            public Cell(int x, int y, char c, bool isStart, bool isEnd)
            {
                this.x = x;
                this.y = y;
                this.c = c;
                this.isStart = isStart;
                this.isEnd = isEnd;
            }
        }
        public int result { get; set; }

        public int rowCount { get; set; }

        public int columnCount { get; set; }

        public List<List<Cell>> grid { get; set; } 

        public Cell start { get; set; }

        public Cell end { get; set; }

        public bool reachedEnd { get; set; }

        public Dictionary<Cell,bool> visisted { get; set; }

        public Queue<Cell> queue { get; set; }

        public List<int> dr { get; set; } = new List<int>() { -1, +1, 0, 0 };

        public List<int> dc { get; set; } = new List<int>() { 0, 0, +1, -1 };

        public int moveCount { get; set; }

        public int cellsLeftInLayer { get; set; }

        public int cellsInNextLayer { get; set; }

        public bool part1 { get; set; }

        public void exploreNeighbors(Cell current)
        {
            for (int i = 0; i < 4; i++)
            {
                int column = current.x + dr[i];
                int row = current.y + dc[i];
                if (row < 0 || column < 0)
                    continue;
                if (row >= rowCount || column >= columnCount)
                    continue;
                Cell neighbor = grid[row][column];
                if (visisted.ContainsKey(neighbor))
                    continue;
                //cant step up or down one level
                char nChar = neighbor.c;

                if (part1)
                {
                    if (nChar == current.c + 1 || nChar == current.c || nChar < current.c)
                    {
                        Console.WriteLine($"Neighbor is {nChar} and current is {current.c}");
                    }
                    if (nChar == current.c + 1 || nChar < current.c || nChar == current.c || neighbor.isEnd || current.isStart)
                    {
                        queue.Enqueue(neighbor);
                        visisted.Add(neighbor, true);
                        cellsInNextLayer++;
                    }
                }
                else 
                {
                    if (nChar == current.c - 1 || nChar == current.c || nChar > current.c)
                    {
                        Console.WriteLine($"Neighbor is {nChar} and current is {current.c}");
                    }
                    if (nChar == current.c - 1 || nChar > current.c || nChar == current.c || current.isStart)
                    {
                        queue.Enqueue(neighbor);
                        visisted.Add(neighbor, true);
                        cellsInNextLayer++;
                    }
                }
            }
        }

        public int solve() 
        {
            queue.Enqueue(start);
            visisted.Add(start, true);
            while (queue.Count > 0) 
            {
                Cell current = queue.Dequeue();
                if (current.isEnd)
                {
                    reachedEnd = true;
                    break;
                }
                else if (!part1 && current.c == 'a') 
                {
                    reachedEnd = true;
                    break;
                }
                exploreNeighbors(current);
                cellsLeftInLayer--;
                if (cellsLeftInLayer == 0) 
                {
                    cellsLeftInLayer = cellsInNextLayer;
                    cellsInNextLayer = 0;
                    moveCount++;
                }
            }
            if (reachedEnd) 
            {
                return moveCount;
            }
            return -1;
        }

        public Day_12(bool _part1) 
        {
            //update to be a list of lists of cells 
            part1 = _part1;
            grid = new List<List<Cell>>();
            queue = new Queue<Cell>();
            visisted = new Dictionary<Cell, bool>();
            int i = 0;
            foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_12/input.txt")) 
            {
                int j = 0;
                List<Cell> currentRow = new List<Cell>();
                foreach (char c in line) 
                {
                    //int x, int y, char c, bool isStart, bool isEnd)
                    if (c == 'S')
                    {
                        var currentCell = new Cell(j,i,c,true,false);
                        if (part1) 
                        {
                            start = currentCell;
                        }
                        currentRow.Add(currentCell);

                    }
                    else if (c == 'E')
                    {
                        var currentCell = new Cell(j, i, c, false, true);
                        if (part1)
                            end = currentCell;
                        else 
                        {
                            currentCell.isStart = true;
                            currentCell.isEnd = false;
                            start = currentCell;
                        }
                        currentRow.Add(currentCell);

                    }
                    else 
                    {
                        var currentCell = new Cell(j, i, c, false, false);
                        currentRow.Add(currentCell);

                    }
                    j++;
                }
                i++;
                grid.Add(currentRow);
            }
            rowCount = grid.Count;
            columnCount = grid[0].Count;

            reachedEnd = false;

            moveCount = 0;
            cellsLeftInLayer = 1;
            cellsInNextLayer = 0;

            result = solve();
        }
    }
}
