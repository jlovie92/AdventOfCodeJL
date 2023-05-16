using AdventOfCodeJL.Days;
using System;
using System.Collections.Generic;

namespace AdventOfCodeJL
{
    class Program
    {
        static void Main()
        {
            List<AdventOfCodeSolution> solutions = new List<AdventOfCodeSolution>
            {
                new Day1AoC(),
                new Day2AoC(),
                new Day3AoC()
            };

            foreach (AdventOfCodeSolution sol in solutions)
            {
                String startString = "--------> Running Solution : " + sol.GetName() + "\n\n";
                System.Console.WriteLine(startString);
                sol.StartSolution();
            }

            System.Console.WriteLine("-------------------------------------------------------------- \ndone.");

            Console.ReadKey();
        }
    }
}
