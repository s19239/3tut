using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial3.Models;

namespace tutorial3.Services
{
    public class MockDbService : IDbService
    {
        private static  IEnumerable<Student> Students;

        static MockDbService()
        {
            Students = new List<Student>
            {
                new Student {IdStudent = 1, FirstName = "Aliia", LastName = "Baimuratova", IndexNumber = "s1923"},
                new Student {IdStudent = 2, FirstName = "Ahmed", LastName = "Zakirov", IndexNumber = "s1564"},
                new Student {IdStudent = 3, FirstName = "Alan", LastName = "Baimuratova", IndexNumber = "s1555"}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return Students;
        }

        public string GetStudentById(int id)
        {
            foreach (var student in Students)
                if (student.IdStudent == id)
                    return student.ToString();

            return "student not found";
        }

        public bool IdExists(int id)
        {
            return Students.Any(student => student.IdStudent == id);
        }

        public string AddStudent(Student student)
        {
            ((List<Student>)Students).Add(student);
            return "Student successfully added";
        }

        public string EditStudentById(int id, string newFn, string newLn, string newIndexNumber)
        {
            foreach (var student in Students)
            {
                if (student.IdStudent != id) continue;
                if (newFn != null) student.FirstName = newFn;
                if (newLn != null) student.LastName = newLn;
                if (newIndexNumber != null) student.IndexNumber = newIndexNumber;
                return "Student successfully updated";
            }

            return "Student failed to update";
        }

        public string RemoveStudentById(int id)
        {
            var studentToRm = ((List<Student>)Students).SingleOrDefault(student => student.IdStudent == id);
            if (studentToRm == null) return "Student failed to remove";
            ((List<Student>)Students).Remove(studentToRm);
            return "Student successfully removed";
        }
    }
}
