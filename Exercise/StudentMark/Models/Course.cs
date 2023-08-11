using System.Collections.Generic;
using System.Linq;

namespace CSV.Models
{
    public class Course
    {
        public string TeacherName { get; set; }
        public string LessonTopic { get; set; }
        public int StudentCount { get; set; }
        public List<Student> Students { get; set; }
        public int Score { get; private set; }


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



        public Course(string teacherName, string lessonTopic, int studenCount)
        {
            TeacherName = teacherName;
            LessonTopic = lessonTopic;
            StudentCount = studenCount;
        }

       
    }

}
