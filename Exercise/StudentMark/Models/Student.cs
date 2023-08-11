using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Models
{
    [Serializable]
    public class Student
    {


        [CsvColumn(Name = "ID")]
        public int ID { get; set; }

        [CsvColumn(Name = "firstname")]
        public string Firstname { get; set; }

        [CsvColumn(Name = "lastname")]
        public string Lastname { get; set; }

        [CsvColumn(Name = "score")]
        public float Score { get; set; }

        public Student()
        {

        }

        public Student(int id, string firstname, string lastname, float score)
        {
            ID = id;
            Firstname = firstname;
            Lastname = lastname;
            Score = score;
        }
        
    }


}
