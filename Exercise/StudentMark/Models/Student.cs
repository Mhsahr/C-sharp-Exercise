namespace practice1.StudentMark.Models
{
    public class Student
    {
        public int Id;
        public string Firstname;
        public string Lastname;
        public float Score;

        public Student()
        {

        }

        public Student(int id, string firstname, string lastname, float score)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Score = score;
        }
    }

}
