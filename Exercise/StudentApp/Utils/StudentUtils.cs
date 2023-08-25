using System;


namespace StudentApp.Utils
{
  
        public static class StudentUtils
        {
            public static void PromptYesNoOptionAndAct(string msg, Action runIfYes, Action runIfNo, string defaultChoice = "Y")
            {
                var choice = PromptUser(msg, defaultChoice);

                switch (choice.ToUpper())
                {
                    case "N":
                        runIfNo();
                        break;
                    case "Y":
                        runIfYes();
                        break;

                }
            }
            public static string PromptUser(string message, string defaultValue = "")
            {
                Console.WriteLine(message);
                var userInput = Console.ReadLine();
                if (userInput == string.Empty)
                    return defaultValue;
                return userInput;

            }
        }
    
}

