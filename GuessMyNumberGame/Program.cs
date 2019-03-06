using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMyNumberGame
{
    class Program
    {

        static void Main(string[] args)
        {

            Functions myFunction = new Functions();

            //Console.WriteLine("Please select a number from 1 to 10");

            //myFunction.Bisection(int.Parse(Console.ReadLine()));

            //Console.WriteLine("\nNow you play");

            //myFunction.HumanPlay();

            Console.WriteLine("\nChoose a number from 1 to 100 and I'll guess it");
            //Console.ReadLine();
            myFunction.CpuPlay();


        }
    }
}
