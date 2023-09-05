using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp.Models
{
    class Student : Person
    {
        public float Score { get; set; }


        public string AsCommaSeparated()
        {

            return $"{Id},{FirstName},{LastName},{Score}";
        }

       
    }

}
