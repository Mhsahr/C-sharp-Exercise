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

            Console.WriteLine("Choose what you ask to do:");
            Console.WriteLine("1 for loading the previous data");
            Console.WriteLine("2 for editing the table");
            Console.WriteLine("3 for deleting a row");
            Console.WriteLine("4 for adding a row");
            Console.WriteLine("5 for getting new datas");
            Console.WriteLine("6 for showing the table");
            Console.WriteLine("7 for sorting the scores");
            Console.WriteLine("8 for saving the datas");

            int menu = Convert.ToInt32(Console.ReadLine());


            var myClass = new Course();

          

            

            

            switch (menu)
            {
                case 1:
                    Console.WriteLine("Enter path to file");
                    var path = Console.ReadLine();
                    myClass.Students = service.LoadData(path);
                    controller.PrintData(myClass.Students);
                    break;

                case 5:
                    myClass.Students = controller.GetDataFromUser();
                    controller.PrintData(myClass.Students);
                    break;

                case 6:
                    controller.PrintData(myClass.Students);
                    break;

                case 7:
                    myClass.SortByScore();
                    break;

                case 8:
                    path = StudentUtils.PromptUser("Enter path to file");
                    service.SaveData(path, myClass.Students);
                    Console.WriteLine("The file has been saved.");
                    break;

                

            }
            var select = StudentUtils.PromptUser("Do you want to continue?(Y/n)");

            while (select != "n".ToLower())
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
                menu = Convert.ToInt32(Console.ReadLine());





                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Enter path to file");
                        var path = Console.ReadLine();
                        myClass.Students = service.LoadData(path);
                        controller.PrintData(myClass.Students);
                        break;

                    case 5:
                        myClass.Students = controller.GetDataFromUser();
                        controller.PrintData(myClass.Students);
                        break;

                    case 6:
                        controller.PrintData(myClass.Students);
                        break;

                    case 7:
                        myClass.SortByScore();
                        break;

                    case 8:
                        path = StudentUtils.PromptUser("Enter path to file");
                        service.SaveData(path, myClass.Students);
                        Console.WriteLine("The file has been saved.");
                        break;
                   

                    
                }
                select = StudentUtils.PromptUser("Do you want to continue?");


            }
            Console.WriteLine("The program is closed.");
        }
    }
}
