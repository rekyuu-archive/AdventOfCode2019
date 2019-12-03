using System;
using System.Collections.Generic;

namespace Advent
{
    class IntcodeResult
    {
        public bool Found { get; set; } = false;
        public int Noun { get; set; } = -1;
        public int Verb { get; set; } = -1;
    }

    class Day02
    {
        private static int IntcodeParse(int opCode, int x, int y)
        {
            // Add the two inputs together
            if (opCode == 1)
            {
                return x + y;
            }
            // Multiply the two inputs together
            else
            {
                return x * y;
            }
        }

        private static int IntcodeProgram(List<int> intCodes)
        {
            int pos = 0;
            while (true)
            {
                int opCode = intCodes[pos];
                if (opCode == 1 || opCode == 2)
                {
                    int x = intCodes[intCodes[pos + 1]];
                    int y = intCodes[intCodes[pos + 2]];

                    // Store the output at the specified position.
                    intCodes[intCodes[pos + 3]] = IntcodeParse(opCode, x, y);
                }
                else if (opCode == 99)
                {
                    // Program finished.
                    break;
                }
                else
                {
                    // Error ocurred.
                    Console.WriteLine($"Invalid OpCode: {opCode}");
                    break;
                }

                // Ready the next OpCode.
                pos += 4;
            }

            return intCodes[0];
        }

        private static IntcodeResult IntcodeSearch(List<int> intCodes, int search)
        {
            for (int n = 0; n <= 99; n++)
            {
                for (int v = 0; v <= 99; v++)
                {
                    List<int> intCodesCopy = new List<int>(intCodes);

                    intCodesCopy[1] = n;
                    intCodesCopy[2] = v;

                    int output = IntcodeProgram(intCodesCopy);
                    if (output == search)
                    {
                        return new IntcodeResult(){
                            Found = true,
                            Noun = n,
                            Verb = v
                        };
                    }
                }
            }

            return new IntcodeResult();
        }

        /* Once you have a working computer, the first step is to restore the
         * gravity assist program (your puzzle input) to the "1202 program
         * alarm" state it had just before the last computer caught fire. To do
         * this, before running the program, replace position 1 with the value
         * 12 and replace position 2 with the value 2.
         */
        public static void SolutionPart1()
        {
            List<int> intCodes = new List<int>(){1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,2,19,6,23,2,13,23,27,1,9,27,31,2,31,9,35,1,6,35,39,2,10,39,43,1,5,43,47,1,5,47,51,2,51,6,55,2,10,55,59,1,59,9,63,2,13,63,67,1,10,67,71,1,71,5,75,1,75,6,79,1,10,79,83,1,5,83,87,1,5,87,91,2,91,6,95,2,6,95,99,2,10,99,103,1,103,5,107,1,2,107,111,1,6,111,0,99,2,14,0,0};

            intCodes[1] = 12;
            intCodes[2] = 2;

            int solution = IntcodeProgram(intCodes);

            Console.WriteLine($"Day 02, Part 1: {solution}");
        }

        /* The inputs should still be provided to the program by replacing the
         * values at addresses 1 and 2, just like before. In this program, the
         * value placed in address 1 is called the noun, and the value placed
         * in address 2 is called the verb. Each of the two input values will
         * be between 0 and 99, inclusive.
         *
         * Once the program has halted, its output is available at address 0,
         * also just like before. Each time you try a pair of inputs, make sure
         * you first reset the computer's memory to the values in the program
         * (your puzzle input) - in other words, don't reuse memory from a
         * previous attempt.
         *
         * Find the input noun and verb that cause the program to produce the
         * output 19690720. What is 100 * noun + verb?
         */
        public static void SolutionPart2()
        {
            List<int> intCodes = new List<int>(){1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,2,19,6,23,2,13,23,27,1,9,27,31,2,31,9,35,1,6,35,39,2,10,39,43,1,5,43,47,1,5,47,51,2,51,6,55,2,10,55,59,1,59,9,63,2,13,63,67,1,10,67,71,1,71,5,75,1,75,6,79,1,10,79,83,1,5,83,87,1,5,87,91,2,91,6,95,2,6,95,99,2,10,99,103,1,103,5,107,1,2,107,111,1,6,111,0,99,2,14,0,0};

            IntcodeResult result = IntcodeSearch(intCodes, 19690720);
            int solution = result.Noun * 100 + result.Verb;

            Console.WriteLine($"Day 02, Part 2: {solution}");
        }
    }
}