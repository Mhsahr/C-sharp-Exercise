using practice1.StudentMark.Models;
using System;
using System.Collections.Generic;

namespace practice1
{
    class Program
    {
        static void Run ()
        {
            int studentCounter = 0;

            Console.WriteLine("How many student do you have?");
            studentCounter = GettingIntInput();


            var course = new Course();

            for (int i = 0; i < studentCounter; i++)
            {
                Console.WriteLine("Enter the first name:");
                var fname = GettingStringInput();

                Console.WriteLine("Enter the last name:");
                var lname = GettingStringInput();

                Console.WriteLine("Enter the score:");
                var score = float.Parse(Console.ReadLine());

                Console.WriteLine("Enter the ID:");
                var id = GettingIntInput();

                var student = new Student(id, fname, lname, score);

                course.Students.Add(student);

            }

            Console.WriteLine("It is stopped.");
            course.Students.Sort((x, y) => x.Score.CompareTo(y.Score));

            foreach (Student item in course.Students)
            {
                Console.WriteLine(item.Score);
            }
        }

        static string GettingStringInput()
        {
            return Console.ReadLine();
        }
        static int GettingIntInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
