using System;

namespace AdventOfCodeJL.Days
{
    class Day4AoC : AdventOfCodeSolution
    {
        public static readonly String PATH = "input/day4Input.txt";

        public Day4AoC() : this(PATH)
        {

        }

        private Day4AoC(string path) : base(path)
        {

        }

        public override string GetName()
        {
            return "Day 4";
        }

        public override void StartSolution()
        {
            int count = 0;
            int overlapCount = 0;
            foreach (string line in inputLines)
            {
                string[] pair = line.Split(',');

                string[] firstRange = pair[0].Split('-');
                string[] secondRange = pair[1].Split('-');

                Section sectionOne = new Section(int.Parse(firstRange[0]), int.Parse(firstRange[1]));
                Section sectionTwo = new Section(int.Parse(secondRange[0]), int.Parse(secondRange[1]));

                if (sectionOne.IsSectionFullyInRange(sectionTwo) || sectionTwo.IsSectionFullyInRange(sectionOne))
                {
                    count++;
                }
                if (sectionOne.IsOverlapped(sectionTwo) || sectionTwo.IsOverlapped(sectionOne))
                {
                    overlapCount++;
                }
            }

            System.Console.WriteLine("The occurances where one section is fully in range of the other section are " + count + " out of " + inputLines.Count + " pairs.");
            System.Console.WriteLine("The occurances where one section is overlaps another section are " + overlapCount + " out of " + inputLines.Count + " pairs.");
        }
    }

    class Section
    {
        private int StartSection { get; }
        private int EndSection { get; }

        public Section(int start, int end)
        {
            this.StartSection = start;
            this.EndSection = end;
        }

        public bool IsSectionFullyInRange(Section section)
        {
            return IsInRange(section.StartSection) && IsInRange(section.EndSection);
        }

        public bool IsOverlapped(Section section)
        {
            return IsInRange(section.StartSection) || IsInRange(section.EndSection);
        }

        private bool IsInRange(int number)
        {
            return number >= StartSection && number <= EndSection;
        }

        public override string ToString()
        {
            return "start : " + this.StartSection + " end: " + this.EndSection;
        }
    }
}
