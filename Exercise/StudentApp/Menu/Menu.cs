using StudentApp.Controllers;
using StudentApp.Models;
using StudentApp.Services;
using System;
using StudentApp.Utils;

namespace StudentApp
{
    class Menu
    {
        private readonly StudentServices service;
        private readonly StudentControllers controller;

        public Menu()
        {
            service = new StudentServices();
            controller = new StudentControllers();
        }
        public void Run()
        {
            AskQuestion();
            int menu = Convert.ToInt32(Console.ReadLine());


            var students = new Student();
            var myClass = new Course();
            switch (menu)
            {
                case 1:
                    Console.WriteLine("Enter path to file");
                    var path = Console.ReadLine();
                    students.Students = service.LoadData(path);
                    controller.PrintData(students.Students);
                    break;

                case 2:
                    controller.Edit(students.Students);
                    break;

                case 3:
                    controller.Delete(students.Students);
                    break;

                case 4:
                    controller.AddData(students.Students);
                    controller.PrintData(students.Students);
                    break;

                case 5:
                    students.Students = controller.GetDataFromUser();
                    controller.PrintData(students.Students);
                    break;

                case 6:
                    controller.PrintData(students.Students);
                    break;

                case 7:
                    myClass.SortByScore();
                    break;

                case 8:
                    path = StudentUtils.PromptUser("Enter path to file");
                    service.SaveData(path, students.Students);
                    Console.WriteLine("The file has been saved.");
                    break;
            }
            var select = StudentUtils.PromptUser("Do you want to continue?(Y/n)");

            while (select != "n".ToLower())
            {

                AskQuestion();
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Enter path to file");
                        var path = Console.ReadLine();
                        students.Students = service.LoadData(path);
                        controller.PrintData(students.Students);
                        break;

                    case 2:
                        controller.Edit(students.Students);
                        break;

                    case 3:
                        controller.Delete(students.Students);
                        break;

                    case 4:
                        controller.AddData(students.Students);
                        break;

                    case 5:
                        students.Students = controller.GetDataFromUser();
                        controller.PrintData(students.Students);
                        break;

                    case 6:
                        controller.PrintData(students.Students);
                        break;

                    case 7:
                        myClass.SortByScore();
                        break;

                    case 8:
                        path = StudentUtils.PromptUser("Enter path to file");
                        service.SaveData(path, students.Students);
                        Console.WriteLine("The file has been saved.");
                        break;
                }
                select = StudentUtils.PromptUser("Do you want to continue?(Y/n)");

            }
            Console.WriteLine("The program is closed.");
        }

        static void AskQuestion()
        {
            Console.WriteLine("Choose what you ask to do:");
            Console.WriteLine("1 for loading the previous data");
            Console.WriteLine("2 for editing the table");
            Console.WriteLine("3 for deleting a row");
            Console.WriteLine("4 for adding a row");
            Console.WriteLine("5 for getting new datas");
            Console.WriteLine("6 for showing the table");
            Console.WriteLine("7 for sorting the scores");
            Console.WriteLine("8 for saving the datas");
        }


    }
}
