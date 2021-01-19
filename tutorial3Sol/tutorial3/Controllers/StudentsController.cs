using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tutorial3.Models;
using tutorial3.Services;

namespace tutorial3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
       // private readonly IDbService _dbService;
        private readonly string con = "Data Source=db-mssql;Initial Catalog=s19239;Integrated Security=True";



        //We want to return the data in the form of name, surname, date of birth, name of studies and semester number.
        
            
            /* SELECT s.FirstName, s.LastName, s.BirthDate, st.Name as Studies , e.Semester 
        from Student s
       left join Enrollment e on e.IdEnrollment = s.IdEnrollment
       left join Studies st on st.IdStudy = e.IdStudy;
       */
         [HttpGet]
        public IActionResult GetStudent()
        {
            var students = new List<Student>();
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "select s.FirstName, s.LastName, s. BirthDate, st.Name as Studies, e.Semester " +
                        "from Student s " +
                        "join Enrollment e on e.IdEnrollment = s.IdEnrollment " +
                        "join Studies st on st.IdStudy = e.IdStudy ";
                    sqlConnection.Open();
                    var response = command.ExecuteReader();
                    while (response.Read())
                    {
                        var st = new Student();
                        st.FirstName = response["FirstName"].ToString();
                        st.LastName = response["LastName"].ToString();
                        st.Studies = response["Studies"].ToString();
                        st.Semester = int.Parse(response["Semester"].ToString());
                        st.BirthDate = DateTime.Parse(response["Birthdate"].ToString());

                        students.Add(st);

                    }
                }
            }
            return Ok(students);
        }

        //endpoint returns semester entries (WpisNaSemestr)
        /* select e.Semester 
           from  Enrollment e ,Student st
          where e.IdEnrollment = st.IdEnrollment 
          AND st.IndexNumber = 2;
         */
        [HttpGet("{id}")]
        public IActionResult GetEntries(string id)
        {
            int semester;
            var entries = new List<int>();
            int sem = 0;
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "select e.Semester " +
                        "from Enrollment e, Student st  " +
                        "where e.IdEnrollment = st.IdEnrollment and st.IndexNumber = @id;";
                    command.Parameters.AddWithValue("id", id);
                    sqlConnection.Open();
                    var response = command.ExecuteReader();
                    if (response.Read())
                    {
                        sem = int.Parse(response["Semester"].ToString());


                    }
                }
            }
            return Ok(sem);
        }

        
    }

}