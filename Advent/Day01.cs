using System;
using System.Collections.Generic;

namespace Advent
{
    class Day01
    {
        /* Fuel required to launch a given module is based on its mass.
         * Specifically, to find the fuel required for a module, take its mass,
         * divide by three, round down, and subtract 2.
         */
        private static int FuelByMass(int mass)
        {
            return ((int)Math.Floor((double)mass / 3.0f)) - 2;
        }

        private static int TotalFuel(List<int> input)
        {
            int total = 0;
            foreach (int mass in input)
            {
                total += FuelByMass(mass);
            }

            return total;
        }

        /* So, for each module mass, calculate its fuel and add it to the
         * total. Then, treat the fuel amount you just calculated as the input
         * mass and repeat the process, continuing until a fuel requirement is
         * zero or negative.
         */
        private static int TotalFuelRecursive(List<int> input)
        {
            int total = 0;
            foreach (int mass in input)
            {
                int lastMass = mass;
                while (true)
                {
                    lastMass = FuelByMass(lastMass);

                    if (lastMass > 0)
                        total += lastMass;
                    else
                        break;
                }
            }

            return total;
        }

        public static void SolutionPart1()
        {
            List<int> input = Utility.PuzzleInputAsInt(@".\\Input\\Day01.txt");
            int solution = Day01.TotalFuel(input);

            Console.WriteLine($"Day 01, Part 1: {solution}");
        }

        public static void SolutionPart2()
        {
            List<int> input = Utility.PuzzleInputAsInt(@".\\Input\\Day01.txt");
            int solution = Day01.TotalFuelRecursive(input);

            Console.WriteLine($"Day 01, Part 2: {solution}");
        }
    }
}