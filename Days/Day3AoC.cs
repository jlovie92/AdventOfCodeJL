using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeJL.Days
{
    class Day3AoC : AdventOfCodeSolution
    {
        public static readonly String PATH = "input/day3Input.txt";

        private readonly Dictionary<char, int> letterToCharacterMap = new Dictionary<char, int>();


        public Day3AoC() : this(PATH)
        {

        }

        private Day3AoC(string path) : base(path)
        {
            int letterValue = 1;
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                letterToCharacterMap.Add(letter, letterValue++);
            }

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                letterToCharacterMap.Add(letter, letterValue++);
            }
        }

        public override string GetName()
        {
            return "Day 3";
        }

        public override void StartSolution()
        {
            Part1();
            Part2();

        }

        private void Part2()
        {
            int runningTotal = 0;
            for (int i = 0; i < inputLines.Count - 1; i += 3)
            {
                // we do something to figure out the common letter in all three lines
                // Add the item priority score to the total and then repeat for all chunks

                SortedSet<char> c1Distinct = new SortedSet<char>(inputLines[i].Distinct());
                SortedSet<char> c2Distinct = new SortedSet<char>(inputLines[i + 1].Distinct());
                SortedSet<char> c3Distinct = new SortedSet<char>(inputLines[i + 2].Distinct());
                List<SortedSet<char>> theSets = new List<SortedSet<char>>() { c1Distinct, c2Distinct, c3Distinct };

                char? commonCharacter = Day3AoC.FindCommonCharacterInChunk(theSets);

                if (commonCharacter != null)
                {
                    runningTotal += letterToCharacterMap[(char)commonCharacter];
                }
            }

            System.Console.WriteLine("Part 2 result is.... : " + runningTotal);
        }

        private void Part1()
        {
            int total = 0;
            foreach (String line in inputLines)
            {
                int lastIndex = line.Length;
                String comp1 = line.Substring(0, lastIndex / 2);
                String comp2 = line.Substring(line.Length / 2);

                HashSet<char> lettersAppeared = new HashSet<char>();

                foreach (char letter in comp1)
                {
                    lettersAppeared.Add(letter);
                }

                foreach (char letter in comp2)
                {
                    if (lettersAppeared.Contains(letter))
                    {
                        total += letterToCharacterMap[letter];

                        break;
                    }
                }
            }

            System.Console.WriteLine("The Priority total is : " + total);
        }

        static char? FindCommonCharacterInChunk(List<SortedSet<char>> theSets)
        {

            SortedSet<char> largestSet = theSets[0];

            foreach (SortedSet<char> s in theSets)
            {
                if (s.Count > largestSet.Count)
                {
                    largestSet = s;
                }
            }

            theSets.Remove(largestSet);

            IEnumerator<char> largestEnumerator = largestSet.GetEnumerator();

            while (largestEnumerator.MoveNext())
            {
                char currentChar = largestEnumerator.Current;

                Boolean found = true;

                foreach (SortedSet<char> aSet in theSets)
                {
                    if (!aSet.Contains(currentChar))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return currentChar;
                }

            }
            return null;
        }
    }
}
