using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CodingChallengeWeek3
{
    public class Menu
    {
        // list of choices for the menu
        private readonly string[] commands = { "IsEven", "MultTable", "Shuffle", "Quit" };

        // Writes out command numbers with corresponding command names
        private void DisplayMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Command Options");
            for (int i = 0; i < commands.Length; ++i)
                Console.WriteLine($"{i}: {commands[i]}");
            
            Console.WriteLine();
        }

        public void Run()
        {
            // run loop that keeps showing menu after each iteration
            // until user chooses to quit
            while (true)
            {
                // display options:
                DisplayMenu();

                // get user number corresponding to listed command
                Console.WriteLine("Command number required ");
                int command = GetUserInt();

                // display confirmation if it's a valid command
                if (command >= 0 && command < commands.Length)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{command} confirmed, Running {commands[command]}");
                    Console.WriteLine();
                }
               
                // match command with requested function and run it
                // sidenote: would be better reference the command array somehow
                switch(command)
                {
                    case 0: IsEven(); break;
                    case 1: MultTable(); break;
                    case 2: Shuffle(); break;
                    case 3: return;
                    default: Console.WriteLine($"Command {command} not recognized, "
                        + $"please choose a command number listed from the menu.");
                        break;
                }
            }
        }

        // helper function that gets an integer from a user
        private int GetUserInt()
        {
            int validNumber = 0;
            bool isValid = false;

            // loop until the user gives valid number
            do
            {
                Console.Write("Please enter an integer: ");
                string input = Console.ReadLine();

                // check the input
                // if true, validNumber is set to the input
                // if false, isValid is false and loops again
                isValid = int.TryParse(input, out validNumber);

                // message user if the integer input is incorrect
                if (!isValid)
                    Console.WriteLine($"{input} is a {input.GetType()}, not an integer.");

            } while (!isValid);

            return validNumber;
        }

        // overload of GetUserInt that takes in a minumum number
        // and returns a number higher than the minimum number
        private int GetUserInt(int min)
        {
            int userInt = min;
            while (true)
            {
                Console.WriteLine($"Integer greater than {min} required");
                userInt = GetUserInt();

                if (userInt > min)
                    break;
                else
                    Console.WriteLine($"Integer {userInt} is less than or equal to {min}");
                Console.WriteLine();
            }

            return userInt;
        }

        // gets user integer and displays a message if its even
        public void IsEven()
        {
            // get user input with helper function GetUserInt
            int inputNumber = GetUserInt();

            // determine the string prefix to be used in result
            // if the user input number is even, the prefix is empty
            // if it's not, then the prefix is 'not'
            string prefix = (inputNumber % 2 == 0) ? "" : "not ";

            // display result
            Console.WriteLine($"{inputNumber} is {prefix}an even number");
        }

        // gets user integer and displays the multiplication expressions
        // of 1 x 1 = 1 up to n x n = n^2
        public void MultTable()
        {
            // get user input with helper function GetUserInt
            // that must be higher than 0
            int inputNumber = GetUserInt(0);

            // go through each iteration of i x j = product
            for(int i=1; i <= inputNumber; ++i )
            {
                for(int j=1; j <= inputNumber; ++j)
                {
                    // display expression
                    Console.Write($"{i} x {j} = {i*j}, ");
                }
            }
        }

        // gets multiple user inputs up to the amount required
        // then returns all those items added in an ArrayList
        private ArrayList GetUserList(int amountRequired)
        {
            ArrayList userList = new ArrayList();

            // iterate amountRequired times
            for(int i=1; i<=amountRequired; ++i)
            {
                // determines if the inner loop will exit
                bool inputEmpty = true;

                // the ith item to be input by user and added to userList
                string userInput = "";

                while (inputEmpty)
                {

                    Console.Write($"Please enter item {i}: ");
                    userInput = Console.ReadLine();

                    // if userInput is not empty, the loop will end
                    if (userInput.Length > 0)
                        inputEmpty = false;
                    else
                        Console.WriteLine("item cannot be empty");
                }
                userList.Add(userInput);
            }

            return userList;
        }

        // takes all elements from an arraylist
        // and concatenates them into a string with brackets
        private string ListToString(ArrayList arraylist)
        {
            string result = "[";
            foreach (object item in arraylist)
                result += $"{item.ToString()}, ";
            result += "]";

            return result;
        }

        // get 2 lists of 5 elements(any type) from user
        // and display a message of list1 + list2 = 
        // a merge of both lists, alternating from list1 to list2
        public void Shuffle()
        {
            const int userListLength = 5;

            // get 2 lists done with helper function GetUserList
            Console.WriteLine("First List");
            ArrayList list1 = GetUserList( userListLength );
            Console.WriteLine();

            Console.WriteLine("Second List");
            ArrayList list2 = GetUserList( userListLength );
            Console.WriteLine();

            ArrayList mergedAlternatingList = new ArrayList();

            // merge lists taking turns left to right
            for (int i=0; i<userListLength; ++i)
            {
                mergedAlternatingList.Add(list1[i]);
                mergedAlternatingList.Add(list2[i]);
            }

            // display results
            Console.WriteLine(
                $"{ListToString( list1 )}"
                + $" + {ListToString( list2 )}"
                + $" = {ListToString( mergedAlternatingList )}"
            );
        }
    }
}
