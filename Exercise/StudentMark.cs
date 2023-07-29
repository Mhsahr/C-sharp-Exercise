using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_Exercise
{
    public class student_mark
    {
        public class Student
        {
            string firstname;
            string lastname;
            int score;
            int ID;
        }
        
        public class Classroom
        {
            public string teacherName;
            public string classSubject;
            public int studentNumber;
        }

        static void Main(string[] args)
        {
            int studentNumber = 0;

            Console.WriteLine("How many student do you have");
            studentNumber = GettingIntInput();

            List<Student> studentList = new List<Student>(studentNumber);

            while (studentNumber != 0)
            {
                var learner = new Student ();

                Console.WriteLine("firstname?");
                learner.firstname = GettingStringInput();

                Console.WriteLine("lastname?");
                learner.lastname = GettingStringInput();

                Console.WriteLine("score");
                learner.score = GettingIntInput();

                Console.WriteLine("ID");
                learner.ID = GettingIntInput();

                studentList.Add(learner);

                studentNumber--;
            }
            Console.WriteLine("Stop!");

            studentList.Sort((x, y) => x.score.CompareTo(y.score));

            foreach (Student item in studentList)
            {
                Console.WriteLine(item.score);
            }
        }

        static int GettingIntInput ()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        static string GettingStringInput()
        {
            return Console.ReadLine();
        }
    }

}
