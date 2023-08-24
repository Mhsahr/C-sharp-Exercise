using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Models
{
    class Class
    {
        public string TeacherName { get; set; }
        public string LessonTopic { get; set; }
        public int StudentCount { get; set; }

        public List<Student> Students { get; set; }

        public void SortByScore()
        {
            Students.Sort((x, y) => x.Score.CompareTo(y.Score));


        }
    }
}
