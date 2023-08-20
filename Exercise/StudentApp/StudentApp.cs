using ConsoleApp4;
using ConsoleApp4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentMark.App
{
    class Program
    {

        static void Run()
        {
            List<Student> students = null;
            Console.WriteLine("Welcome to Mahsa Student Management System v2.5.0");
            var choice = PromptUser("Do you want to load from previously saved CSV file? (y/N)");

            switch (choice.ToLower())
            {
                case "y":
                    Console.WriteLine("Enter path to file");
                    var path = Console.ReadLine();
                    LoadData(path);

                    students = GetDataFromUser();

                    break;
                default:
                    students = GetDataFromUser();
                    break;
            }
            PrintData(students);
            Sort(students);

            DoStuff(students);
        }
        static string PromptUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();

        }
        static void LoadData(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    var content = reader.ReadToEnd();

                    var students = new List<Student>();
                    var rows = content.Split("\r\n");
                    rows = rows.SkipLast(1).ToArray();


                    foreach (var line in rows)
                    {
                        var cols = line.Split(',');
                        int id = int.Parse(cols[0]);
                        float score = float.Parse(cols[3]);

                        var student = new Student()
                        {
                            Id = id,
                            Firstname = cols[1],
                            Lastname = cols[2],
                            Score = score,

                        };

                        students.Add(student);

                    }
                    Console.WriteLine(String.Join(",\r\n", rows));
                }
            }

            catch (Exception)
            {
                Console.WriteLine("The file can not be read.");
            }


        }

        static void SaveData(string path, List<Student> students)
        {

            var studentsAsCommaSeparated = students.Select(s => s.AsCommaSeparated());

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "students.csv")))

            {
                //outputFile.WriteLine("ID, Firstname, Lastname, Score");

                foreach (string line in studentsAsCommaSeparated)
                    outputFile.WriteLine(line);

            }


        }
        static List<Student> GetDataFromUser()
        {
            var students = new List<Student>();
            int studentCounter = Convert.ToInt32(PromptUser("How many students are there? "));

            for (var i = 0; i < studentCounter; i++)
            {
                var id = Convert.ToInt32(PromptUser($"Student[{i + 1}]: Enter ID: "));
                var fname = PromptUser($"Student[{i + 1}]: Enter Firstname: ");
                var lname = PromptUser($"Student[{i + 1}]: Enter Lastname: ");
                var score = float.Parse(PromptUser($"Student[{i + 1}]: Enter Score: "));
                var student = new Student() { Id = id, Firstname = fname, Lastname = lname, Score = score };
                students.Add(student);
            }

            return students;



        }

        static void PrintData(List<Student> data)
        {
            Console.WriteLine("ID\tFirstname\tLastname\tScore");
            Console.WriteLine("---------------------------------------------------------");
            foreach (var learner in data)
            {
                Console.WriteLine($"{learner.Id}\t{learner.Firstname}\t\t{learner.Lastname}\t\t{learner.Score}");
            }

        }

        public static void Sort(List<Student> students)
        {
            students.Sort((x, y) => x.Score.CompareTo(y.Score));

            foreach (Student item in students)
            {
                Console.WriteLine(item.Score);
            }

        }

        static void DoStuff(List<Student> students)
        {
            var choice = PromptUser("Do you want to load from previously saved CSV file? (y/N)");

            switch (choice.ToLower())
            {
                case "n":
                    Console.WriteLine("You can now close the program");
                    break;
                default:
                    var path = PromptUser("Enter path to file");
                    SaveData(path, students);
                    Console.WriteLine("The file has been saved.");
                    break;
            }
        }
    }






}
