using System;
using System.Collections.Generic;

namespace AdventOfCodeJL.Days
{
    public abstract class AdventOfCodeSolution
    {
        public readonly List<string> inputLines;

        public AdventOfCodeSolution(String path)
        {
            inputLines = FileInputReader.ReadTextFile(path);
        }

        abstract public void StartSolution();

        abstract public String GetName();
    }
}
