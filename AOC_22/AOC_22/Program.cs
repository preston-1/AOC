// See https://aka.ms/new-console-template for more information
using Day_1;

bool topthree = true;
var res = new solution(topthree);
var final = topthree ? res._topThreeResult : res._result;
Console.WriteLine(final);