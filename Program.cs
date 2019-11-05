using System;
using System.CommandLine.DragonFruit;

namespace stayawake
{
    class Program
    {
        /// <summary>DragonFruit simple example program</summary>
        /// <param name="verbose">Show verbose output</param>
        /// <param name="flavor">Which flavor to use?</param>
        /// <param name="count">How many smoothies?</param>
        static int Main(bool verbose, string flavor = "strawberry", int count = 1)
        {
            if (verbose)
            {
                Console.WriteLine("Running now in verbose mode!");
            }
        
            Console.WriteLine($"Creating {count} banana {(count == 1 ? "smoothie" : "smoothies")} with {flavor}");
            return 0;
        }
    }
}
