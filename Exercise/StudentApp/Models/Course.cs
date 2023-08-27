using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Models
{
    class Course : Person
    {
        public string LessonTopic { get; set; }
        public int StudentCount { get; set; }


        public void SortByScore()
        {
            var students = new Student();
            students.Students.Sort((x, y) => x.Score.CompareTo(y.Score));
        }
    }
}
