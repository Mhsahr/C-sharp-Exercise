using CSV.Models;
using System;
using ConsoleTables;
using System.Linq;
using System.Text;
using System.Data;

//Install Package ConsoleTables version 2.4.1

namespace StudentMark.App
{
    class Table
    {

        public int Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public float score { get; set; }



        public static void MakeTable()
        {

            Console.OutputEncoding = Encoding.UTF8;
            var data = InitEmployee();
            string[] columnNames = data.Columns.Cast<DataColumn>()
                                   .Select(x => x.ColumnName)
                                   .ToArray();

            DataRow[] rows = data.Select();
            var table = new ConsoleTable(columnNames);
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            table.Write(Format.MarkDown);
            Console.Read();
        }
        public static DataTable InitEmployee()
        {
            int studentCounter = 0;

            Console.WriteLine("How many student are there?");
            studentCounter = Convert.ToInt32(Console.ReadLine());

            var course = new Course();
           

            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Firstname", typeof(string));
            table.Columns.Add("Lastname", typeof(string));
            table.Columns.Add("Score", typeof(float));

            Console.WriteLine("What is the teacher's name? ");
            string teacherName = Console.ReadLine();

            Console.WriteLine("What lesson is being taught? ");
            string lessonTopic = Console.ReadLine();

            int studentCount = studentCounter;


            for (int i = 0; i < studentCounter; i++)
            {
                Console.WriteLine("Enter Id: ");
                int Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter firstname: ");
                string fname = Console.ReadLine();

                Console.WriteLine("Enter lastname: ");
                string lname = Console.ReadLine();

                Console.WriteLine("Enter score: ");
                float score = float.Parse(Console.ReadLine());

                table.Rows.Add(Id, fname, lname, score);

                var student = new Student(Id, fname, lname, score);
                course.Students.Add(student);
            }

            Console.WriteLine("The name of the teacher is {0}, it is {1} and there are {2} students.", teacherName, lessonTopic, studentCount);

            Console.WriteLine("It is stopped.");

            course.Students.Sort((x, y) => x.Score.CompareTo(y.Score));

            foreach (Student item in course.Students)
            {
                Console.WriteLine(item.Score);
            }

            float average = course.GetAverageScore();
            Console.WriteLine($"The average is: {average}");

            return table;
        }
    }
}
