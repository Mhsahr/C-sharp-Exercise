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
            Console.WriteLine("2 for getting new data");
            int menu = Convert.ToInt32(Console.ReadLine());


            var student = new Student();
            var myClass = new Class();
            switch (menu)
            {
                case 1:
                    Console.WriteLine("Enter path to file");
                    var path = Console.ReadLine();
                    myClass.Students = service.LoadData(path);
                    controller.PrintData(myClass.Students);
                    break;

                //try
                //{
                //    Console.WriteLine("Enter path to file");
                //    var path = Console.ReadLine();
                //    students.Students = service.LoadData(path);
                //    controller.PrintData(students.Students);
                //    break;
                //}
                //catch (Exception)
                //{
                //    Console.WriteLine("Enter the right path");
                //    var path = Console.ReadLine();
                //    students.Students = service.LoadData(path);
                //    controller.PrintData(students.Students);
                //    break;
                //}

                case 2:
                    myClass.Students = controller.GetDataFromUser();
                    controller.PrintData(myClass.Students);
                    break;
                   
            }

            var select = StudentUtils.PromptUser("Do you want to continue?(Y/n)");
            if (select == "y".ToLower() || select == "n".ToLower())
            {
                while (select == "y".ToLower())
                {

                    AskQuestion();
                    menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("Enter path to file");
                                var path = Console.ReadLine();
                                myClass.Students = service.LoadData(path);
                                controller.PrintData(myClass.Students);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Enter the right path");
                                var path = Console.ReadLine();
                                myClass.Students = service.LoadData(path);
                                controller.PrintData(myClass.Students);
                                break;
                            }

                        case 2:
                            myClass.Students = controller.GetDataFromUser();
                            controller.PrintData(myClass.Students);
                            break;

                        case 3:
                            controller.Delete(myClass.Students);
                            break;

                        case 4:
                            controller.AddData(myClass.Students);
                            break;

                        case 5:
                            controller.Edit(myClass.Students);
                            break;

                        case 6:
                            controller.PrintData(myClass.Students);
                            break;

                        case 7:
                            myClass.Students.Sort((x, y) => x.Score.CompareTo(y.Score));
                            foreach (Student item in myClass.Students)
                            {
                                Console.WriteLine(item.Score);
                            }
                            break;

                        case 8:
                            float average = myClass.GetAverageScore();
                            Console.WriteLine($"The average is: {average}");
                            break;

                        case 9:
                            try
                            {
                                var savingPath = StudentUtils.PromptUser("Enter path to file");
                                service.SaveData(savingPath, myClass.Students);
                                Console.WriteLine("The file has been saved.");
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Enter the right path");
                                var savingPath = Console.ReadLine();
                                service.SaveData(savingPath, myClass.Students);
                                Console.WriteLine("The file has been saved.");
                                break;
                            }
                    }
                    select = StudentUtils.PromptUser("Do you want to continue?(Y/n)");

                }
                Console.WriteLine("The program is closed.");
            }
            
        }

        static void AskQuestion()
        {
            Console.WriteLine("Choose what you ask to do:");
            Console.WriteLine("1 for loading the previous data");
            Console.WriteLine("2 for getting new data");
            Console.WriteLine("3 for deleting a row");
            Console.WriteLine("4 for adding a row");
            Console.WriteLine("5 for editing the table");
            Console.WriteLine("6 for showing the table");
            Console.WriteLine("7 for sorting the scores");
            Console.WriteLine("8 for getting an average for scores");
            Console.WriteLine("9 for saving the data");
        }

    }
}
