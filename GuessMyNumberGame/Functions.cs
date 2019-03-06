using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMyNumberGame
{
    class Functions
    {
        static int[] List = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int firstInd = 0;
        int midInd = (List.Length - 1) / 2;
        int lastInd = List.Length - 1;

        public int Bisection(int userInput)
        {
            if (userInput == List[midInd])
            {
                Console.WriteLine($"The number you chose was {List[midInd]}");
                return List[midInd];
            }
            else
            {
                if (userInput < List[midInd])
                {
                    //The midInd variable will never be equal to firstInd; this will avoid infinit loop
                    if (midInd == firstInd + 1)
                    {
                        Console.WriteLine($"The number you chose was {List[firstInd]}");
                        return List[firstInd];
                    }
                    else
                    {
                        Console.WriteLine($"The number you chose is less than {List[midInd]}");
                        lastInd = midInd;
                        midInd = firstInd + ((lastInd - firstInd) / 2);
                    }
                }
                else
                {
                    //The midInd variable will never be equal to lastInd; this will avoid infinit loop
                    if (midInd == lastInd - 1)
                    {
                        Console.WriteLine($"The number you chose was {List[lastInd]}");
                        return List[lastInd];
                    }
                    else
                    {
                        Console.WriteLine($"The number you chose is more than {List[midInd]}");
                        firstInd = midInd;
                        midInd += (lastInd - firstInd) / 2;
                    }
                }
                return Bisection(userInput);
            }
        }

        public int HumanPlay()
        {
            int bottom = 1;
            int top = 1000;
            Random randGen = new Random();
            int cpuNum = randGen.Next(1, 1000);

            Console.WriteLine("I have chosen a number from 1 to 1000. Guess it");

            int userInput = int.Parse(Console.ReadLine());
            int tries = 0;
            do
            {                
                if (userInput == cpuNum)
                {
                    Console.WriteLine($"You got it, the number was {userInput}");
                }
                else if (userInput < cpuNum)
                {
                    if (userInput <= bottom)
                    {
                        Console.WriteLine($"Did I mention its higher than {bottom}?");
                        userInput = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        bottom = userInput;
                        Console.WriteLine($"Too low, try guessing between {bottom} and {top}");
                        userInput = int.Parse(Console.ReadLine());
                    }
                }
                else
                {
                    if (userInput >= top)
                    {
                        Console.WriteLine($"Did I mention its lower than {top}?");
                        userInput = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        top = userInput;
                        Console.WriteLine($"Too high, try guessing between {bottom} and {top}");
                        userInput = int.Parse(Console.ReadLine());
                    }                    
                }
                tries++;
            } while (userInput != cpuNum);

            Console.WriteLine($"You got it, the number was {userInput}");
            Console.WriteLine($"Tries: {tries}");
            return userInput;
        }

        public int CpuPlay()
        {
            int cpuGuess = 1;
            int hint = 0;
            int top = 100;
            int bottom = 1;
            int tries = 0;

            do
            {
                if (tries > 8)
                {
                    Console.WriteLine("Either you're messing with me or you changed your number");
                    hint = 3;
                }
                else
                {
                    cpuGuess = bottom + ((top - bottom) / 2);
                    Console.WriteLine($"I'm guessing {cpuGuess}");
                    Console.WriteLine("Type 1 = Too high\n Type 2 = Too low\n Type 3 = Correct!");
                    hint = int.Parse(Console.ReadLine());
                    if (cpuGuess == top - 1 && hint == 2)
                    {
                        cpuGuess = top;
                        hint = 3;
                    }
                    else if (cpuGuess == bottom + 1 && hint == 1)
                    {
                        cpuGuess = bottom;
                        hint = 3;
                    }
                    else if (hint == 1)
                    {
                        top = cpuGuess;
                    }
                    else
                    {
                        bottom = cpuGuess;
                    }
                }
                tries++;
            } while (hint != 3);
            Console.WriteLine($"The answer is {cpuGuess}");
            Console.WriteLine($"Tries: {tries}");
            return cpuGuess;
        }
    }
}
