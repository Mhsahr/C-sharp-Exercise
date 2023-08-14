using System;

namespace C_sharp_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a right number for opening an application " +
                "1 for minMax " +
                "2 for name sorting " +
                "3 for student marks" +
                "4 for student app");
            int number =Convert.ToInt32 (Console.ReadLine());
            if (number == 1)
            {
                minMax.Run();
            }

            else if (number == 2)
            {
                NameListSorting.Run();
            }

            else if (number == 3)
            {
                studentMark.Run();
            }
             
            else if (number==4)
            {
                studentApp.Run();
            }
        }
    }
}
