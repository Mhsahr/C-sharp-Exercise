using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_Exercise
{
    class NameListSorting
    {
        static List<string> nameList = new List<string>();

        public static void Run()
        {

            var shouldContinue = true;



            while (shouldContinue)
            {
                var name = GetNameFromUser();
                nameList.Add(name);
                shouldContinue = AskUserIfShouldContinue();
            }
            nameList.Sort();

            PrintNames();
        }
        static string GetNameFromUser()
        {
            Console.WriteLine("What name do you want to add : ");
            return Console.ReadLine();
        }
        static void PrintNames()
        {
            foreach (string i in nameList)
            {
                Console.WriteLine(i);
            }
        }
        static bool AskUserIfShouldContinue()
        {
            while (true)
            {
                Console.WriteLine("Do you want to continue (yes/no): ");
                var action = Console.ReadLine();
                switch (action.ToLower())
                {
                    case "yes":
                        return true;

                    case "no":
                        Console.WriteLine("Receiving new names stopped.");
                        return false;
                    default:
                        Console.WriteLine("Wrong input! Try Again");
                        continue;
                }

            }
        }
    }
}
