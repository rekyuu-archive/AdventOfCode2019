using System;
using System.Collections.Generic;

namespace Advent
{
    class Utility
    {
        public static List<int> PuzzleInputAsInt(string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            List<int> output = new List<int>();

            foreach (string line in lines)
            {
                output.Add(Int32.Parse(line));
            }

            return output;
        }
    }
}