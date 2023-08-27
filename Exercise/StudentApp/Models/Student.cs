using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Models
{
    class Student : Person
    {
        public float Score { get; set; }

        public List<Student> Students { get; set; }


        public string AsCommaSeparated()
        {

            return $"{Id},{FirstName},{LastName},{Score}";
        }
    }
}
