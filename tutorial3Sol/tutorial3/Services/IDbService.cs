using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial3.Models;

namespace tutorial3.Services
{
  public  interface IDbService
    {
        public IEnumerable<Student> GetStudents();

        public string GetStudentById(int id);

        public string AddStudent(Student student);

        public string EditStudentById(int id, string newFn, string newLn, string newIndexNum);

        public string RemoveStudentById(int id);

        public bool IdExists(int id);
    }
}
