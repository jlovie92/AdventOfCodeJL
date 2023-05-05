using System;

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

            foreach (String line in inputLines)
            {
                if(!String.IsNullOrWhiteSpace(line))
                {

                    totalCalories += int.Parse(line);
                }
                else
                {
                    if(totalCalories > highestCalories)
                    {
                        highestCalories = totalCalories;
                    }

                    elf++;
                    totalCalories = 0;
                }
            }

            Console.WriteLine("The winner is: " + winner + " with a calorie total of: " + highestCalories);
        }
    }
}
