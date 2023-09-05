using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp.Models
{
    class Class : Person
    {
        public string LessonTopic { get; set; }
        public int StudentCount { get; set; }

        public List<Student> Students { get; set; }

        public float GetAverageScore()
        {
            var sum = Students.Sum(student => student.Score);

            return sum / Students.Count;
        }



    }

}
