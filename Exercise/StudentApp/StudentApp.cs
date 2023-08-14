using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentMark.App
{
    class StudentApp
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

            choice = PromptUser("Do you want to save your work to a CSV file? (Y/n)");

            switch (choice.ToLower())
            {
                case "n":
                    Console.WriteLine("You can now close the program");
                    break;
                default:
                    var path = PromptUser("Enter path to file");
                    SaveData(path,students);
                    break;
            }


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
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The file could not be read.");
            }

        }
        static void SaveData(string path, List<Student> students)
        {
            var studentsAsCommaSeparated = students.Select(s => s.AsCommaSeparated());

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "students.csv")))
            {
                foreach (string line in studentsAsCommaSeparated)
                    outputFile.WriteLine(line);
            }
            

        }
        static List<Student> GetDataFromUser()
        {
            var students = new List<Student>();
            var studentCount = int.Parse(PromptUser("How many students do you want to enter"));
            for (var i=0;i< studentCount; i++)
            {
                var id = Convert.ToInt32(PromptUser($"Student[{i + 1}]: Enter ID: "));
                var fname = PromptUser($"Student[{i + 1}]: Enter Firstname: ");
                var lname = PromptUser($"Student[{i + 1}]: Enter Lastname: ");
                var score =float.Parse( PromptUser($"Student[{i + 1}]: Enter Score: "));
                var student = new Student() { Id = id, Firstname = fname,Lastname = lname, Score = score };
                students.Add(student);
            }
            return students;


        }

        static void PrintData(List<Student> data)
        {
            Console.WriteLine("ID\tFirstname\tLastname\tScore");
            Console.WriteLine("---------------------------------------------------------");
            foreach (var student in data)
            {
                Console.WriteLine($"{student.Id}\t{student.Firstname}\t\t{student.Lastname}\t\t{student.Score}");
            }

        }
    }

 

   


}
