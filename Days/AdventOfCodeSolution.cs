using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace AdventOfCodeJL.Days
{
    abstract class AdventOfCodeSolution
    {
        public readonly List<string> inputLines;

        public AdventOfCodeSolution(String path)
        {
            inputLines = FileInputReader.ReadTextFile(path);
        }

        abstract public void StartSolution();
    }
}
