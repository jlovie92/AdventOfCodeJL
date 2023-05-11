using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeJL.Days
{
    class Day2AoC : AdventOfCodeSolution
    {
        public static readonly String PATH = "input/day2Input.txt";

        private const char ROCK = 'A';

        private const char PAPER = 'B';

        private const char SCISSSORS = 'C';

        private Dictionary<char, char> win2LoseMap;
        private Dictionary<char, char> Lose2WinMap;

        private Day2AoC(String path) : base(path)
        {
            win2LoseMap = new Dictionary<char, char>();
            win2LoseMap.Add(ROCK,SCISSSORS);
            win2LoseMap.Add(SCISSSORS,PAPER);
            win2LoseMap.Add(PAPER,ROCK);

            Lose2WinMap = win2LoseMap.ToDictionary(x => x.Value, x => x.Key);
        }

        public Day2AoC() : this(PATH)
        {

        }

        public override void StartSolution()
        {
            int totalScore = 0;
            int roundOutcomeDeterminedScore = 0;
            foreach (String line in inputLines)
            {
                char[] splitBy = new char[] {
                ' '};
                String[] choices = line.Split(splitBy);

                char opponentChoice = char.Parse(choices[0]);
                char yourChoice = decryptChoice(char.Parse(choices[1]));

                char roundOutcomeChoice = decryptRoundEndChoice(opponentChoice, char.Parse(choices[1]));

                totalScore += getPlayerScore(opponentChoice, yourChoice);
                roundOutcomeDeterminedScore += getPlayerScore(opponentChoice,roundOutcomeChoice);


            }

            System.Console.WriteLine("Your total Rock Paper Scissors score is : " + totalScore);
            System.Console.WriteLine("Your total Rock Paper Scissors score determined by the round outcome is : " + roundOutcomeDeterminedScore);
        }

        private char decryptRoundEndChoice(char opponentChoice, char roundOutcome)
        {
            // x lose, y draw, z win
            if('X' == roundOutcome)
            {
                return win2LoseMap[opponentChoice];
            }
            else if ('Y' == roundOutcome)
            {
                return opponentChoice;
            }
            else if ('Z' == roundOutcome)
            {
                return Lose2WinMap[opponentChoice];
            }

            return 'L';
        }

        private static char decryptChoice(char choice)
        {
            char decryptedChoice = 'N';

            if ('X' == choice)
            {
                decryptedChoice = ROCK;
            } else if ('Y' == choice)
            {
                decryptedChoice = PAPER;
            } else if('Z' == choice)
            {
                decryptedChoice = SCISSSORS;
            }

            return decryptedChoice;
        }

        public int getPlayerScore(char opponentChoice, char playerChoice)
        {
            int score = getShapeValue(playerChoice);

            bool youWin = win2LoseMap[playerChoice] == opponentChoice;


            if (youWin)
            {
                score += 6;
            }else if(playerChoice == opponentChoice)
            {
                score += 3;
            }

            return score;
        }

        private int getShapeValue(char shape)
        {
            int shapeScore;

            switch (shape)
            {
                case Day2AoC.ROCK:
                    shapeScore = 1;
                    break;
                case Day2AoC.PAPER:
                    shapeScore = 2;
                    break;
                case Day2AoC.SCISSSORS:
                    shapeScore = 3;
                    break;
                default:
                    shapeScore = 0;
                    break;
            };

            return shapeScore;
        }

    public override string getName()
        {
            return "Day 2";
        }
    }
}
