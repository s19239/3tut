using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial3.Models
{
    public class Student
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Semester { get; set; }
        public string Studies { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
