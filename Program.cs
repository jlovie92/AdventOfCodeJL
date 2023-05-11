using AdventOfCodeJL.Days;
using System;
using System.Collections.Generic;

namespace AdventOfCodeJL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AdventOfCodeSolution> solutions = new List<AdventOfCodeSolution>();
            solutions.Add(new Day1AoC());
            solutions.Add(new Day2AoC());

            foreach(AdventOfCodeSolution sol in solutions)
            {
                String startString = "--------> Running Solution : " + sol.getName() +"\n\n";
                System.Console.WriteLine(startString);
                sol.StartSolution();
            }
            
            Console.ReadKey();
        }
    }
}
