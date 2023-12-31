﻿using StudentApp.Models;
using System;
using System.Collections.Generic;
using StudentApp.Utils;
using System.Linq;

namespace StudentApp.Controllers
{
    class StudentControllers
    {

        public void PrintData(List<Student> data)
        {

            Console.WriteLine("ID\tFirstname\tLastname\tScore");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var learner in data)
            {

                Console.WriteLine($"{learner.Id}\t{learner.FirstName}\t\t{learner.LastName}\t\t{learner.Score}");

            }

        }

        public List<Student> GetDataFromUser()
        {

            var students = new List<Student>();
            int studentCounter = Convert.ToInt32(StudentUtils.PromptUser("How many students are there? "));

            try
            {

                for (var i = 0; i < studentCounter; i++)
                {

                    var id = Convert.ToInt32(StudentUtils.PromptUser($"Student[{i + 1}]: Enter ID: "));
                    var fname = StudentUtils.PromptUser($"Student[{i + 1}]: Enter Firstname: ");
                    var lname = StudentUtils.PromptUser($"Student[{i + 1}]: Enter Lastname: ");
                    var score = float.Parse(StudentUtils.PromptUser($"Student[{i + 1}]: Enter Score: "));
                    var student = new Student() { Id = id, FirstName = fname, LastName = lname, Score = score };
                    students.Add(student);

                }

            }
            catch (Exception)
            {

                students.Clear();
                Console.WriteLine("Do it again.");
                for (var i = 0; i < studentCounter; i++)
                {
                    var id = Convert.ToInt32(StudentUtils.PromptUser($"Student[{i + 1}]: Enter ID: "));
                    var fname = StudentUtils.PromptUser($"Student[{i + 1}]: Enter Firstname: ");
                    var lname = StudentUtils.PromptUser($"Student[{i + 1}]: Enter Lastname: ");
                    var score = float.Parse(StudentUtils.PromptUser($"Student[{i + 1}]: Enter Score: "));
                    var student = new Student() { Id = id, FirstName = fname, LastName = lname, Score = score };
                    students.Add(student);
                }
            }
            return students;

        }

        public void Delete(List<Student> students)
        {

            int numberId = Convert.ToInt32(StudentUtils.PromptUser("Enter the ID you want to change: "));

            var itemToRemove = students.Single(r => r.Id == numberId);
            students.Remove(itemToRemove);

        }

        public void Edit(List<Student> students)
        {

        int numberId = Convert.ToInt32(StudentUtils.PromptUser("Enter the ID you want to change:"));
            
            students.RemoveAt(numberId);

            var id = Convert.ToInt32(StudentUtils.PromptUser("Enter ID: "));
        var fname = StudentUtils.PromptUser("Enter Firstname: ");
        var lname = StudentUtils.PromptUser("Enter Lastname: ");
        var score = float.Parse(StudentUtils.PromptUser("Enter Score: "));
        var student = new Student() { Id = id, FirstName = fname, LastName = lname, Score = score };

            students.Insert(numberId, student);

        }

        public void AddData(List<Student> students)
        {

            var id = Convert.ToInt32(StudentUtils.PromptUser("Enter ID: "));
            var fname = StudentUtils.PromptUser("Enter Firstname: ");
            var lname = StudentUtils.PromptUser("Enter Lastname: ");
            var score = float.Parse(StudentUtils.PromptUser("Enter Score: "));
            var student = new Student() { Id = id, FirstName = fname, LastName = lname, Score = score };
            students.Add(student);

        }
    }
}
