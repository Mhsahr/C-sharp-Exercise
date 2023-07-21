using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_Exercise
{
    public class student_mark
    {
        private static IEnumerable<Student> studentList;

        public class Student
        {
            public string firstName;
            public string lastName;
            public int score;
            public int ID;
        }
        public class Classroom
        {
            public string teacherName;
            public string lessonTopic;
            public string studentNumber;
        }


        public static void Run()
        {
            int studentNumber = 0;

            Console.WriteLine("How many student do you have?");
            studentNumber = GettingIntInput();



            List<Student> studentList = new List<Student>(studentNumber);


            while (studentNumber != 0)
            {
                var learner = new Student();


                Console.WriteLine("Enter the first name:");
                learner.firstName = GettingStringInput();

                Console.WriteLine(learner.lastName = "Enter the last name:");
                learner.lastName = GettingStringInput();

                Console.WriteLine("Enter the score:");
                learner.score = GettingIntInput();

                Console.WriteLine("Enter the ID:");
                learner.ID = GettingIntInput();

                studentList.Add(learner);


                studentNumber--;


            }
            Console.WriteLine("you can not go through");
            studentList.Sort((x, y) => x.score.CompareTo(y.score));

            foreach (Student item in studentList)
            {
                Console.WriteLine(item.score);
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
