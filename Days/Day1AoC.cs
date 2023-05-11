using System;
using System.Collections.Generic;

namespace AdventOfCodeJL.Days
{
    class Day1AoC : AdventOfCodeSolution
    {
        public static readonly String PATH = "input/day1Input.txt";
        private Day1AoC(String path) : base(path)
        {
            
        }

        public Day1AoC() : this(PATH)
        {

        }

        public override void StartSolution()
        {
            int elf = 1;

            int winner = elf;
            int highestCalories = 0;

            int totalCalories = 0;

            List<int> topCalories = new List<int>();

            int index = 0;
            foreach (String line in inputLines)
            {
                if(!String.IsNullOrWhiteSpace(line))
                {

                    totalCalories += int.Parse(line);
                }
                else
                {
                    topCalories.Add(totalCalories);
                    if (totalCalories > highestCalories)
                    {
                        highestCalories = totalCalories;
                    }
                    elf++;
                    totalCalories = 0;
                }

                if ((inputLines.Count -1) == index)
                {
                    topCalories.Add(totalCalories);
                }
                index++;
            }
            topCalories.Sort();
            Console.WriteLine("The winner is: " + winner + " with a calorie total of: " + highestCalories);
            int listIndex = topCalories.Count-1;
            int elf1 = topCalories[listIndex--];
            int elf2 = topCalories[listIndex--];
            int elf3 = topCalories[listIndex--];
            Console.WriteLine("Part two answer is:" + (elf1 + elf2 + elf3));
        }

        public override string getName()
        {
            return "Day 1";
        }
    }
}
