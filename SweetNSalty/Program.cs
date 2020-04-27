using System;

namespace SweetNSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            // In order to display the amount sweet, salty, sweet'nSalty 
            // these variables will be used to store the amount
            int sweet = 0;
            int salty = 0;
            int sweetNSalty = 0;

            // loop through 1-100 numbers, printing each number except for
            // multiples of 3, print and increment "sweet"
            // multiples of 5, print and increment "salty"
            // and multiple of 3 and 5, print and increment "sweet'nSalty"
            // and increment sweet and salty
            for(int i = 1; i<=100; ++i)
            {
                // check both cases first so it doesn't get skipped
                // if it were last, it would get skipped after passing one of its conditions
                if( i%3 == 0 && i%5 == 0)
                {
                    Console.Write("sweet'nSalty's");
                    ++sweetNSalty;
                    ++sweet;
                    ++salty;
                }
                else if( i%3 == 0 )
                {
                    Console.Write("sweet");
                    ++sweet;
                }
                else if( i%5 == 0 )
                {
                    Console.Write("salty");
                    ++salty;
                }
                else
                {
                    Console.Write(i);
                }

                // for formatting: 
                // after 10 outputs, insert a line 
                if( i%10 == 0 )
                {
                    Console.WriteLine();
                } 
                else // for every other output, insert a space
                {
                    Console.Write(" ");
                }
            }

             // empty lines are to see output better
            Console.WriteLine();

            // output final tally of "sweet", "salty", "sweet'nSalty's"
            Console.WriteLine($"There are {sweet} sweet, {salty} salty, and {sweetNSalty} sweet'nSalty's.");
            Console.WriteLine();
        }
    }
}
