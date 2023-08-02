using System.Collections.Generic;
using System.Linq;

namespace practice1.StudentMark.Models
{
    public class Course
    {
        public string TeacherName { get; set; }
        public string LessonTopic { get; set; }
        public int StudentCount { get; set; }

        public List<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
        public void Enroll(Student student)
        {
            Students.Add(student);
        }
        public float GetAverageScore()
        {
            var sum = Students.Sum(student => student.Score);

            return sum / Students.Count;
        }
    }

}
