﻿using System;

namespace StudentApp
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mahsa Student Management System v2.5.3");

            var menu = new Menu();
            menu.Run();

        }

    }
}
