using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_11
{
    internal class Day_11
    {
        static int Gfc(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int Lcm(int a, int b)
        {
            return (a / Gfc(a, b)) * b;
        }

        public List<Monkey> PlayRound(List<Monkey> monkeys, bool part1)
        {
            var modifiedMonkeys = monkeys;
            foreach (var monkey in monkeys)
            {
                if (monkey.items.Count >= 1)
                {
                    while (monkey.items.Count != 0) 
                    {
                        monkey.inspectionCount++;
                        int inspectedItem = monkey.items[0];
                        monkey.items.RemoveAt(0);
                        if (monkey.old)
                        {
                            monkey.operationValue = inspectedItem;
                        }
                        int lcm = Lcm(inspectedItem, monkey.operationValue);
                        int wlMult = 0;
                        if (part1)
                        {
                            wlMult = monkey.operation == "+" ? inspectedItem + monkey.operationValue : inspectedItem * monkey.operationValue;
                        }
                        else 
                        {
                            wlMult = monkey.operation == "+" ? inspectedItem + monkey.operationValue : inspectedItem * lcm;
                        }
                        //somehow reduce the prime number to stay prime....
                        int truncated = part1 ? (int)Math.Truncate((double)wlMult / 3) : wlMult;
                        // if prime1 % prime == 0 then prime1 is not a prime number
                        if (truncated % monkey.test == 0)
                        {
                            modifiedMonkeys[monkey.throwTrue].items.Add(truncated);
                        }
                        else
                        {
                            modifiedMonkeys[monkey.throwFalse].items.Add(truncated);
                        }
                    }
                }
            }
            return modifiedMonkeys;
        }

        public class Monkey 
        {
            public int id { get; set; }
            public List<int> items { get; set; }

            public int operationValue { get; set; }

            public string operation { get; set; }
            
            public int test { get; set; }

            public int throwTrue { get; set; }
            
            public int throwFalse { get; set; }

            public int inspectionCount { get; set; }

            public bool old { get; set; }

            

            public Monkey(int Id, List<int> Items, string OperationValue, string Operation, int Test, int ThrowTrue, int ThrowFalse)
            {
                id = Id;
                items = Items;
                if (OperationValue == "old")
                {
                    operationValue = 0;
                    old = true;
                }
                else
                {
                    operationValue = int.Parse(OperationValue);
                }
                operation = Operation;
                test = Test;
                throwTrue = ThrowTrue;
                throwFalse = ThrowFalse;
                inspectionCount = 0;
            }

        }
        public int result { get; set; }

        public Day_11(bool part1) 
        {
            int lineCounter = 0;
            int monkeyNum = 0;
            List<int> startingItems = new List<int>();
            string operation = "";
            string operationValue = "";
            int test = 0;
            int trueTest = 0;
            int falseTest = 0;
            List<Monkey> monkeyList = new List<Monkey>();
            foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_11/test_input.txt")) 
            {
                if (lineCounter == 0)
                {
                    //get monkey number
                    string[] splits = line.Split(" ");
                    string num = splits[1];
                    monkeyNum = int.Parse(num.Remove(num.Length-1,1));
                }
                else if (lineCounter == 1)
                {
                    //get monkey starting items
                    string[] splits = line.Split(":");
                    string[] nums = splits[^1].Split(",");
                    foreach (var num in nums) 
                    {
                        startingItems.Add(int.Parse(num));
                    }
                }
                else if (lineCounter == 2)
                {
                    //get operation
                    string[] splits = line.Split(" ");
                    operation = splits[^2];
                    operationValue = splits[^1];
                }
                else if (lineCounter == 3)
                {
                    //get test
                    string[] splits = line.Split(" ");
                    test = int.Parse(splits[^1]);
                }
                else if (lineCounter == 4)
                {
                    //get true case
                    string[] splits = line.Split(" ");
                    trueTest = int.Parse(splits[^1]);
                }
                else if (lineCounter == 5)
                {
                    //get false case
                    string[] splits = line.Split(" ");
                    falseTest = int.Parse(splits[^1]);
                }
                else if(line == "")
                {
                    //int Id, List<int> Items, string OperationValue, string Operation, int Test, int ThrowTrue, int ThrowFalse
                    //build Monkey using all of your strings
                    monkeyList.Add(new Monkey(monkeyNum,startingItems, operationValue, operation, test, trueTest, falseTest));
                    //set strings back to nothing I guess...
                    lineCounter = -1;
                    monkeyNum = 0;
                    startingItems = new List<int>();
                    operation = "";
                    operationValue = "";
                    test = 0;
                    trueTest = 0;
                    falseTest = 0;
                }
                lineCounter++;
            }
            //last one needs to be added
            monkeyList.Add(new Monkey(monkeyNum, startingItems, operationValue, operation, test, trueTest, falseTest));
            int upTo = part1 ? 20 : 10000;
            for (int i = 0; i < upTo; i++) 
            {
                if (i == 1 || i == 20 || i == 1000 || i == 2000) 
                {
                    Console.WriteLine($"-- After Round {i} --");
                    foreach (var m in monkeyList) 
                    {
                        Console.WriteLine($"monkey: {m.id} inspected items {m.inspectionCount} times.");
                    }
                    Console.WriteLine("");
                }
                monkeyList = PlayRound(monkeyList, part1);
                
            }
            var topTwo = monkeyList.OrderByDescending(e => e.inspectionCount).Take(2).ToList();
            result = topTwo[0].inspectionCount * topTwo[1].inspectionCount;
        }
    }
}
