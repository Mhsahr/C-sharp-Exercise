using ConsoleApp4.Models;
using ConsoleApp4.Services;
using ConsoleApp4.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Controllers
{
    class ClassController
    {
        private readonly StudentService studentService;
        public ClassController()
        {
            studentService = new StudentService();
        }
        public void Run()
        {
            var myClass = new Class();
            Console.WriteLine("Welcome to Mahsa Student Management System v2.5.0");

            ConsoleUtils.PromptYesNoOptionAndAct("Do you want to load from previously saved CSV file? (y/N)", () =>
            {
                Console.WriteLine("Enter path to file");
                var path = Console.ReadLine();
                myClass.Students = studentService.LoadData(path);

            }, () => myClass.Students = GetDataFromUser(),
            "N"
        );

            PrintData(myClass.Students);
            myClass.SortByScore();

            Action getPathAndSave = () =>
            {
                var path = ConsoleUtils.PromptUser("Enter path to file");
                studentService.SaveData(path, myClass.Students);
                Console.WriteLine("The file has been saved.");
            };
            ConsoleUtils.PromptYesNoOptionAndAct("Do you want to save your work on disk (Y/n)?", getPathAndSave, () => Console.WriteLine("You can now close the program"));

        }

   
    void PrintData(List<Student> data)
    {
        Console.WriteLine("ID\tFirstname\tLastname\tScore");
        Console.WriteLine("---------------------------------------------------------");
        foreach (var learner in data)
        {
            Console.WriteLine($"{learner.Id}\t{learner.Firstname}\t\t{learner.Lastname}\t\t{learner.Score}");
        }

    }
    List<Student> GetDataFromUser()
    {
        var students = new List<Student>();
        int studentCounter = Convert.ToInt32(ConsoleUtils.PromptUser("How many students are there? "));


        for (var i = 0; i < studentCounter; i++)
        {
            var id = Convert.ToInt32(ConsoleUtils.PromptUser($"Student[{i + 1}]: Enter ID: "));
            var fname = ConsoleUtils.PromptUser($"Student[{i + 1}]: Enter Firstname: ");
            var lname = ConsoleUtils.PromptUser($"Student[{i + 1}]: Enter Lastname: ");
            var score = float.Parse(ConsoleUtils.PromptUser($"Student[{i + 1}]: Enter Score: "));
            var student = new Student() { Id = id, Firstname = fname, Lastname = lname, Score = score };
            students.Add(student);
        }

        return students;

    }
}
}
