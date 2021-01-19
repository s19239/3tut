using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial3.Models;

namespace tutorial3.Services
{
    public class SQLServerdb:IStudentsDal
    {
        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

    }
}
