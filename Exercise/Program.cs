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
                "3 for student marks");
            int number =Convert.ToInt32 (Console.ReadLine());
            if (number == 1)
            {
                minMax.Run();
            }

            else if (number == 2)
            {
                nameList_Sorting.Run();
            }

            else if (number == 3)
            {
                student_mark.Run();
            }


        }
    }
}
