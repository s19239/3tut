using System;
using System.Collections.Generic;
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
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy = "FirstName")
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (_dbService.IdExists(id) == true) return Ok(_dbService.GetStudentById(id));
            return NotFound("Student was not found");
        }

        [HttpPost]
        public IActionResult CreateAndAddStudent(Student student)
        {
            var newIndexNum = $"s{new Random().Next(1, 20000)}";
            student.IndexNumber = newIndexNum;
            if (_dbService.IdExists(student.IdStudent) == false)
                return Ok(_dbService.AddStudent(student));
            return UnprocessableEntity("Student with this id already exits");
        }

        [HttpPut("{id}")]
        public IActionResult EditStudent(int id, string fName = null, string lName = null, string indNum = null)
        {
            if (_dbService.IdExists(id))
                return Ok(_dbService.EditStudentById(id, fName, lName, indNum));
            return NotFound("Student not found");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveStudent(int id)
        {
            if (_dbService.IdExists(id))
                return Ok(_dbService.RemoveStudentById(id));
            return NotFound("Student not found");
        }
    }

}