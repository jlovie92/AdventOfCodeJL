using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeJL
{
    class FileInputReader
    {
        public static List<String> ReadTextFile(String path)
        {
            List<String> lines = new List<String>();

            StreamReader sr = new StreamReader(path);

            String line;
            try
            {
                line = sr.ReadLine();

                while(line != null)
                {
                    lines.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return lines;
        }
    }
}
