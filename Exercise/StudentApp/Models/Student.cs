using System;
using System.Collections.Generic;
using System.Text;
using StudentMark.App;

namespace ConsoleApp4.Models
{
    class Student
    {
        public int  Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public float Score { get; set; }

     


        public string AsCommaSeparated()
        {

            return $"{Id},{Firstname},{Lastname},{Score}";
        }
    }
}
