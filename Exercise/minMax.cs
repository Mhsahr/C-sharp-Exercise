using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace C_sharp_Exercise
{
    class minMax
    {
        public static void Run()
        { 
            List<int> numbers = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter a number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                numbers.Add(number);
            }
            {
                Console.WriteLine("The max number is {0} \n", numbers.Max());

                Console.WriteLine("The min number is {0} \n", numbers.Min());
            }
        } 
    }
}
