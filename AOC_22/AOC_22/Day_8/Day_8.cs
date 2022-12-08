using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_8
{
    public class Day_8
    {
        public int result { get; set; }

        bool checkUp(List<List<int>> grid, int i, int j) 
        {
            int currentVal = grid[i][j];
            while (i > 0) 
            {
                if (currentVal <= grid[i - 1][j]) 
                {
                    return false;
                }
                i--;
            }
            return true;
        }
        bool checkDown(List<List<int>> grid, int i, int j)
        {
            int currentVal = grid[i][j];
            while (i < grid.Count-1)
            {
                if (currentVal <= grid[i + 1][j])
                {
                    return false;
                }
                i++;
            }
            return true;
        }
        bool checkLeft(List<List<int>> grid, int i, int j)
        {
            int currentVal = grid[i][j];
            while (j > 0)
            {
                if (currentVal <= grid[i][j-1])
                {
                    return false;
                }
                j--;
            }
            return true;
        }

        bool checkRight(List<List<int>> grid, int i, int j)
        {
            int currentVal = grid[i][j];
            while (j < grid[i].Count-1)
            {
                if (currentVal <= grid[i][j + 1])
                {
                    return false;
                }
                j++;
            }
            return true;
        }

        int getUp(List<List<int>> grid, int i, int j)
        {
            int count = 0;
            int currentVal = grid[i][j];
            while (i > 0)
            {
                count++;
                if (currentVal <= grid[i - 1][j])
                {
                    return count;
                }
                i--;
            }
            return count;
        }
        int getDown(List<List<int>> grid, int i, int j)
        {
            int count = 0;
            int currentVal = grid[i][j];
            while (i < grid.Count - 1)
            {
                count++;
                if (currentVal <= grid[i + 1][j])
                {
                    return count;
                }
                i++;
            }
            return count;
        }
        int getLeft(List<List<int>> grid, int i, int j)
        {
            int count = 0;
            int currentVal = grid[i][j];
            while (j > 0)
            {
                count++;
                if (currentVal <= grid[i][j - 1])
                {
                    return count;
                }
                j--;
            }
            return count;
        }

        int getRight(List<List<int>> grid, int i, int j)
        {
            int count = 0;
            int currentVal = grid[i][j];
            while (j < grid[i].Count - 1)
            {
                count++;
                if (currentVal <= grid[i][j + 1])
                {
                    return count;
                }
                j++;
            }
            return count;
        }

        public Day_8(bool part1)
        {
            int x,y,sum;
            if (part1)
            {
                List<List<int>> grid = new List<List<int>>();
                foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_8/input.txt"))
                {
                    List<int> row = new List<int>();
                    foreach (char c in line)
                    {
                        row.Add(int.Parse(c.ToString()));
                    }
                    grid.Add(row);
                }
                x = grid[0].Count() - 1;
                y = grid.Count() - 1;
                sum = 0;
                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[i].Count; j++)
                    {
                        //if on edge
                        if (i == 0 || i == y || ((i != 0 && i != y) && j == 0 || j == x))
                        {
                            sum++;
                        }
                        else
                        {
                            if (checkUp(grid, i, j) || checkDown(grid, i, j) || checkLeft(grid, i, j) || checkRight(grid, i, j))
                            {
                                sum++;
                            }
                        }
                    }
                }
                result = sum;
            }
            else 
            {
                List<List<int>> grid = new List<List<int>>();
                List<int> scenicScores = new List<int>();
                foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_8/input.txt"))
                {
                    List<int> row = new List<int>();
                    foreach (char c in line)
                    {
                        row.Add(int.Parse(c.ToString()));
                    }
                    grid.Add(row);
                }
                x = grid[0].Count() - 1;
                y = grid.Count() - 1;
                sum = 0;
                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[i].Count; j++)
                    {
                        //if on edge
                        if (i == 0 || i == y || ((i != 0 && i != y) && j == 0 || j == x))
                        {
                            sum++;
                        }
                        else
                        {
                            int u = getUp(grid, i, j);
                            int d = getDown(grid, i, j);
                            int l = getLeft(grid, i, j);
                            int r = getRight(grid, i, j);
                            scenicScores.Add(u * d * l * r);
                        }
                    }
                }
                result = scenicScores.Max();
            }
           
        }
    }
}
