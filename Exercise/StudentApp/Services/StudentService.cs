using ConsoleApp4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp4.Services
{
    class StudentService
    {
        public List<Student> LoadData(string path)
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
                    return students;
                }
            }

            catch (Exception)
            {
                throw new InvalidDataException("Couldn't find or parse data");
            }


        }

        public void SaveData(string path, List<Student> students)
        {

            var studentsAsCommaSeparated = students.Select(s => s.AsCommaSeparated());

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "students.csv")))

            {
                //outputFile.WriteLine("ID, Firstname, Lastname, Score");

                foreach (string line in studentsAsCommaSeparated)
                    outputFile.WriteLine(line);

            }
            // create the file

            // write to file

        }
    }
}
