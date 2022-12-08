using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_7
{
    public class Day_7
    {
        public class file 
        {
            public List<file>? children { get; set; }
            public int filesize { get; set; }

            public string? dirName { get; set; }
            public bool isDir { get; set; }
            public bool isRoot { get; set; }
            public file? parent { get; set; }

            //dir
            public file(string _fileInfo, file _parent)
            {
                isDir = true;
                dirName = _fileInfo.Split(" ")[1];
                parent = _parent;
                children = new List<file>();
            }
            //file
            public file(string _fileInfo) 
            {
                isDir = false;
                filesize = int.Parse(_fileInfo.Split(" ")[0]);
            }
            //root
            public file(bool isroot) 
            {
                children = new List<file>();
                isDir = true;
                isRoot = isroot;
            }
        }

        public int result { get; set; }
        public Day_7(bool part1) 
        {
            bool atRoot = true;
            file root = new file(true);
            file pwd = new file(false);
            foreach (var line in File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_7/input.txt")) 
            {
                string[] splits = line.Split(" ");
                //command
                if (splits[0] == "$")
                {
                    if (splits[1] == "ls")
                    {
                        //do nothing
                        continue;
                    }
                    else if (splits[1] == "cd")
                    {
                        if (splits[2] == "/") 
                        {
                            //cd /
                            pwd = root;
                            atRoot = true;
                        }
                        else if (splits[2] == "..")
                        {
                            //cd ..
                            pwd = pwd.parent;
                        }
                        else
                        {
                            //cd <something>
                            foreach (file child in pwd.children)
                            {
                                if (child.isDir && child.dirName == splits[2])
                                {
                                    pwd = child;
                                    atRoot = false;
                                }
                            }
                        }
                    }
                }
                //files
                else
                {
                    if (line.Split(" ")[0] == "dir")
                    {
                        if (atRoot)
                            root.children.Add(new file(line, root));
                        else
                            pwd.children.Add(new file(line, pwd));
                    }
                    else 
                    {
                        pwd.children.Add(new file(line));
                    }
                }
            }
            int totalcount = 0;
            int currentCount = 0;
            if (part1)
            {
                recursiveCountP1(root.children, ref currentCount, ref totalcount);
                result = totalcount;
            }
            else 
            {
                List<int> dirSizes = new List<int>();
                recursiveCountP2(root.children, ref currentCount, ref totalcount, ref dirSizes);
                int sum = dirSizes.Last();
                int dirSizeToRemove = 30000000 - (70000000 - sum);
                result = dirSizes.Where(e => e >= dirSizeToRemove).ToList().Min();
            }
           
        }


        public int recursiveCountP1(List<file> files, ref int current, ref int total) 
        {
            int localCounter = 0;
            foreach(var file in files) 
            {
                if (file.isDir)
                {
                    localCounter += recursiveCountP1(file.children, ref current, ref total);
                }
                else 
                {
                    localCounter += file.filesize;
                }
            }
            if (localCounter <= 100000) 
            {
                total += localCounter;
                current += localCounter;
            }
            return total;
        }

        public int recursiveCountP2(List<file> files, ref int current, ref int total, ref List<int> dirSizes)
        {
            int localCounter = 0;
            foreach (var file in files)
            {
                if (file.isDir)
                {
                    localCounter += recursiveCountP2(file.children, ref current, ref total, ref dirSizes);
                }
                else
                {
                    localCounter += file.filesize;
                }
            }
            total = localCounter;
            dirSizes.Add(localCounter);
            return total;
        }
    }
}
